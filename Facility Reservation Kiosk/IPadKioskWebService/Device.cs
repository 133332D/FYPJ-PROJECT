//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IPadKioskWebService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Device
    {
        public int DeviceID { get; set; }
        public string DepartmentID { get; set; }
        public Nullable<int> DefaultDepartmentFilterID { get; set; }
        public string DeviceGeneratedUniqueID { get; set; }
        public string PublicKey { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> ApprovedDateTime { get; set; }
        public Nullable<System.DateTime> RejectedOrRevokedDateTime { get; set; }
        public string RejectedOrRevokedReason { get; set; }
        public string Description { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual DepartmentFilter DepartmentFilter { get; set; }
    }
}
