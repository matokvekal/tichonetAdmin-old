
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
    
public partial class Driver
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Driver()
    {

        this.tblSchedules = new HashSet<tblSchedule>();

    }


    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Company { get; set; }

    public string CellNumber { get; set; }

    public string GpsId { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblSchedule> tblSchedules { get; set; }

}

}
