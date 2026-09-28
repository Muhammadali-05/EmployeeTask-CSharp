using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTaskCSharp.Models
{
    public class Userr
    {
        public byte UserId { get; set; }
        public byte EmployeeId { get; set; }
        public string Login { get; set; } = string.Empty;
        public DateTime? LastLoginDate { get; set; }
        public bool IsActive {get; set; }
    }
}
