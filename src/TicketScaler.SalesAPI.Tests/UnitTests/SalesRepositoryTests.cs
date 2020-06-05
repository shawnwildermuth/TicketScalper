using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.SalesAPI.Data;
using TicketScalper.ShowsAPI.Tests;
using Xunit;

namespace TicketScaler.SalesAPI.Tests.UnitTests
{
  public class SalesRepositoryTests
  {
    private SalesRepository _repository;

    public SalesRepositoryTests()
    {
      _repository = new SalesRepository(DbUtilities.BuildInMemoryContext());
    }

    [Fact]
    public async Task ShouldReturnCustomers()
    {
      var results = await _repository.GetCustomersAsync();

      Assert.NotNull(results);
      Assert.NotEmpty(results);
      Assert.Contains(results, a => a.Id == 1);

    }

    [Theory]
    [InlineData(1)]
    public async Task ShouldReturnCustomer(int id)
    {
      var results = await _repository.GetCustomerAsync(id);

      Assert.NotNull(results);
      Assert.True(results.Id == 1);
      Assert.NotEmpty(results.FirstName);
      Assert.NotEmpty(results.LastName);
      Assert.Null(results.Sales);

    }

    [Theory]
    [InlineData(1)]
    public async Task ShouldReturnSales(int id)
    {
      var sales = await _repository.GetSalesAsync(id);

      Assert.NotNull(sales);
      Assert.NotEmpty(sales);
      Assert.Contains(sales, t => t.CustomerId == id);
      Assert.All(sales, t => Assert.NotEmpty(t.TransactionNumber));
    }

    [Fact]
    public async Task SaleShouldHasTickets()
    {
      var sales = await _repository.GetSalesAsync(1);

      Assert.NotEmpty(sales);
      Assert.True(sales.Count() == 1);
      var sale = sales[0];
      Assert.NotNull(sale.Tickets);
      Assert.True(sale.Tickets.Count() > 0);
    }

  }
}
