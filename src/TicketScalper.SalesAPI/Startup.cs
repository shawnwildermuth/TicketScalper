using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TicketScalper.Core.Extensions;
using TicketScalper.Core.Tokens;
using TicketScalper.SalesAPI.Data;
using TicketScalper.SalesAPI.Services;

namespace TicketScalper.SalesAPI
{
  public class Startup
  {
    private IConfiguration _config;
    private readonly IWebHostEnvironment _env;

    public Startup(IConfiguration config, IWebHostEnvironment env)
    {
      _config = config;
      _env = env;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<SalesContext>(cfg => cfg.UseSqlServer(_config.GetConnectionString("SalesDb")));
      services.AddScoped<ISalesRepository, SalesRepository>();

      services.AddControllers();
      services.AddAutoMapper(Assembly.GetEntryAssembly());

      services.AddTicketScalperAuthentication();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "SalesAPI", Version = "v1" });
        if (_env.IsProduction())
        {
          var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
          var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
          c.IncludeXmlComments(xmlPath);
        }
      });

      services.AddScoped<ITicketService, TicketService>();
      services.AddScoped<ITicketChannelProvider, TicketChannelProvider>();

      services.AddApiVersioning(cfg =>
      {
        cfg.ReportApiVersions = true;
        cfg.DefaultApiVersion = new ApiVersion(1, 0);
        cfg.AssumeDefaultVersionWhenUnspecified = true;
        cfg.ApiVersionReader = new HeaderApiVersionReader("X-Version");
      });

      services.AddTicketScalperCorsPolicy();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
      if (_env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }


      app.UseHttpsRedirection();

      app.UseSwagger();
      app.UseSwaggerUI(cfg =>
      {
        cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "SalesAPI");
        cfg.RoutePrefix = "docs";
      });

      app.UseRouting();

      app.UseCors();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
