using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TicketScalper.Core.Data
{
  public class BaseRepository<TContext> : IRepository where TContext : DbContext
  {
    public BaseRepository(TContext context)
    {
      Context = context;
    }

    protected TContext Context { get; }

    public void Add<T>(T entity)
    {
      Context.Add(entity);
    }

    public void Delete<T>(T entity)
    {
      Context.Remove(entity);
    }

    public async Task<bool> SaveAllAsync()
    {
      if (Context.ChangeTracker.HasChanges())
      {
        return await Context.SaveChangesAsync() > 0;
      }
      else 
      {
        return true;
      }
    }
  }
}