using System.Collections.Generic;

namespace EmployeeManager.Models
{
    public class SectionDetail : Section
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}