namespace TicketScalper.ShowsAPI.Models
{
  /// <summary>
  /// Model for the Ticket Entity
  /// </summary>
  public class TicketModel
  {
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the seat.
    /// </summary>
    /// <value>
    /// The seat.
    /// </value>
    public string Seat { get; set; }
    /// <summary>
    /// Gets or sets the original price.
    /// </summary>
    /// <value>
    /// The original price.
    /// </value>
    public decimal OriginalPrice { get; set; }
    /// <summary>
    /// Gets or sets the current price.
    /// </summary>
    /// <value>
    /// The current price.
    /// </value>
    public decimal CurrentPrice { get; set; }
  }
}