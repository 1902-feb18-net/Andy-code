using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CharacterRestDAL;
using CharacterRestService.Models;

namespace CharacterRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(SignInManager<IdentityUser> signInManager, AuthDbContext dbContext)
        {
            // we can do code-first skipping migration at runtime
            // downside is we cant run migrations on the db that 
            // gets generated later
            //dbContext.Database.EnsureCreated();
            //SignInManager = signInManager
            // k i give up on adding in code, will pay attention

            // make a login task, then make a logout task, and finally a register
            //[HttpPost]
            //public async Task<IActionResult> Login(Login login){}

            // POST /account
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register register, 
            [FromServices] UserManager<IdentityUser> userManager)
        {
            var user = new IdentityUser(register.Username);
            var result = await userManager.CreateAsync(user, register.Password);

            // check if succeed
            // yada yada something here

            return NoContent();
        }
    }
}