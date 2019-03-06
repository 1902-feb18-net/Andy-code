using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // in VS we have "IIS Express" Web Server (crucial for HTTP lifecycle)
            // is a server that knows how to take http requests and send back a response
            // we servers are software that listen on ports
            // for data sent over internet, especially HTTP
            // our app runs inside/alongside that web server
            // technically we have another web server inside that is a container directly for this 
            // application called Kestrel (cross platform)
            CreateWebHostBuilder(args).Build().Run();
        }

        // creates a webhost that has a startup, what matters is the Startup
        // ASP.NET creates a webhost and runs it, using configs given by a startup class
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
