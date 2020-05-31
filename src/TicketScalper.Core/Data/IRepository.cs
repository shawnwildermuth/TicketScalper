using System.Threading.Tasks;

namespace TicketScalper.Core.Data
{
  public interface IRepository
  {
    void Add<T>(T entity);
    void Delete<T>(T entity);
    Task<bool> SaveAllAsync();
  }
}