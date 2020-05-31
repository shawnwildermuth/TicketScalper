using System.Collections.Generic;
using System.Threading.Tasks;
using TicketScalper.Core.Data;
using TicketScalper.ShowsAPI.Data.Entities;

namespace TicketScalper.ShowsAPI.Data
{
  public interface IShowRepository : IRepository
  {
    Task<IEnumerable<Show>> GetLatestShowsAsync();
    Task<Show> GetShowAsync(int id);

    Task<IEnumerable<Ticket>> GetTicketsForShowAsync(int showId);
    Task<IEnumerable<Ticket>> GetTicketsAsync(int[] ticketIds);
  }
}