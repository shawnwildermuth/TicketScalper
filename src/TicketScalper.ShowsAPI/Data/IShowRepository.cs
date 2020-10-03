using System.Collections.Generic;
using System.Threading.Tasks;
using TicketScalper.Core.Data;
using TicketScalper.ShowsAPI.Data.Entities;

namespace TicketScalper.ShowsAPI.Data
{
  /// <summary>
  /// THe interface for the Shows' Repository
  /// </summary>
  /// <seealso cref="TicketScalper.Core.Data.IRepository" />
  public interface IShowRepository : IRepository
  {
    /// <summary>
    /// Gets the latest shows asynchronous.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Show>> GetLatestShowsAsync();
    /// <summary>
    /// Gets the show asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<Show> GetShowAsync(int id);

    /// <summary>
    /// Gets the tickets for show asynchronous.
    /// </summary>
    /// <param name="showId">The show identifier.</param>
    /// <returns></returns>
    Task<IEnumerable<Ticket>> GetTicketsForShowAsync(int showId);
    /// <summary>
    /// Gets the tickets asynchronous.
    /// </summary>
    /// <param name="ticketIds">The ticket ids.</param>
    /// <returns></returns>
    Task<IEnumerable<Ticket>> GetTicketsAsync(int[] ticketIds);
  }
}