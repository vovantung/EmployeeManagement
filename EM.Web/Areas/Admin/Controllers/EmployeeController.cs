using EM.Services;
using EM.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EM.Web.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
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
            if(employee == null)
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
            if(salary != null)
            {
                salaryDetailVm.BasicSalary = salary.BasicSalary;
                salaryDetailVm.CommissionRate = salary.CommissionRate;
                salaryDetailVm.GrossSales = salary.GrossSales;
            }
            return View(salaryDetailVm);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult Create(EmployeeSalaryVm employeeSalaryVm)
        {
            if (ModelState.IsValid)
            {
                EmployeeCreateRequest employeeCreateRequest = new EmployeeCreateRequest()
                {
                    LastName = employeeSalaryVm.LastName,
                    FirstName = employeeSalaryVm.FirstName,
                    Address = employeeSalaryVm.Address,
                    PhoneNumber = employeeSalaryVm.PhoneNumber,
                    BasicSalary = employeeSalaryVm.BasicSalary,
                    CommissionRate = employeeSalaryVm.CommissionRate,
                    GrossSales = employeeSalaryVm.GrossSales
                };
                var result = employeeService.Add(employeeCreateRequest);
                if(result <= 0)
                {
                    ModelState.AddModelError("", "Add employee is failed!");
                    return View(employeeSalaryVm);
                }
            }
            else
            {
                return View(employeeSalaryVm);
            }
            return RedirectToAction("Index");
        }
        public JsonResult Delete(int employeeId)
        {
            var result =  employeeService.Delete(employeeId);
            if(result == 0)
            {
               return Json(new { result = false });
            }
            return Json(new { result = true });
        }
        [HttpGet]
        public ActionResult Update(int employeeId)
        {
            var employee = employeeService.GetById(employeeId);
            if (employee != null)
            {
                EmployeeUpdateRequest blogUpdate = new EmployeeUpdateRequest()
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    PhoneNumber = employee.PhoneNumber,
                    Address = employee.Address
                };
                return View(blogUpdate);
            }
            return View();

        }
        [HttpPost]
        public ActionResult Update(EmployeeUpdateRequest request)
        {
            var result = employeeService.Update(request);
            if(result == 0)
            {
                ModelState.AddModelError("", "Update failed!");
                return View();
            }
           
            return RedirectToAction("Index");
        }
    }
}