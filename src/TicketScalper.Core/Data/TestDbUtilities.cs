using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.ShowsAPI.Tests
{
    public static class TestDbUtilities<TContext> where TContext : DbContext
    {
      public static TContext BuildInMemoryContext()
      {
        // Build an options for In Memory
        var builder = new DbContextOptionsBuilder<TContext>();
        builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        // Build the In-Memory Db
        var context = (TContext)Activator.CreateInstance(typeof(TContext), builder.Options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

      return context;
    }
  }
}
