using EM.Services;
using EM.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Web.Controllers
{
    public class HomeController : Controller
    {
        IEmployeeService employeeService;
        public HomeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        // GET: Employee
        public ActionResult Index()
        {
            var employees = employeeService.GetAll();
            if (employees == null)
            {
                return View();
            }
            return View(employees);
        }

        public ActionResult SalaryDetail(int employeeId)
        {
            var employee = employeeService.GetById(employeeId);
            if (employee == null)
            {
                ModelState.AddModelError("", "Not found Employee");
                return View();
            }
            var salary = employeeService.GetByEmployeeId(employeeId);
            SalaryDetailVm salaryDetailVm = new SalaryDetailVm()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber
            };
            if (salary != null)
            {
                salaryDetailVm.BasicSalary = salary.BasicSalary;
                salaryDetailVm.CommissionRate = salary.CommissionRate;
                salaryDetailVm.GrossSales = salary.GrossSales;
            }
            return View(salaryDetailVm);
        }
    }
}