using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
using TicketScalper.ShowsAPI.Services;
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
      ticketServiceMock.Setup(s => s.ReserveTickets(It.IsAny<int[]>())).ReturnsAsync(() =>
      {
        return true;
      });
      ticketServiceMock.Setup(s => s.FinalizeTickets(It.IsAny<int[]>())).ReturnsAsync(() =>
      {
        var result = new FinalizedTicketResponse()
        {
          Success = true,
          Tickets = new TicketInfo[]
          {
            new TicketInfo()
            {
              Price = 49.99m
            },
            new TicketInfo()
            {
              Price = 49.99m
            },
            new TicketInfo()
            {
              Price = 49.99m
            },
            new TicketInfo()
            {
              Price = 49.99m
            },
          }
        };
        return result;
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

    [Fact]
    public async Task ShouldReturnSale()
    {
      var result = await _controller.Get(1,1);
      var sale = result.Value;

      Assert.NotNull(sale);
    }

    [Fact]
    public async Task CreatesSales()
    {
      var model = new TicketRequestModel()
      {
        CreditCard = "12345",
        ValidationCode = "1234",
        ExpirationMonth = 4,
        ExpirationYear = 2024,
        TicketIds = new int[] { 1, 2, 3, 4 }
      };

      var result = await _controller.Post(1, model);

      Assert.IsType<CreatedAtRouteResult>(result.Result);
      var objectResult = (ObjectResult)result.Result;

      var sale = (TicketSaleModel)objectResult.Value;

      Assert.NotNull(sale);
      Assert.NotEmpty(sale.Tickets);
      Assert.True(sale.Tickets.Count() == 4);
      Assert.True(sale.Tickets.Sum(t => t.Price) == sale.TransactionTotal);

    }
  }
}
