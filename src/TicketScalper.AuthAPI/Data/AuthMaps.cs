using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.AuthAPI.Models;
using TicketScalper.Core.Identity;

namespace TicketScalper.AuthAPI.Data
{
    public class AuthMaps : Profile
    {
    public AuthMaps()
    {
      CreateMap<TicketScalperIdentityUser, TicketScalperIdentityModel>()
        .ReverseMap();
    }
    }
}
