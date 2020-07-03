using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using TicketScalper.Core.Extensions;

namespace TicketScalper.Gateway
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((ctx, cfg) =>
        {
          cfg.SetBasePath(ctx.HostingEnvironment.ContentRootPath)
              .AddJsonFile("appsettings.json")
              .AddJsonFile("appsettings.Development.json", true)
              .AddJsonFile("ocelot.json", false, true)
              .AddJsonFile("ocelot.development.json", true, true)
              .AddEnvironmentVariables();

        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.ConfigureServices(cfg =>
          {
            cfg.AddTicketScalperCorsPolicy();
            cfg.AddOcelot();
          });
          webBuilder.Configure(async cfg =>
          {
            cfg.UseCors();
            await cfg.UseOcelot();
          });
        });
  }
}
