using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.SalesAPI.Controllers;
using TicketScalper.SalesAPI.Data;
using TicketScalper.SalesAPI.Data.Entities;
using TicketScalper.SalesAPI.Models;
using TicketScalper.ShowsAPI.Tests;
using Xunit;

namespace TicketScaler.SalesAPI.Tests.IntegrationTests
{
  public class CustomerControllerTests
  {
    private readonly CustomersController _controller;

    public CustomerControllerTests()
    {
      var ctx = TestDbUtilities<SalesContext>.BuildInMemoryContext();
      var repo = new SalesRepository(ctx);

      var configuration = new MapperConfiguration(cfg => cfg.AddProfile<SalesMaps>());
      var mapper = new Mapper(configuration);

      var serviceProvider = new ServiceCollection()
        .AddLogging()
        .BuildServiceProvider();

      var factory = serviceProvider.GetService<ILoggerFactory>();

      var logger = factory.CreateLogger<CustomersController>();

      _controller = new CustomersController(logger, mapper, repo);
    }

    [Fact]
    public async Task ControllerReturnsCustomers()
    {
      var result = await _controller.GetCustomersAsync();
      var customers = result.Value;

      Assert.NotNull(customers);
      Assert.NotEmpty(customers);
      Assert.IsType<CustomerModel[]>(customers);
    }

    [Fact]
    public async Task ControllerCreatesCustomers()
    {
      var model = new CustomerModel()
      {
        FirstName = "Bob",
        LastName = "Smith",
        CompanyName = "Foo, Inc."
      };

      var result = await _controller.PostAsync(model);

      Assert.IsType<CreatedAtRouteResult>(result.Result);
      var objectResult = (ObjectResult)result.Result;

      var customer = (CustomerModel)objectResult.Value;

      Assert.NotNull(customer);
      Assert.Contains(model.FirstName, customer.FirstName);
      Assert.NotEqual(model.Id, customer.Id);

      result = await _controller.GetCustomerAsync(customer.Id);
      var got = result.Value;

      Assert.NotNull(got);
    }

    [Fact]
    public async Task ControllerUpdatesCustomer()
    {
      var result = await _controller.GetCustomerAsync(1);
      var customer = result.Value;

      Assert.NotNull(customer);

      customer.AddressLine3 = "Suite 500";

      var updateResult = await _controller.Put(customer.Id, customer);
      Assert.IsType<OkObjectResult>(updateResult.Result);
      var objectResult = (ObjectResult)updateResult.Result;

      var updated = (CustomerModel)objectResult.Value;
      Assert.Equal(customer.AddressLine3, updated.AddressLine3);

    }

    [Fact]
    public async Task ControllerCantDeletesCustomerWithSales()
    {
      var deleteResult = await _controller.Delete(1);
      Assert.IsType<BadRequestObjectResult>(deleteResult);
    }

    [Fact]
    public async Task ControllerDeletesCustomer()
    {
      var model = new CustomerModel()
      {
        FirstName = "Bob",
        LastName = "Smith",
        CompanyName = "Foo, Inc."
      };

      var result = await _controller.PostAsync(model);

      Assert.IsType<CreatedAtRouteResult>(result.Result);
      var objectResult = (ObjectResult)result.Result;

      var customer = (CustomerModel)objectResult.Value;

      var deleteResult = await _controller.Delete(customer.Id);
      Assert.IsType<OkResult>(deleteResult);
    }

  }
}
