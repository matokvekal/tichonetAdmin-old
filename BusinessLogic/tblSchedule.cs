
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
    
public partial class tblSchedule
{

    public int Id { get; set; }

    public Nullable<System.DateTime> Date { get; set; }

    public Nullable<int> Direction { get; set; }

    public Nullable<int> LineId { get; set; }

    public Nullable<int> DriverId { get; set; }

    public Nullable<int> BusId { get; set; }

    public Nullable<System.DateTime> leaveTime { get; set; }

    public Nullable<System.DateTime> arriveTime { get; set; }



    public virtual Line Line { get; set; }

    public virtual Driver Driver { get; set; }

    public virtual Bus Bus { get; set; }

}

}
