using System;

namespace TicketScalper.ShowsAPI.Data.Entities
{
  /// <summary>
  /// Entity for Tickets
  /// </summary>
  public class Ticket
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
    /// <summary>
    /// Gets or sets the date.
    /// </summary>
    /// <value>
    /// The date.
    /// </value>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the show identifier.
    /// </summary>
    /// <value>
    /// The show identifier.
    /// </value>
    public int ShowId { get; set; }

    /// <summary>
    /// Gets or sets the show.
    /// </summary>
    /// <value>
    /// The show.
    /// </value>
    public Show Show { get; set; }
  }
}