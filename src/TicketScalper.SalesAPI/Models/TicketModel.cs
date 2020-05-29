using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.SalesAPI.Models
{
  public class TicketModel
  {
    public int Id { get; set; }

    public string ShowName { get; set; }
    public string Acts { get; set; }
    public string Seat { get; set; }
    public decimal Price { get; set; }
    public DateTime ShowDate { get; set; }
    public string VenueName { get; set; }
    public string PhoneNumber { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine3 { get; set; }
    public string CityTown { get; set; }
    public string StateProvince { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
  }
}
