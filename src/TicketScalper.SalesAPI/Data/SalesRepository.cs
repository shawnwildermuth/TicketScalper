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
        .Where(c => c.UserName == id)
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

    public Task<bool> HasCustomerAsync(string userName)
    {
      return Context.Customers.AnyAsync(w => w.UserName.ToUpper() == userName.ToUpper());
    }

    public Task<bool> HasSalesAsync(int id)
    {
      return Context.Customers.Include(c => c.Sales).AnyAsync(c => c.Id == id && c.Sales.Any());
    }
  }
}
