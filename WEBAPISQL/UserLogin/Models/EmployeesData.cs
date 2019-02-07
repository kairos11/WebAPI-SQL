using System;
using System.Collections.Generic;

namespace UserLogin.Models
{
    public partial class EmployeesData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int? Salary { get; set; }
    }
}
