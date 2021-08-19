using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Data.Entities
{
    [Table("Salaries")]
    public class Salary
    {
        //public double CommissionRate { set; get; }
        //public double GrossSales { set; get; }
        //public double BasicSalary { set; get; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double CommissionRate { get; set; }
        public double GrossSales { get; set; }
        public double BasicSalary { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
