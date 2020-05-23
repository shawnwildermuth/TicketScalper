using System.Collections.Generic;
using System.Threading.Tasks;
using TicketScalper.core.Data;
using TicketScalper.ShowsAPI.Data.Entities;

namespace TicketScalper.ShowsAPI.Data
{
  public interface IShowRepository : IRepository
  {
    Task<IEnumerable<Show>> GetLatestShowsAsync();
    Task<IEnumerable<Ticket>> GetTicketsAsync(int showId);
    Task<Show> GetShowAsync(int id);
  }
}