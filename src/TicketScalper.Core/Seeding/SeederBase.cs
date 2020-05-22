using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace TicketScalper.Core.Seeding
{
  public abstract class SeederBase<T> : ISeeder where T : DbContext
  {
    protected readonly T Context;

    public SeederBase(T context) 
    {
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