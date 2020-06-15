using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.AuthAPI.Models
{
  public class TokenRequestViewModel
  {
    [Required]
    [MinLength(5)]
    public string Username { get; set; }
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
  }
}
