using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.SalesAPI.Controllers;
using TicketScalper.SalesAPI.Data;
using TicketScalper.SalesAPI.Data.Entities;
using TicketScalper.SalesAPI.Models;
using TicketScalper.SalesAPI.Services;
using TicketScalper.ShowsAPI.Tests;
using Xunit;

namespace TicketScaler.SalesAPI.Tests.IntegrationTests
{
    public class SalesControllerTests
    {
    private SalesController _controller;

    public SalesControllerTests()
    {
      var ctx = TestDbUtilities<SalesContext>.BuildInMemoryContext();
      var repo = new SalesRepository(ctx);

      var configuration = new MapperConfiguration(cfg => cfg.AddProfile<SalesMaps>());
      var mapper = new Mapper(configuration);

      var serviceProvider = new ServiceCollection()
        .AddLogging()
        .BuildServiceProvider();

      var factory = serviceProvider.GetService<ILoggerFactory>();

      var logger = factory.CreateLogger<SalesController>();

      var ticketServiceMock = new Mock<ITicketService>();
      ticketServiceMock.Setup(s => s.ReserveTickets(new int[0])).Returns(() => Task.FromResult(true));
      ticketServiceMock.Setup(s => s.FinalizeTickets(new int[0])).Returns(() =>
      {
        var result = new FinalizedTicketResponse()
        {
          Success = true,
          Tickets = new TicketInfo[]
          {
            new TicketInfo()
            {
              Id = 1
            }
          }
        };
        return Task.FromResult(result);
      });


      _controller = new SalesController(logger, mapper, repo, ticketServiceMock.Object);
    }


    [Fact]
    public async Task ShouldReturnSales()
    {
      var result = await _controller.Get(1);
      var sales = result.Value;

      Assert.NotNull(sales);
      Assert.NotEmpty(sales);
    }
  }
}
