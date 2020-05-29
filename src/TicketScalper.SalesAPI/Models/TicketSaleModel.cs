using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.SalesAPI.Models
{
    public class TicketSaleModel
    {
    public int Id { get; set; }
    public string ApprovalCode { get; set; }
    public string PaymentType { get; set; }
    public string TransactionNumber { get; set; }
    public bool Completed { get; set; }
    public decimal TransactionTotal { get; set; }
    public int CustomerId { get; set; }
    public IEnumerable<TicketModel> Tickets { get; set; }
  }
}
