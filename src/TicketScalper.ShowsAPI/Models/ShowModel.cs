using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.ShowsAPI.Models
{
    public class ShowModel
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public int Length { get; set; }
    public bool IsGeneralAdmission { get; set; }
    public bool SoldOut { get; set; }

    public VenueModel Venue { get; set; }
    public ActModel[] Acts { get; set; }
  }
}
