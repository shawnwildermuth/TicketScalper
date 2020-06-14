using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.SalesAPI.Models
{
  public class TicketRequestModel
  {
    [Required]
    public int[] TicketIds { get; set; }
    [Required]
    public string CreditCard { get; set; }
    [Required]
    public int ExpirationMonth { get; set; }
    [Required]
    public int ExpirationYear { get; set; }
    [Required]
    public string ValidationCode { get; set; }
    [Required]
    public string PostalCode { get; set; }

  }
}
