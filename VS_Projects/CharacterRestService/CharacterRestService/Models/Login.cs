using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterRestService.Models
{
    public class Login
    {
        string Username { get; set; }
        string Password { get; set; }
        bool RememberMe { get; set; }
    }
}
