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
using Swashbuckle.AspNetCore.SwaggerGen;
using TicketScalper.ShowsAPI.Data;
using TicketScalper.ShowsAPI.Services;

namespace TicketScalper.ShowsAPI
{
  public class Startup
  {
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
      _config = configuration;
      _env = env;
    }

    private IConfiguration _config;
    private readonly IWebHostEnvironment _env;

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ShowContext>(cfg => cfg.UseSqlServer(_config.GetConnectionString("ShowDb")));
      services.AddScoped<IShowRepository, ShowRepository>();

      services.AddControllers();
      services.AddAutoMapper(Assembly.GetEntryAssembly());

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShowsAPI", Version = "v1" });
        if (_env.IsProduction())
        {
          var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
          var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
          c.IncludeXmlComments(xmlPath);
        }
      });

      services.AddGrpc(cfg => cfg.EnableDetailedErrors = true);

      services.AddApiVersioning(cfg =>
      {
        cfg.ReportApiVersions = true;
        cfg.DefaultApiVersion = new ApiVersion(1, 0);
        cfg.AssumeDefaultVersionWhenUnspecified = true;
        cfg.ApiVersionReader = new HeaderApiVersionReader("X-Version");
      });
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
        cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "ShowsAPI");
        cfg.RoutePrefix = "docs";
      });

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapGrpcService<TicketService>();
      });
    }
  }
}
