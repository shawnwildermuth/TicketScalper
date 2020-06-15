using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Linq;
using TicketScalperApp.Identity.Data;

namespace TicketScalper.AuthAPI
{
  public class Program
  {
    public static void Main(string[] args)
    {
      if (args.Count() == 1)
      {
        if (args[0] == "/seed")
        {
          Seeder.Seed().Wait();
          return;
        }
        else if (args[0] == "/drop")
        {
          Seeder.Drop().Wait();
          return;
        }
      }

      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
