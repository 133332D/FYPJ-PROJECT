//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Camera_Integration
{
    using System;
    using System.Collections.Generic;
    
    public partial class VideoAnalytic
    {
        public int VideoAnalyticsID { get; set; }
        public Nullable<int> CameraID { get; set; }
        public string IPAddress { get; set; }
        public Nullable<double> CrowdDensity { get; set; }
        public string SnapshotFile { get; set; }
    
        public virtual Camera Camera { get; set; }
    }
}
