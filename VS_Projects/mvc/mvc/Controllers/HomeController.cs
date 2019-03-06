using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        // each method in controller is going to be called an action method
        // handles the response that happens on the page
        public IActionResult Index()
        {
            // mpw we lmpw tp print/read data
            // we could access some userRepo here
            // which accesses some dbcontext
            var user = new User {
                Username = "Fred",
                Address = new List<Address>
                {
                    new Address {street ="123 main st", city ="san jose, CA"},
                    new Address {street ="321 bla st", city ="san Fransokyo, CA"}
                }
            };
            // looks for a View with the name of the current method
            
            return View(user);
        }

        [HttpPost] //this method receives post not get 
        public IActionResult IndexWithUser(User user)
        {
            // we're going to receive form data and "model binding" will
            // occur to this "user" object.
            return View("Index", user);
        }

        public IActionResult IndexWithId(int id)
        {
            var user = new User { Username = $"BenTo #{id}" };
            // this does not work
            //return View(User);
            // this wont work, requires non-null val
            //return View("Index");
            return View("Index", user);
            // here's how i test this
            // https://localhost:44358/Home/IndexWithId?Id=12312
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
