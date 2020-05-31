using System;

namespace TicketScalper.ShowsAPI.Data.Entities
{
  public class Ticket
  {
    public int Id { get; set; }
    public string Seat { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal CurrentPrice { get; set; }
    public DateTime Date { get; set; }

    public int ShowId { get; set; }

    public Show Show { get; set; }
  }
}