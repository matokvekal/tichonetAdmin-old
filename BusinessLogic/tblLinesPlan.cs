
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
    
public partial class tblLinesPlan
{

    public int Id { get; set; }

    public int LineId { get; set; }

    public Nullable<bool> Sun { get; set; }

    public Nullable<System.DateTime> SunTime { get; set; }

    public Nullable<bool> Mon { get; set; }

    public Nullable<System.DateTime> MonTime { get; set; }

    public Nullable<bool> Tue { get; set; }

    public Nullable<System.DateTime> TueTime { get; set; }

    public Nullable<bool> Wed { get; set; }

    public Nullable<System.DateTime> WedTime { get; set; }

    public Nullable<bool> Thu { get; set; }

    public Nullable<System.DateTime> ThuTime { get; set; }

    public Nullable<bool> Fri { get; set; }

    public Nullable<System.DateTime> FriTime { get; set; }

    public Nullable<bool> Sut { get; set; }

    public Nullable<System.DateTime> SutTime { get; set; }



    public virtual Line Line { get; set; }

}

}
