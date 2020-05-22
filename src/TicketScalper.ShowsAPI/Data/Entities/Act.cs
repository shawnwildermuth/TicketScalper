using System.Collections;
using System.Collections.Generic;

namespace TicketScalper.ShowsAPI.Data.Entities
{
  public class Act
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<ActShow> ActShows { get; set; }

  }
}