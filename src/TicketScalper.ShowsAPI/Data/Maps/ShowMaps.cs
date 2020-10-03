using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Routing.Matching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.ShowsAPI.Data.Entities;
using TicketScalper.ShowsAPI.Models;
using TicketScalper.ShowsAPI.Services;

namespace TicketScalper.ShowsAPI.Data.Maps
{
  /// <summary>
  /// The Mapping Profile for Shows
  /// </summary>
  /// <seealso cref="AutoMapper.Profile" />
  public class ShowMaps : Profile
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ShowMaps"/> class.
    /// </summary>
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

      CreateMap<Ticket, TicketMessage>()
        .ForMember(t => t.ShowName,
          opt => opt.MapFrom(d => d.Show.Name))
        .ForMember(t => t.ShowDate,
          opt => opt.MapFrom(d => Timestamp.FromDateTime(d.Date.Date.ToUniversalTime())))
        .ForMember(t => t.Price,
          opt => opt.MapFrom(d => d.CurrentPrice))
        .ForMember(t => t.Acts,
          opt => opt.MapFrom(d => d.Show.ActShows.Select(s => s.Act.Name)))
        .ForMember(t => t.VenueName, opt => opt.MapFrom(d => d.Show.Venue.Name))
        .ForMember(a => a.Address1,
          opt => opt.MapFrom(x => NotNullString(x.Show.Venue.Address.Address1)))
        .ForMember(a => a.Address2,
          opt => opt.MapFrom(x => NotNullString(x.Show.Venue.Address.Address2)))
        .ForMember(a => a.Address3,
          opt => opt.MapFrom(x => NotNullString(x.Show.Venue.Address.Address3)))
        .ForMember(a => a.CityTown,
          opt => opt.MapFrom(x => NotNullString(x.Show.Venue.Address.CityTown)))
        .ForMember(a => a.StateProvince,
          opt => opt.MapFrom(x => NotNullString(x.Show.Venue.Address.StateProvince)))
        .ForMember(a => a.PostalCode,
          opt => opt.MapFrom(x => NotNullString(x.Show.Venue.Address.PostalCode)))
        .ForMember(a => a.Country,
          opt => opt.MapFrom(x => NotNullString(x.Show.Venue.Address.Country)));

    }

    private string NotNullString(string value)
    {
      return string.IsNullOrWhiteSpace(value) ? "" : value;
    }
  }
}
