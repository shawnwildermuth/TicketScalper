using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.ShowsAPI.Data;

namespace TicketScalper.ShowsAPI.Tests
{
    public static class DbUtilities
    {
      public static ShowContext BuildInMemoryContext()
      {
        // Build an options for In Memory
        var builder = new DbContextOptionsBuilder<ShowContext>();
        builder.UseInMemoryDatabase("ShowDb");

        // Build the In-Memory Db
        var context = new ShowContext(builder.Options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

      return context;
    }
  }
}
