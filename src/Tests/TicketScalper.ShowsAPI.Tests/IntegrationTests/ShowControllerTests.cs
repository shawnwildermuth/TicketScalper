using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.ShowsAPI.Controllers;
using TicketScalper.ShowsAPI.Data;
using TicketScalper.ShowsAPI.Data.Maps;
using TicketScalper.ShowsAPI.Models;
using Xunit;

namespace TicketScalper.ShowsAPI.Tests.IntegrationTests
{
  public class ShowControllerTests
  {
    private ShowsController _controller;

    public ShowControllerTests()
    {
      var ctx = DbUtilities.BuildInMemoryContext();
      var repo = new ShowRepository(ctx);

      var configuration = new MapperConfiguration(cfg => cfg.AddProfile<ShowMaps>());
      var mapper = new Mapper(configuration);

      _controller = new ShowsController(repo, mapper);
    }

    [Fact]
    public async Task ControllerShouldReturnLatest()
    {
      var result = await _controller.GetLatest();
      var latest = result.Value;

      Assert.NotNull(latest);
      Assert.NotEmpty(latest);
      Assert.IsType<ShowModel>(latest.First());
      foreach (var item in latest)
      {
        Assert.True(item.StartDate >= DateTime.Today);
      }
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public async Task ControllerShouldSucceed(int id)
    {
      var result = await _controller.Get(id);
      var latest = result.Value;

      Assert.NotNull(latest);
      Assert.IsType<ShowModel>(latest);
      Assert.Equal(latest.Id, id);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async Task ControllerShouldReturnTickets(int id)
    {
      var tickets = (await _controller.GetTickets(id)).Value;

      Assert.NotNull(tickets);
      Assert.NotEmpty(tickets);
      foreach (var item in tickets)
      {
        Assert.True(item.CurrentPrice > 0);
      }
    }

    [Fact]
    public async Task ControllerShouldNotReturnTickets()
    {
      var result = await _controller.GetTickets(3);
      var tickets = result.Value;

      Assert.Null(tickets);
      Assert.IsAssignableFrom<NotFoundResult>(result.Result);
    }
  }
}
