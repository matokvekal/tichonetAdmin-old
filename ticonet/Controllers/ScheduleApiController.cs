﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;
using Business_Logic;
using ClosedXML.Excel;
using log4net;
using ticonet.Models;
using Business_Logic.Enums;

namespace ticonet.Controllers
{
    [System.Web.Mvc.Authorize]
    public class ScheduleApiController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ScheduleApiController));

        [System.Web.Mvc.HttpGet]
        public HttpResponseMessage GetLines(bool _search, string nd, int rows, int page, string sidx, string sord, string filters = "")
        {
            var lines = new List<GridLineModel>();
            var totalRecords = 0;
            using (var logic = new LineLogic())
            {
                lines = logic.GetList()
                    .Select(z => new GridLineModel(z)).ToList();
                totalRecords = logic.Lines.Count();
            }
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new
                {
                    //total = (totalRecords + rows - 1) / rows,
                    //page,
                    //records = totalRecords,
                    rows = lines
                });
        }

        [System.Web.Mvc.HttpGet]
        public HttpResponseMessage GetSchedule(bool _search, string nd, int rows, int page, string sidx, string sord, string filters = "")
        {
            var items = new List<ScheduleItemModel>();
            var totalRecords = 0;
            using (var logic = new tblScheduleLogic())
            {
                items = logic.GetPaged(_search, rows, page, sidx, sord, filters)
                    .Select(z => new ScheduleItemModel(z)).ToList();
                totalRecords = logic.Schedule.Count();
            }
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new
                {
                    total = (totalRecords + rows - 1) / rows,
                    page,
                    records = totalRecords,
                    rows = items
                });
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult EditItem(ScheduleItemModel model)
        {
            using (var logic = new tblScheduleLogic())
            {
                switch ((GridOperation)Enum.Parse(typeof(GridOperation), model.Oper, true))
                {
                    case GridOperation.add:
                        logic.SaveItem(model.ToDbModel());
                        break;
                    case GridOperation.edit:
                        logic.Update(model.ToDbModel());
                        break;
                    case GridOperation.del:
                        logic.DeleteItem(model.Id);
                        break;
                }
            }
            return new JsonResult { Data = true };
        }

        //public HttpResponseMessage GetExcel(bool _search, string nd, int rows, int page, string sidx, string sord, string filters = "")
        //{
        //    var lines = new GridLineModel[] {};
        //    var totalRecords = 0;
        //    using (var logic = new LineLogic())
        //    {
        //        totalRecords = logic.Lines.Count();
        //        lines = logic.GetPaged(_search, totalRecords, 1, sidx, sord, filters)
        //            .Select(z => new GridLineModel(z)).ToArray();
        //    }

        //    string Name = "Lines";
        //    var workbook = new XLWorkbook();
        //    var worksheet = workbook.Worksheets.Add(Name + " Sheet");
        //    worksheet.Outline.SummaryVLocation = XLOutlineSummaryVLocation.Top;

        //    worksheet.Cell(1, 1).Value = DictExpressionBuilderSystem.Translate("Line.LineName");
        //    worksheet.Cell(1, 2).Value = DictExpressionBuilderSystem.Translate("Line.LineNumber");
        //    worksheet.Cell(1, 3).Value = DictExpressionBuilderSystem.Translate("Line.Direction");
        //    worksheet.Cell(1, 4).Value = DictExpressionBuilderSystem.Translate("Line.IsActive");
        //    worksheet.Cell(1, 5).Value = DictExpressionBuilderSystem.Translate("Line.totalStudents");
        //    worksheet.Cell(1, 6).Value = DictExpressionBuilderSystem.Translate("Line.Duration");
        //    worksheet.Cell(1, 7).Value = DictExpressionBuilderSystem.Translate("Line.Sun");
        //    worksheet.Cell(1, 8).Value = DictExpressionBuilderSystem.Translate("Line.Mon");
        //    worksheet.Cell(1, 9).Value = DictExpressionBuilderSystem.Translate("Line.Tue");
        //    worksheet.Cell(1, 10).Value = DictExpressionBuilderSystem.Translate("Line.Wed");
        //    worksheet.Cell(1, 11).Value = DictExpressionBuilderSystem.Translate("Line.Thu");
        //    worksheet.Cell(1, 12).Value = DictExpressionBuilderSystem.Translate("Line.Fri");
        //    worksheet.Cell(1, 13).Value = DictExpressionBuilderSystem.Translate("Line.Sut");
        //    worksheet.Cell(1, 14).Value = DictExpressionBuilderSystem.Translate("Bus.BusId");
        //    worksheet.Cell(1, 15).Value = DictExpressionBuilderSystem.Translate("Bus.PlateNumber");
        //    worksheet.Cell(1, 16).Value = DictExpressionBuilderSystem.Translate("BusCompany.Name");
        //    worksheet.Cell(1, 17).Value = DictExpressionBuilderSystem.Translate("Bus.seats");

        //    for (int i = 0; i < lines.Length; i++)
        //    {
        //        var row = 2 + i;
        //        worksheet.Cell(row, 1).SetValue<string>(lines[i].LineName);
        //        worksheet.Cell(row, 2).SetValue<string>(lines[i].LineNumber);
        //        worksheet.Cell(row, 3).SetValue<string>(lines[i].Direction == 0? "To": "From");
        //        worksheet.Cell(row, 4).SetValue<bool>(lines[i].IsActive);
        //        worksheet.Cell(row, 5).SetValue<int>(lines[i].totalStudents);
        //        worksheet.Cell(row, 6).SetValue<string>(Convert.ToString(lines[i].Duration));
        //        worksheet.Cell(row, 7).SetValue<bool>(lines[i].Sun);
        //        worksheet.Cell(row, 8).SetValue<bool>(lines[i].Mon);
        //        worksheet.Cell(row, 9).SetValue<bool>(lines[i].Tue);
        //        worksheet.Cell(row, 10).SetValue<bool>(lines[i].Wed);
        //        worksheet.Cell(row, 11).SetValue<bool>(lines[i].Thu);
        //        worksheet.Cell(row, 12).SetValue<bool>(lines[i].Fri);
        //        worksheet.Cell(row, 13).SetValue<bool>(lines[i].Sut);
        //        worksheet.Cell(row, 14).SetValue<string>(lines[i].BusIdDescription);
        //        worksheet.Cell(row, 15).SetValue<string>(lines[i].PlateNumber);
        //        worksheet.Cell(row, 16).SetValue<string>(lines[i].BusCompanyName);
        //        worksheet.Cell(row, 17).SetValue<int?>(lines[i].seats);
        //    }

        //    worksheet.RangeUsed().Style.Border.InsideBorder = XLBorderStyleValues.Thin;
        //    worksheet.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.None;
        //    worksheet.Columns().AdjustToContents();

        //    var result = new HttpResponseMessage(HttpStatusCode.OK);
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        workbook.SaveAs(memoryStream);
        //        result.Content = new ByteArrayContent(memoryStream.GetBuffer());
        //        result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        //        {
        //            FileName = Name + ".xlsx"
        //        };
        //        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        //    }
        //    return result;
        //}


        //public GridLineModel[] GetPrint(bool _search, string nd, int rows, int page, string sidx, string sord, string filters = "")
        //{
        //    var lines = new GridLineModel[] { };
        //    var totalRecords = 0;
        //    using (var logic = new LineLogic())
        //    {
        //        totalRecords = logic.Lines.Count();
        //        lines = logic.GetPaged(_search, totalRecords, page, sidx, sord, filters)
        //            .Select(z => new GridLineModel(z)).ToArray();
        //    }

        //    return lines;
        //}
    }
}