using System.Collections.Generic;

namespace TicketScalper.SalesAPI.Data.Entities
{
  public class TicketSale
  {
    public int Id { get; set; }
    public string ApprovalCode { get; set; }
    public string PaymentType { get; set; }
    public string TransactionNumber { get; set; }
    public bool Completed { get; set; }
    public decimal TransactionTotal { get; set; }

    public Customer Customer { get; set; }
    public int CustomerId { get; set; }

    public ICollection<TicketInfo> Tickets { get; set; }
  }
}