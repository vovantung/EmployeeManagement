using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.ViewModels.Employee
{
    public class EmployeePagingRequest
    {
        public int PagedIndex { get; set; }
        public int PageSize { get; set; }
        public string KeyWordFindName { get; set; }
    }
}
