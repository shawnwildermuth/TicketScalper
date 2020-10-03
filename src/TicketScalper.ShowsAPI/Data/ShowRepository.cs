using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.Core.Data;
using TicketScalper.ShowsAPI.Data.Entities;

namespace TicketScalper.ShowsAPI.Data
{
  /// <summary>
  /// The Repository for the Show API
  /// </summary>
  public class ShowRepository : BaseRepository<ShowContext>, IShowRepository
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ShowRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public ShowRepository(ShowContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets the latest shows asynchronous.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Show>> GetLatestShowsAsync() => await Context.Shows
        .Include(s => s.Venue)
        .Include(s => s.ActShows)
        .ThenInclude(s => s.Act)
        .Include(s => s.Tickets)
        .Where(s => s.StartDate >= DateTime.Today)
        .ToArrayAsync();

    /// <summary>
    /// Gets the show asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public async Task<Show> GetShowAsync(int id) => await Context.Shows
        .Include(s => s.Venue)
        .Include(s => s.ActShows)
        .ThenInclude(s => s.Act)
        .Include(s => s.Tickets)
        .Where(s => s.Id == id)
        .FirstOrDefaultAsync();

    /// <summary>
    /// Gets the tickets for show asynchronous.
    /// </summary>
    /// <param name="showId">The show identifier.</param>
    /// <returns></returns>
    public async Task<IEnumerable<Ticket>> GetTicketsForShowAsync(int showId) => await Context.Tickets
      .Where(t => t.Show.Id == showId)
      .ToArrayAsync();

    /// <summary>
    /// Gets the tickets asynchronous.
    /// </summary>
    /// <param name="ticketIds">The ticket ids.</param>
    /// <returns></returns>
    public async Task<IEnumerable<Ticket>> GetTicketsAsync(int[] ticketIds) => await Context.Tickets
      .Include(t => t.Show)
      .ThenInclude(t => t.ActShows)
      .ThenInclude(t => t.Act)
      .Include(t => t.Show)
      .ThenInclude(t => t.Venue)
      .ThenInclude(t => t.Address)
      .Where(t => ticketIds.Contains(t.Id))
      .ToArrayAsync();

  }
}
