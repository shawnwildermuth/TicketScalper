using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.SalesAPI.Data.Entities;

namespace TicketScalper.SalesAPI.Models
{
  public class FinalizedTicketResponse
  {
    public bool Success { get; set; } = false;
    public IEnumerable<TicketInfo> Tickets { get; set; }
  }
}
