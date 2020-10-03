using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.ShowsAPI.Models
{
  /// <summary>
  /// Model class for Shows
  /// </summary>
  public class ShowModel
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
    /// Gets or sets a value indicating whether [sold out].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [sold out]; otherwise, <c>false</c>.
    /// </value>
    public bool SoldOut { get; set; }

    /// <summary>
    /// Gets or sets the venue.
    /// </summary>
    /// <value>
    /// The venue.
    /// </value>
    public VenueModel Venue { get; set; }
    /// <summary>
    /// Gets or sets the acts.
    /// </summary>
    /// <value>
    /// The acts.
    /// </value>
    public ActModel[] Acts { get; set; }
  }
}
