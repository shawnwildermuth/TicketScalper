using System.Collections;
using System.Collections.Generic;

namespace TicketScalper.ShowsAPI.Data.Entities
{
  /// <summary>
  /// Entity for the Venue
  /// </summary>
  public class Venue
  {
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets the phone.
    /// </summary>
    /// <value>
    /// The phone.
    /// </value>
    public string Phone { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>
    /// The address.
    /// </value>
    public Address Address { get; set; }
    /// <summary>
    /// Gets or sets the shows.
    /// </summary>
    /// <value>
    /// The shows.
    /// </value>
    public ICollection<Show>  Shows { get; set; }
  }
}