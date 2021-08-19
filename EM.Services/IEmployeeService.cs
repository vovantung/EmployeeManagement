using EM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.ViewModels.Employee;

namespace EM.Services
{
    public interface IEmployeeService
    {
        int Add(EmployeeCreateRequest request);
        int Update(EmployeeUpdateRequest request);
        int Delete(int employeeId);
        Employee GetById(int employeeId);
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> GetAllPageding(EmployeePagingRequest request);
        Salary GetByEmployeeId(int employeeId);
    }
}
