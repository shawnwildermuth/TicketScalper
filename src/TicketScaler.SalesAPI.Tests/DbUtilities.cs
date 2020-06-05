using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.SalesAPI.Data;

namespace TicketScalper.ShowsAPI.Tests
{
    public static class DbUtilities
    {
      public static SalesContext BuildInMemoryContext()
      {
        // Build an options for In Memory
        var builder = new DbContextOptionsBuilder<SalesContext>();
        builder.UseInMemoryDatabase("SalesDb");

        // Build the In-Memory Db
        var context = new SalesContext(builder.Options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

      return context;
    }
  }
}
