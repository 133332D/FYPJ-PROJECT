//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Facility_Reservation_Kiosk
{
    using System;
    using System.Collections.Generic;
    
    public partial class Camera
    {
        public int CameraID { get; set; }
        public string DepartmentID { get; set; }
        public string FacilityID { get; set; }
        public string IPAddress { get; set; }
        public Nullable<double> MinimumDensity { get; set; }
        public Nullable<double> MaximumDensity { get; set; }
        public Nullable<double> CurrentDensity { get; set; }
    
        public virtual Department Department { get; set; }
    }
}
