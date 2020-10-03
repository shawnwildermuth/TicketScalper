using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.ShowsAPI.Data.Entities
{
  /// <summary>
  /// Entity for one to many collection of Acts to Shows
  /// </summary>
  public class ActShow
  {
    /// <summary>
    /// Gets or sets the act identifier.
    /// </summary>
    /// <value>
    /// The act identifier.
    /// </value>
    public int ActId { get; set; }
    /// <summary>
    /// Gets or sets the act.
    /// </summary>
    /// <value>
    /// The act.
    /// </value>
    public Act Act { get; set; }
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
