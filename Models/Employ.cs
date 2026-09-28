using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTaskCSharp.Models
{
    public class Employ

    {
        public byte EmployeeId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string DepartmentName {  get; set; } = string.Empty;
        public DateTime HireDate {  get; set; }
    }
}
