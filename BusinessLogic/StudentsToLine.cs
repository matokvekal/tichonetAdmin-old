//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class StudentsToLine
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LineId { get; set; }
        public int StationId { get; set; }
        public int Direction { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string color { get; set; }
        public Nullable<int> distanceFromStation { get; set; }
        public string PathGeometry { get; set; }
    
        public virtual Station Station { get; set; }
        public virtual Line Line { get; set; }
    }
}
