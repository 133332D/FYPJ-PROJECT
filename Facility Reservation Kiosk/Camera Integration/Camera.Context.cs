﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FacilityReservationKioskEntities : DbContext
    {
        public FacilityReservationKioskEntities()
            : base("name=FacilityReservationKioskEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<VideoAnalytic> VideoAnalytics { get; set; }
    }
}
