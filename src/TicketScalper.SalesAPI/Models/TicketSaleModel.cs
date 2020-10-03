using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.SalesAPI.Models
{
  /// <summary>
  /// Model for a Ticket Sale
  /// </summary>
  public class TicketSaleModel
  {
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the approval code.
    /// </summary>
    /// <value>
    /// The approval code.
    /// </value>
    public string ApprovalCode { get; set; }
    /// <summary>
    /// Gets or sets the type of the payment.
    /// </summary>
    /// <value>
    /// The type of the payment.
    /// </value>
    public string PaymentType { get; set; }
    /// <summary>
    /// Gets or sets the transaction number.
    /// </summary>
    /// <value>
    /// The transaction number.
    /// </value>
    public string TransactionNumber { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="TicketSaleModel"/> is completed.
    /// </summary>
    /// <value>
    ///   <c>true</c> if completed; otherwise, <c>false</c>.
    /// </value>
    public bool Completed { get; set; }
    /// <summary>
    /// Gets or sets the transaction total.
    /// </summary>
    /// <value>
    /// The transaction total.
    /// </value>
    public decimal TransactionTotal { get; set; }
    /// <summary>
    /// Gets or sets the customer identifier.
    /// </summary>
    /// <value>
    /// The customer identifier.
    /// </value>
    public int CustomerId { get; set; }
    /// <summary>
    /// Gets or sets the tickets.
    /// </summary>
    /// <value>
    /// The tickets.
    /// </value>
    public IEnumerable<TicketModel> Tickets { get; set; }
  }
}
