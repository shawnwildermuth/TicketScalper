using System.Collections;
using System.Collections.Generic;

namespace TicketScalper.ShowsAPI.Data.Entities
{
  /// <summary>
  /// Entity that represents an Act for a Show
  /// </summary>
  public class Act
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
    /// Gets or sets the description.
    /// </summary>
    /// <value>
    /// The description.
    /// </value>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the act shows.
    /// </summary>
    /// <value>
    /// The act shows.
    /// </value>
    public ICollection<ActShow> ActShows { get; set; }

  }
}