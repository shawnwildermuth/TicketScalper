using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.SalesAPI.Models
{
  /// <summary>
  /// Model for a ticket request
  /// </summary>
  public class TicketRequestModel
  {
    /// <summary>
    /// Gets or sets the ticket ids.
    /// </summary>
    /// <value>
    /// The ticket ids.
    /// </value>
    [Required]
    public int[] TicketIds { get; set; }
    /// <summary>
    /// Gets or sets the credit card.
    /// </summary>
    /// <value>
    /// The credit card.
    /// </value>
    [Required]
    public string CreditCard { get; set; }
    /// <summary>
    /// Gets or sets the expiration month.
    /// </summary>
    /// <value>
    /// The expiration month.
    /// </value>
    [Required]
    public int ExpirationMonth { get; set; }
    /// <summary>
    /// Gets or sets the expiration year.
    /// </summary>
    /// <value>
    /// The expiration year.
    /// </value>
    [Required]
    public int ExpirationYear { get; set; }
    /// <summary>
    /// Gets or sets the validation code.
    /// </summary>
    /// <value>
    /// The validation code.
    /// </value>
    [Required]
    public string ValidationCode { get; set; }
    /// <summary>
    /// Gets or sets the postal code.
    /// </summary>
    /// <value>
    /// The postal code.
    /// </value>
    [Required]
    public string PostalCode { get; set; }

  }
}
