using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketScalper.Core.Data;
using TicketScalper.SalesAPI.Data.Entities;

namespace TicketScalper.SalesAPI.Data
{
  /// <summary>
  /// Interface for the Repository for Sales
  /// </summary>
  /// <seealso cref="TicketScalper.Core.Data.IRepository" />
  public interface ISalesRepository : IRepository
  {
    /// <summary>
    /// Gets the customers asynchronous.
    /// </summary>
    /// <returns></returns>
    Task<Customer[]> GetCustomersAsync();
    /// <summary>
    /// Gets the customer asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<Customer> GetCustomerAsync(int id);
    /// <summary>
    /// Gets the customer by user asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<Customer> GetCustomerByUserAsync(string id);
    /// <summary>
    /// Determines whether [has customer asynchronous] [the specified user name].
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    Task<bool> HasCustomerAsync(string userName);

    /// <summary>
    /// Determines whether [has sales asynchronous] [the specified identifier].
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<bool> HasSalesAsync(int id);
    /// <summary>
    /// Gets the sales asynchronous.
    /// </summary>
    /// <param name="customerId">The customer identifier.</param>
    /// <returns></returns>
    Task<TicketSale[]> GetSalesAsync(int customerId);
    /// <summary>
    /// Gets the sale asynchronous.
    /// </summary>
    /// <param name="customerId">The customer identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<TicketSale> GetSaleAsync(int customerId, int id);
  }
}