using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.ViewModels.Employee
{
    public class EmployeeSalaryVm
    {
        [Required(ErrorMessage = "The 'First Name' field is required")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The 'Last Name' field is required")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [MaxLength(300)]
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Currency)]
        public double CommissionRate { get; set; }
        [DataType(DataType.Currency)]
        public double GrossSales { get; set; }
        [DataType(DataType.Currency)]
        public double BasicSalary { get; set; }
    }
}
