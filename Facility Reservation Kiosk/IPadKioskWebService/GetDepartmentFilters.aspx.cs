using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPadKioskWebService
{
    public partial class GetDepartmentFilters : System.Web.UI.Page
    {
        public class KioskContext : DbContext
        {
            //using the FacilityReservationKioskEntities Connection string
            public KioskContext()
                : base("name=FacilityReservationKioskEntities")
            {
            }
            public DbSet<DepartmentFilter> DepartmentFilters { get; set; }
        }

        public class FilterList
        {
            public List<FilterObject> Filters;
        }

        public class FilterObject
        {
            public int departmentFilterID { get; set; }
            public string departmentID { get; set; }
            public string filterName { get; set; }
            public string block { get; set; }
            public string level { get; set; }
            public string name { get; set; }

            public FilterObject(int dfid, string depid, string fn, string b, string l, string n)
            {
                this.departmentFilterID = dfid;
                this.departmentID = depid;
                this.filterName = fn;
                this.block = b;
                this.level = l;
                this.name = n;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //To get the string to search in depfilter table
            string departmentID = Request.QueryString["DepartmentID"];

            var sqlFilList = new FilterList();
            sqlFilList.Filters = new List<FilterObject>();

            using (var db = new KioskContext())
            {
                //selects only from departmentfilter where department ID  = SIT [Querystring]
                var depfilters = from df in db.DepartmentFilters
                                where df.Department.DepartmentID == departmentID

                                orderby df.FilterName
                                select new
                                {
                                    df.DepartmentFilterID,
                                    df.DepartmentID,
                                    df.FilterName,
                                    df.Block,
                                    df.Level,
                                    df.Name,
                                };

                foreach (var fil in depfilters)
                {
                    FilterObject filobject = new FilterObject(fil.DepartmentFilterID, fil.DepartmentID, fil.FilterName, fil.Block, fil.Level,
                        fil.Name);

                    sqlFilList.Filters.Add(filobject);
                }
            }

            //Serialize into json format output (string)
            string json = JsonConvert.SerializeObject(sqlFilList, Formatting.Indented);


            //codes to pass back the json string to the iPad
            Response.Write(json);
            Response.End();
        }
    }
}