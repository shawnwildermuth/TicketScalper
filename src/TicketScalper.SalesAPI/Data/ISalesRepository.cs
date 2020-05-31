using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketScalper.Core.Data;
using TicketScalper.SalesAPI.Data.Entities;

namespace TicketScalper.SalesAPI.Data
{
  public interface ISalesRepository : IRepository
  {
    Task<Customer[]> GetCustomersAsync();
    Task<Customer> GetCustomerAsync(int id);
    Task<bool> HasCustomerAsync(string firstName, string lastName);
    Task<bool> HasSalesAsync(int id);
    Task<TicketSale[]> GetSalesAsync(int customerId);
    Task<TicketSale> GetSaleAsync(int customerId, int id);
  }
}