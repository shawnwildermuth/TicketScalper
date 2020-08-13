using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TicketScalper.Core.Extensions
{
  public static class HostExtensions
  {
    public static IHost Seed<T>(this IHost host, Action<T> options = null) where T : DbContext
    {
      var config = host.Services.GetService<IConfiguration>();

      var bldr = new DbContextOptionsBuilder();
      bldr.UseSqlServer(config.GetConnectionString("DbServer"));

      T context = (T) Activator.CreateInstance(typeof(T), bldr.Options);
      context.Database.EnsureCreated();

      options?.Invoke(context);

      return host;
    }
  }
}
