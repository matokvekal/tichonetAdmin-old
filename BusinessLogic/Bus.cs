
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Business_Logic
{

using System;
    using System.Collections.Generic;
    
public partial class Bus
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Bus()
    {

        this.BusesToLines = new HashSet<BusesToLine>();

        this.tblSchedules = new HashSet<tblSchedule>();

    }


    public int Id { get; set; }

    public string BusId { get; set; }

    public string PlateNumber { get; set; }

    public Nullable<int> BusType { get; set; }

    public Nullable<int> Occupation { get; set; }

    public Nullable<int> Owner { get; set; }

    public Nullable<int> GpsSource { get; set; }

    public string GpsCode { get; set; }

    public Nullable<int> seats { get; set; }

    public Nullable<double> price { get; set; }

    public Nullable<System.DateTime> munifacturedate { get; set; }

    public Nullable<System.DateTime> LicensingDueDate { get; set; }

    public Nullable<System.DateTime> insuranceDueDate { get; set; }

    public Nullable<System.DateTime> winterLicenseDueDate { get; set; }

    public Nullable<System.DateTime> brakeTesDueDate { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<BusesToLine> BusesToLines { get; set; }

    public virtual tblBusCompany BusCompany { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblSchedule> tblSchedules { get; set; }

}

}
