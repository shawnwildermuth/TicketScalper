using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.ShowsAPI.Data.Entities
{
  /// <summary>
  /// The Entity that represents a Show
  /// </summary>
  public class Show
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
    /// Gets or sets the start date.
    /// </summary>
    /// <value>
    /// The start date.
    /// </value>
    public DateTime StartDate { get; set; }
    /// <summary>
    /// Gets or sets the length.
    /// </summary>
    /// <value>
    /// The length.
    /// </value>
    public int Length { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether this instance is general admission.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is general admission; otherwise, <c>false</c>.
    /// </value>
    public bool IsGeneralAdmission { get; set; }

    /// <summary>
    /// Gets or sets the venue identifier.
    /// </summary>
    /// <value>
    /// The venue identifier.
    /// </value>
    public int VenueId { get; set; }

    /// <summary>
    /// Gets or sets the venue.
    /// </summary>
    /// <value>
    /// The venue.
    /// </value>
    public Venue Venue { get; set; }
    /// <summary>
    /// Gets or sets the act shows.
    /// </summary>
    /// <value>
    /// The act shows.
    /// </value>
    public ICollection<ActShow> ActShows { get; set; }
    /// <summary>
    /// Gets or sets the tickets.
    /// </summary>
    /// <value>
    /// The tickets.
    /// </value>
    public ICollection<Ticket> Tickets { get; set; }
  }
}
