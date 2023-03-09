using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeAreas.Data
{
    public class EmployeeAreasContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EmployeeAreasContext() : base("name=EmployeeAreasContext")
        {
        }

        public System.Data.Entity.DbSet<EmployeeAreas.Areas.HR.Data.Employee> Employees { get; set; }
    }
}
