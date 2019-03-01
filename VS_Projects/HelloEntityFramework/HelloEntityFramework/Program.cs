using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace HelloEntityFramework
{
    class Program
    {
        // EF DB first approach steps
        //
        // 1. have startup project and data access library project
        // 2. reference data access from startup project
        // 3. add NuGet packages to startup project
        //  - Microsoft.EntityFrameworkCore.Tools
        //  - Microsoft.EntityFrameworkCore.SqlServer
        //  and to the data access project
        //  - Microsoft.EntityFrameworkCore.SqlServer
        // 4. Open package manager Console in VS
        //  (view -> other windows -> package manager console)
        //  (alternate 4/5. run in git bash)
        //      dotnet ef dbcontext scaffolf "<your connection string>"
        //          Microsoft.EntityFrameworkCore.SqlServer
        //              --project <name of data project>
        // 5. Run command
        //   Scaffold-DBContext "<your-connection-string>" Microsoft.EntityFrameworkCore.SqlServer -Project <name-of-data-project> -Force
        // 6. Delete the OnConfiguring ovverride in the DbContext, to prevent
        //      committing your connection string to git.

        // (7. any time we change the DB (add a new col etc...), go to step 4)

        // by default the scaffolding will configure the models in OnModelCreating
        //  with the fluent API, this is the right way to do it - strongest separation
        //  of concerns
        // if we scaffold with option "-DataAnnotations" (/"--data-annotations") we'll put the configs on the Movie
        // and Genre classes themselves with attributes
        // 3rd way to configure is convention based


        // logging with Microsoft.Extensions.Logging from NuGet
        // grab from training notes later
        public static readonly LoggerFactory AppLoggerFactory =
            new LoggerFactory(new[] (new ConsoleLoggerProvider(_, __) => true, true));
        static void Main(string[] args)
        {
            // note to self, i set my thing up wrong!!!
            // grab from his github repo later
            var optionBuilder = new DbContextOptionsBuilder<ChinookContext>();
            optionBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
            var options = DbContextOptionsBuilder.Options;

            using (var dbContext = new ChinookContext(options))
            {
                PrintChinook(dbContext);
            }

        }
        static void PrintChinook(ChinookContext dbContext)
        {
            foreach (var something in dbContext.Invoice)
            {
                Console.WriteLine($"Something ");
            }
        }
    }
}
