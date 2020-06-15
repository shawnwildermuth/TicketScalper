using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TicketScalper.Core.Identity;

namespace BountyApp.Identity.Data
{
  public class TicketScalperIdentityContext : IdentityDbContext<TicketScalperIdentityUser>
  {
    public TicketScalperIdentityContext(DbContextOptions options) : base(options)
    {
    }

  }
}
