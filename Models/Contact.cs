using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTaskCSharp.Models
{
    public  class Contact
    {
        public byte ContactId { get; set; }
        public byte EmployeeId { get; set; }
        public string ContactType { get; set; } = string.Empty;
        public string ContactValue { get; set; } = string.Empty;
    }
}
