using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Threading.Tasks;
using TicketScalper.ShowsAPI.Data;
using TicketScalper.ShowsAPI.Tests;
using Xunit;

namespace TicketScalper.ShowsAPI.UnitTests
{
  public class ShowsRepositoryTests
  {
    private ShowRepository _repo;

    public ShowsRepositoryTests()
    {
      _repo = new ShowRepository(TestDbUtilities<ShowContext>.BuildInMemoryContext());
    }

    [Fact]
    public async Task RepositoryShouldReturnShows()
    {
      var shows = await _repo.GetLatestShowsAsync();

      Assert.NotNull(shows);
      Assert.NotEmpty(shows);
      Assert.Contains(shows, a => a.Id == 1);
      Assert.Contains(shows, a => a.Id == 2);
      Assert.Contains(shows, a => a.Id == 3);
    }

    [Fact]
    public async Task RepositoryShouldReturnShow()
    {
      var show = await _repo.GetShowAsync(1);

      Assert.NotNull(show);
      Assert.Contains("Styx", show.Name);
    }


    [Fact]
    public async Task RepositoryShouldReturnTickets()
    {
      var tickets = await _repo.GetTicketsForShowAsync(1); 

      Assert.NotNull(tickets);
      Assert.NotEmpty(tickets);
      Assert.Contains(tickets, a => a.Id == 1);
      Assert.Contains(tickets, a => a.Id == 2);
      Assert.Contains(tickets, a => a.Id == 3);
    }

    [Fact]
    public async Task RepositoryNotShouldReturnTickets()
    {
      var tickets = await _repo.GetTicketsForShowAsync(3);

      Assert.NotNull(tickets);
      Assert.Empty(tickets);
    }

    [Fact]
    public async Task ShowShouldHaveArtists()
    {
      var show = await _repo.GetShowAsync(1);

      Assert.NotNull(show);
      Assert.NotEmpty(show.ActShows);
    }

    [Fact]
    public async Task ShowShouldHaveVenue()
    {
      var show = await _repo.GetShowAsync(1);

      Assert.NotNull(show);
      Assert.NotNull(show.Venue);
      Assert.Contains("Variety", show.Venue.Name);
    }

    [Fact]
    public async Task ShowShouldHaveVenueAddress()
    {
      var show = await _repo.GetShowAsync(1);

      Assert.NotNull(show);
      Assert.NotNull(show.Venue);
      Assert.NotNull(show.Venue.Address);
      Assert.Contains("Atlanta", show.Venue.Address.CityTown);
    }

    [Fact]
    public async Task ShowShouldBeSoldOut()
    {
      var show = await _repo.GetShowAsync(3);

      Assert.NotNull(show);
      Assert.Empty(show.Tickets);
    }

  }
}
