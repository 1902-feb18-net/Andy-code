using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class User
    {
        public string Username { get; set; }
        public IEnumerable<Address> Address { get; set; } = new List<Address>();
    }
}
