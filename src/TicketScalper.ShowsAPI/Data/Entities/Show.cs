using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.ShowsAPI.Data.Entities
{
    public class Show
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public int Length { get; set; }
    public bool IsGeneralAdmission { get; set; }

    public Venue Venue { get; set; }
    public ICollection<ActShow> ActShows { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
  }
}
