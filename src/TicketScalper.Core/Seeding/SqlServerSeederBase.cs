using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TicketScalper.Core.Seeding
{
  public abstract class SqlServerSeederBase<T> : ISeeder where T : DbContext
  {
    protected readonly T Context;

    public SqlServerSeederBase(T context) 
    {
      if (!context.Database.IsSqlServer())
      {
        throw new InvalidOperationException("SqlServerSeederBase requires a DbContext for SQL Server.");
      }
      Context = context;
    }

    protected virtual async Task<bool> CanSeed()
    {
      if (await Context.Database.CanConnectAsync())
      {
        var pendingMigrations = await Context.Database.GetPendingMigrationsAsync();
        if (!pendingMigrations.Any()) return true;
      }
      return false;
    }

    public abstract Task Seed();

  }
}