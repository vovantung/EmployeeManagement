using EM.Data.EF;
using EM.Data.Entities;
using EM.Ultilities;
using EM.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Services
{
    public class EmployeeService : IEmployeeService
    {
        EMDbContext dbContext;
        public EmployeeService(EMDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(EmployeeCreateRequest request)
        {
            Salary salary = new Salary()
            {
                GrossSales = request.GrossSales,
                CommissionRate = request.CommissionRate,
                BasicSalary = request.BasicSalary,
            };
            var employee = new List<Employee>()
            {
                new Employee()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    BirthDate = request.BirthDate,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    Email = request.Email,
                }
            };
            salary.Employees = employee;
            try
            {
                dbContext.Salaries.Add(salary);
                dbContext.SaveChanges();
                return employee.FirstOrDefault().Id;
            }catch(EMException ex)
            {
                return 0;
            }
        }

        public int Delete(int employeeId)
        {
            var employee = dbContext.Employees.Find(employeeId);
            if(employee == null)
            {
                return 0;
            }
            try
            {
                dbContext.Employees.Remove(employee);
                dbContext.SaveChanges();
                return employeeId;
            }catch(EMException ex)
            {
                return 0;
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                return dbContext.Employees.ToList();
            }catch(EMException ex)
            {
                return null;
            }
        }

        public IEnumerable<Employee> GetAllPageding(EmployeePagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Salary GetByEmployeeId(int employeeId)
        {
            var employee = dbContext.Employees.Find(employeeId);
            if(employee == null)
            {
                return null;
            }
            var salary = dbContext.Salaries.Find(employee.SalaryId);
            if(salary == null)
            {
                return null;
            }
            return salary;
        }

        public Employee GetById(int employeeId)
        {
            var employee = dbContext.Employees.Find(employeeId);
            if(employee == null)
            {
                return null;
            }
            return employee;
        }

        public int Update(EmployeeUpdateRequest request)
        {
            var employee = dbContext.Employees.Find(request.Id);
            if(employee == null)
            {
                return 0;
            }
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.PhoneNumber = request.PhoneNumber;
            employee.Address = request.Address;
            try
            {
                dbContext.SaveChanges();
            }catch(EMException ex)
            {
                return 0;
            }
            return request.Id;
        }
    }
}
