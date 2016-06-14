﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic.Enums;

namespace Business_Logic
{
    public class StationsLogic : baseLogic
    {
        public Station Save(Station station)
        {
            if (DB.Stations.Any(z => z.Id == station.Id))
            {
                // update station
                DB.Stations.Attach(station);
                DB.Entry(station).State = EntityState.Modified;

                ////Update Attached student colors
                //foreach (var rec in DB.StudentsToStations.Where(z => z.StationId == station.Id))
                //{
                //    var st = DB.tblStudents.FirstOrDefault(z => z.pk == rec.StudentId);
                //    if (st != null) st.Color = station.Color;
                //}
            }
            else
            {
                //add station
                DB.Stations.Add(station);
            }
            DB.SaveChanges();
            return station;
        }


        public Station GetStation(int id)
        {
            return DB.Stations.FirstOrDefault(z => z.Id == id);
        }

        public List<Station> GetStations(List<int> ids)
        {
            return DB.Stations.Where(z => ids.Contains( z.Id )).ToList();
        }


        public List<StudentsToLine> GetStudents(int stationsId)
        {
            return DB.StudentsToLines.Where(z => z.StationId == stationsId).ToList();
        }

      
        public List<Station> GetList()
        {
            return DB.Stations.ToList();
        }

       
        public List<Station> GetStationForLine(int lineId)
        {
            return DB.StationsToLines
                .Where(z => z.LineId == lineId)
                .Select(z => z.Station)
                .ToList();
        }

        public bool Delete(int Id)
        {
            var res = false;
            try
            {
                var itm = DB.Stations.FirstOrDefault(z => z.Id == Id);
                if (itm != null)
                {
                    DB.Stations.Remove(itm);
                    DB.SaveChanges();
                    res = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return res;
        }

        public bool AddToLine(int stationId, int lineId, TimeSpan arrivalTime, int position, bool changeColor)
        {
            var res = false;
            try
            {
                //Remove old value if it exists
                var itm = DB.StationsToLines.FirstOrDefault(z => z.LineId == lineId && z.StationId == stationId);
                if (itm != null)
                {
                    DB.StationsToLines.Remove(itm);
                    DB.SaveChanges();
                }
                var stationsOnLine = DB.StationsToLines.Where(z => z.LineId == lineId).OrderBy(z => z.Position); //All station of line exclude  new
                foreach (var station in stationsOnLine)
                {
                    //If position of station equals ore more that new station position then move to one position
                    if (station.Position >= position) station.Position++;
                }
                itm = new StationsToLine
                {
                    LineId = lineId,
                    StationId = stationId,
                    ArrivalDate = arrivalTime,
                    Position = position
                };
                DB.StationsToLines.Add(itm);
                if (changeColor)
                {
                    var station = DB.Stations.FirstOrDefault(z => z.Id == stationId);
                    var line = DB.Lines.FirstOrDefault(z => z.Id == lineId);
                    if (station != null && line != null)
                        station.color = line.HexColor;
                }
                DB.SaveChanges();
                using (var logic = new LineLogic())
                {
                    logic.UpdateStudentCount();
                }
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return res;
        }

        public bool SaveOnLine(int stationId, int lineId, TimeSpan arrivalTime, int position, bool changeColor)
        {
            var res = false;
            try
            {
                var itm = DB.StationsToLines.FirstOrDefault(z => z.LineId == lineId && z.StationId == stationId);
                if (itm != null)
                {
                    if (itm.Position != position) //reorder
                    {
                        var p = 1;
                        foreach (var station in DB.StationsToLines.Where(z => z.LineId == lineId).OrderBy(z => z.Position))
                        {
                            if (station.StationId != stationId)
                            {
                                if (p == position) p++;
                                station.Position = p;
                                p++;
                            }
                        }
                        itm.Position = position;
                    }
                    itm.ArrivalDate = arrivalTime;
                    if (changeColor)
                    {
                        var station = DB.Stations.FirstOrDefault(z => z.Id == stationId);
                        var line = DB.Lines.FirstOrDefault(z => z.Id == lineId);
                        if (station != null && line != null)
                            station.color = line.HexColor;
                    }
                    DB.SaveChanges();
                    using (var logic = new LineLogic())
                    {
                        logic.UpdateStudentCount();
                    }
                    res = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return res;
        }

        public bool DeleteFromLine(int stationId, int lineId)
        {
            var res = false;
            try
            {
                var itm = DB.StationsToLines.FirstOrDefault(z => z.LineId == lineId && z.StationId == stationId);
                if (itm != null)
                {
                    DB.StationsToLines.Remove(itm);
                    DB.SaveChanges();
                    var p = 1;
                    foreach (var station in DB.StationsToLines.Where(z => z.LineId == lineId).OrderBy(z => z.Position))
                    {
                        station.Position = p;
                        p++;
                    }
                    DB.SaveChanges();
                    using (var logic = new LineLogic())
                    {
                        logic.UpdateStudentCount();
                    }
                    res = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return res;
        }

        public bool AttachStudent(int studentId, int stationId,int? lineId, int distance, ColorMode colorMode, DateTime? date)
        {
            var res = false;
            try
            {
                using (var logic = new LineLogic())
                {
                    //Remove duplicate
                    var duplicates = DB.StudentsToLines
                        .Where(z => z.StudentId == studentId && z.Date == date);
                                    //z.StationId == stationId &&
                                    //z.LineId == lineId &&
                                    
                    DB.StudentsToLines.RemoveRange(duplicates);
                    DB.SaveChanges();


                    var student = DB.tblStudents.FirstOrDefault(z => z.pk == studentId);
                    if (student == null) return false;
                    var station = DB.Stations.FirstOrDefault(z => z.Id == stationId);
                    if (station == null) return false;
                    var line = DB.Lines.FirstOrDefault(z => z.Id == lineId);

                    var direction = 0;
                    if (line != null) direction = line.Direction;
                    
                    if (colorMode == ColorMode.Station)
                    {
                        student.Color = station.color;
                    }

                    if (line != null && colorMode == ColorMode.Line)
                    {
                        student.Color = line.HexColor;
                    }

                    var item = new StudentsToLine
                    {
                        StudentId = studentId,
                        StationId = stationId,
                        LineId = lineId,
                        color = student.Color,
                        Date = null,
                        Direction = direction,
                        distanceFromStation = distance
                    };
                    DB.StudentsToLines.Add(item);
                    DB.SaveChanges();

                    logic.UpdateStudentCount();
                }
                res = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return res;
        }
    }
}

