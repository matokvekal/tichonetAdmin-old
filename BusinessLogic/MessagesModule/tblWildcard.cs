//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Business_Logic.MessagesModule
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblWildcard
    {
        public int Id { get; set; }
        public int tblRecepientFilterId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Key { get; set; }
    
        public virtual tblRecepientFilter tblRecepientFilter { get; set; }
    }
}
