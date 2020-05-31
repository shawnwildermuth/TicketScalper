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
  public class ShowRepository : BaseRepository<ShowContext>, IShowRepository
  {
    public ShowRepository(ShowContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Show>> GetLatestShowsAsync() => await Context.Shows
        .Include(s => s.Venue)
        .Include(s => s.ActShows)
        .ThenInclude(s => s.Act)
        .Include(s => s.Tickets)
        .Where(s => s.StartDate >= DateTime.Today)
        .ToArrayAsync();

    public async Task<Show> GetShowAsync(int id) => await Context.Shows
        .Include(s => s.Venue)
        .Include(s => s.ActShows)
        .ThenInclude(s => s.Act)
        .Include(s => s.Tickets)
        .Where(s => s.Id == id)
        .FirstOrDefaultAsync();

    public async Task<IEnumerable<Ticket>> GetTicketsForShowAsync(int showId) => await Context.Tickets
      .Where(t => t.Show.Id == showId)
      .ToArrayAsync();

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
