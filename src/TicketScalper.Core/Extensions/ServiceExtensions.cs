using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace TicketScalper.Core.Extensions
{
  public static class ServiceExtensions
  {
    public static IServiceCollection AddTicketScalperCorsPolicy(this IServiceCollection coll)
    {
      return coll.AddCors(opt =>
      {
        opt.AddDefaultPolicy(cfg =>
        {
          // TODO configure better policy
          cfg.AllowAnyHeader();
          cfg.AllowAnyMethod();
          cfg.AllowAnyOrigin();
        });
      });
    }
  }
}
