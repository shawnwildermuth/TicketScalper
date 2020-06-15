using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BountyApp.Identity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TicketScalper.Core.Extensions;
using TicketScalper.Core.Identity;
using TicketScalper.Core.Tokens;

namespace TicketScalper.AuthAPI
{
  public class Startup
  {
    private readonly IConfiguration _config;

    public Startup(IConfiguration configuration)
    {
      _config = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<TicketScalperIdentityContext>(cfg =>
      {
        cfg.UseSqlServer(_config.GetConnectionString("AuthDb"));
      });

      services.AddIdentityCore<TicketScalperIdentityUser>()
          .AddEntityFrameworkStores<TicketScalperIdentityContext>();

      services.AddAuthentication()
              .AddTicketScalperBearerToken();


      services.AddTicketScalperCorsPolicy();

      services.AddScoped<TicketScalperTokenFactory>();

      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseCors();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
