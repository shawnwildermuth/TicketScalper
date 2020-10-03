using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.Core.Data;
using TicketScalper.SalesAPI.Data.Entities;

namespace TicketScalper.SalesAPI.Data
{
  /// <summary>
  /// Repository for Sales information
  /// </summary>
  public class SalesRepository : BaseRepository<SalesContext>, ISalesRepository
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="SalesRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public SalesRepository(SalesContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets the customer asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public Task<Customer> GetCustomerAsync(int id)
    {
      return Context.Customers
        .Where(c => c.Id == id)
        .FirstOrDefaultAsync();
    }

    /// <summary>
    /// Gets the customer by user asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public Task<Customer> GetCustomerByUserAsync(string id)
    {
      return Context.Customers
        .Where(c => c.UserName == id)
        .FirstOrDefaultAsync();
    }

    /// <summary>
    /// Gets the customers asynchronous.
    /// </summary>
    /// <returns></returns>
    public Task<Customer[]> GetCustomersAsync()
    {
      return Context.Customers.ToArrayAsync();
    }

    /// <summary>
    /// Gets the sale asynchronous.
    /// </summary>
    /// <param name="customerId">The customer identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public Task<TicketSale> GetSaleAsync(int customerId, int id)
    {
      return Context.TicketSales
        .Include(s => s.Tickets)
        .Where(s => s.CustomerId == customerId && s.Id == id)
        .FirstOrDefaultAsync();
    }

    /// <summary>
    /// Gets the sales asynchronous.
    /// </summary>
    /// <param name="customerId">The customer identifier.</param>
    /// <returns></returns>
    public Task<TicketSale[]> GetSalesAsync(int customerId)
    {
      return Context.TicketSales
        .Include(s => s.Tickets)
        .Where(s => s.CustomerId == customerId)
        .ToArrayAsync();
    }

    /// <summary>
    /// Determines whether [has customer asynchronous] [the specified user name].
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    public Task<bool> HasCustomerAsync(string userName)
    {
      return Context.Customers.AnyAsync(w => w.UserName.ToUpper() == userName.ToUpper());
    }

    /// <summary>
    /// Determines whether [has sales asynchronous] [the specified identifier].
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public Task<bool> HasSalesAsync(int id)
    {
      return Context.Customers.Include(c => c.Sales).AnyAsync(c => c.Id == id && c.Sales.Any());
    }
  }
}
