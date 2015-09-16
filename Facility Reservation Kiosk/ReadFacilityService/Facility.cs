//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReadFacilityService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Facility
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Facility()
        {
            this.FacilityReservations = new HashSet<FacilityReservation>();
        }
    
        public string FacilityID { get; set; }
        public string DepartmentID { get; set; }
        public string Block { get; set; }
        public string Level { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public string MapPositionX { get; set; }
        public string MapPositionY { get; set; }
        public string OpenHours { get; set; }
        public string CloseHours { get; set; }
        public string MaxBkTime { get; set; }
        public string MaxBkUnits { get; set; }
        public string MinBkTime { get; set; }
        public string MinBkUnits { get; set; }
    
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacilityReservation> FacilityReservations { get; set; }
    }
}
