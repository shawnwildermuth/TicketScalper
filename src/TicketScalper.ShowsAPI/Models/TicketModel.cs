namespace TicketScalper.ShowsAPI.Models
{
  public class TicketModel
  {
    public int Id { get; set; }
    public string Seat { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal CurrentPrice { get; set; }
  }
}