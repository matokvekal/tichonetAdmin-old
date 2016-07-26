﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Business_Logic
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BusProjectEntities : DbContext
    {
        public BusProjectEntities()
            : base("name=BusProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<BusesToLine> BusesToLines { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<StationsToLine> StationsToLines { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentsToLine> StudentsToLines { get; set; }
        public virtual DbSet<tblAlertsQueue> tblAlertsQueues { get; set; }
        public virtual DbSet<tblBusCompany> tblBusCompanies { get; set; }
        public virtual DbSet<tblCalendar> tblCalendars { get; set; }
        public virtual DbSet<tblCulture> tblCultures { get; set; }
        public virtual DbSet<tblDictSystem> tblDictSystems { get; set; }
        public virtual DbSet<tblFamily> tblFamilies { get; set; }
        public virtual DbSet<tblMessageQueue> tblMessageQueues { get; set; }
        public virtual DbSet<tblPaymentOrder> tblPaymentOrders { get; set; }
        public virtual DbSet<tblSchedule> tblSchedules { get; set; }
        public virtual DbSet<tblStreet> tblStreets { get; set; }
        public virtual DbSet<tblStudent> tblStudents { get; set; }
        public virtual DbSet<tblSystem> tblSystems { get; set; }
        public virtual DbSet<tblYear> tblYears { get; set; }
        public virtual DbSet<tblLinesPlan> tblLinesPlans { get; set; }
    }
}
