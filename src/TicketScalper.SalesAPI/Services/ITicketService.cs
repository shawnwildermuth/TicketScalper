using System.Threading.Tasks;
using TicketScalper.SalesAPI.Models;

namespace TicketScalper.SalesAPI.Services
{
  /// <summary>
  /// Interface for the ticket service
  /// </summary>
  public interface ITicketService
  {
    /// <summary>
    /// Finalizes the tickets.
    /// </summary>
    /// <param name="tickets">The tickets.</param>
    /// <returns></returns>
    Task<FinalizedTicketResponse> FinalizeTickets(int[] tickets);
    /// <summary>
    /// Reserves the tickets.
    /// </summary>
    /// <param name="tickets">The tickets.</param>
    /// <returns></returns>
    Task<bool> ReserveTickets(int[] tickets);
  }
}