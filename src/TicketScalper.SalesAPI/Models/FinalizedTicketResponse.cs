using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.SalesAPI.Data.Entities;

namespace TicketScalper.SalesAPI.Models
{
  /// <summary>
  /// Response design for a Finalized Tickets
  /// </summary>
  public class FinalizedTicketResponse
  {
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="FinalizedTicketResponse"/> is success.
    /// </summary>
    /// <value>
    ///   <c>true</c> if success; otherwise, <c>false</c>.
    /// </value>
    public bool Success { get; set; } = false;
    /// <summary>
    /// Gets or sets the tickets.
    /// </summary>
    /// <value>
    /// The tickets.
    /// </value>
    public IEnumerable<TicketInfo> Tickets { get; set; }
  }
}
