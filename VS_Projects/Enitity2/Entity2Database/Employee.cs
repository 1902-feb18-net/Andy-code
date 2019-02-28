using System;
using System.Collections.Generic;

namespace Entity2Database
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Ssn { get; set; }
        public int DeptId { get; set; }
    }
}
