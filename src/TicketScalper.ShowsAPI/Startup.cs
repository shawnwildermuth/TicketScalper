using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TicketScalper.Core.Seeding;
using TicketScalper.ShowsAPI.Data;

namespace TicketScalper.ShowsAPI
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      _config = configuration;
    }

    private IConfiguration _config;

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ShowContext>();
      services.AddTransient<ISeeder, ShowSeeder>();

      services.AddControllers();
      services.AddAutoMapper(Assembly.GetEntryAssembly());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeeder seeder)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        seeder.Seed().Wait();
      }
      else 
      { 
        app.UseHttpsRedirection();
      }
 
      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
