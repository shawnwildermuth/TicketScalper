using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketScalper.core.Data;
using TicketScalper.SalesAPI.Data.Entities;

namespace TicketScalper.SalesAPI.Data
{
  public interface ISalesRepository : IRepository
  {
    Task<Customer[]> GetCustomersAsync();
    Task<Customer> GetCustomerAsync(int id);
    Task<bool> HasCustomerAsync(string firstName, string lastName);
    Task<bool> HasSalesAsync(int id);
  }
}