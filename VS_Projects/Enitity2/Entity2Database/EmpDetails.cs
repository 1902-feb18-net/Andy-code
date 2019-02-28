using System;
using System.Collections.Generic;

namespace Entity2Database
{
    public partial class EmpDetails
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int? Salary { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
