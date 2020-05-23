using AutoMapper;
using Microsoft.AspNetCore.Routing.Matching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.ShowsAPI.Data.Entities;
using TicketScalper.ShowsAPI.Models;

namespace TicketScalper.ShowsAPI.Data.Maps
{
  public class ShowMaps : Profile
  {
    public ShowMaps()
    {
      CreateMap<Show, ShowModel>()
        .ForMember(s => s.SoldOut,
          opt => opt.MapFrom(x => !x.Tickets.Any()))
        .ForMember(s => s.Acts, 
          opt => opt.MapFrom(x => x.ActShows.Select(b => b.Act))); // Flatten ActShows

      CreateMap<Ticket, TicketModel>();

      CreateMap<Act, ActModel>();

      CreateMap<Venue, VenueModel>()
        .ForMember(a => a.Address1,
          opt => opt.MapFrom(x => x.Address.Address1))
        .ForMember(a => a.Address2,
          opt => opt.MapFrom(x => x.Address.Address2))
        .ForMember(a => a.Address3,
          opt => opt.MapFrom(x => x.Address.Address3))
        .ForMember(a => a.CityTown,
          opt => opt.MapFrom(x => x.Address.CityTown))
        .ForMember(a => a.StateProvince,
          opt => opt.MapFrom(x => x.Address.StateProvince))
        .ForMember(a => a.PostalCode,
          opt => opt.MapFrom(x => x.Address.PostalCode))
        .ForMember(a => a.Country,
          opt => opt.MapFrom(x => x.Address.Country));
    }
  }
}
