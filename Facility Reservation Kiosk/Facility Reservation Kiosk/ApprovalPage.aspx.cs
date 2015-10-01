﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Facility_Reservation_Kiosk
{
    public partial class ApprovalPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDeviceID.Text = Request.QueryString["searchID"];
            lblDateTime.Text = DateTime.Now.ToString("M/dd/yy");
         
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int ID = System.Convert.ToInt32(lblDeviceID.Text);
          
            using (var db = new FacilityReservationKioskEntities())
            {
                //Load up and update 

                Device device = db.Devices.Find(ID);

                //Modify fields
                device.Description = tbDescription.Text;
                device.DepartmentID =tbDepartment.Text;
                device.DefaultDepartmentFilterID = System.Convert.ToInt32(tbDefaultFilter.Text);
                device.PublicKey = "";
                device.DeviceGeneratedUniqueID = "";
                device.Status = "";
                device.ApprovedDateTime = DateTime.Now;
                device.RejectedOrRevokedDateTime = DateTime.Now;
                device.RejectedOrRevokedReason = "";


                db.Devices.Add(device);
                db.SaveChanges();
                
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}