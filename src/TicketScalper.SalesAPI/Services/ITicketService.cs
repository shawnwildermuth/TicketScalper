using System.Threading.Tasks;
using TicketScalper.SalesAPI.Models;

namespace TicketScalper.SalesAPI.Services
{
  public interface ITicketService
  {
    Task<FinalizedTicketResponse> FinalizeTickets(int[] tickets);
    Task<bool> ReserveTickets(int[] tickets);
  }
}