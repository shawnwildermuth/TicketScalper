using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.AuthAPI.Models
{
  public class TicketScalperIdentityRequestModel
  {
    [Required]
    [EmailAddress]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
  }
}
