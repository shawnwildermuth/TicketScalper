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
  public class SalesRepository : BaseRepository<SalesContext>, ISalesRepository
  {
    public SalesRepository(SalesContext context) : base(context)
    {
    }

    public Task<Customer> GetCustomerAsync(int id)
    {
      return Context.Customers
        .Where(c => c.Id == id)
        .FirstOrDefaultAsync();
    }

    public Task<Customer> GetCustomerByUserAsync(string id)
    {
      return Context.Customers
        .Where(c => c.UserId == id)
        .FirstOrDefaultAsync();
    }

    public Task<Customer[]> GetCustomersAsync()
    {
      return Context.Customers.ToArrayAsync();
    }

    public Task<TicketSale> GetSaleAsync(int customerId, int id)
    {
      return Context.TicketSales
        .Include(s => s.Tickets)
        .Where(s => s.CustomerId == customerId && s.Id == id)
        .FirstOrDefaultAsync();
    }

    public Task<TicketSale[]> GetSalesAsync(int customerId)
    {
      return Context.TicketSales
        .Include(s => s.Tickets)
        .Where(s => s.CustomerId == customerId)
        .ToArrayAsync();
    }

    public Task<bool> HasCustomerAsync(string firstName, string lastName)
    {
      return Context.Customers.AnyAsync(w => w.FirstName.ToUpper() == firstName.ToUpper() && w.LastName.ToUpper() == lastName.ToUpper());
    }

    public Task<bool> HasSalesAsync(int id)
    {
      return Context.Customers.Include(c => c.Sales).AnyAsync(c => c.Id == id && c.Sales.Any());
    }
  }
}
