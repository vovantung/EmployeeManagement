using EM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Data.EF
{
    public class EMDbContext :DbContext
    {
        public EMDbContext() : base("EMConnectionString")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }
    }
}
