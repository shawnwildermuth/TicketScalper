using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.Core.Controllers
{
  public class UserController : ControllerBase
  {
    public string UserName 
    {
      get 
      {
        return User.Identity.Name;
      }
    }

    public string UserId
    {
      get
      {
        return User.Claims.Where(c => c.Type == JwtRegisteredClaimNames.Jti).FirstOrDefault()?.Value;
      }
    }
  }
}
