using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.Core.Seeding
{
  public interface ISeeder
  {
    Task Seed();
  }
}
