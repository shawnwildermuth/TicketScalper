using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.SalesAPI.Data.Entities;
using TicketScalper.SalesAPI.Models;
using TicketScalper.ShowsAPI.Services;

namespace TicketScalper.SalesAPI.Data
{
  public class SalesMaps : Profile
  {
    public SalesMaps()
    {
      CreateMap<Customer, CustomerModel>()
        .ForMember(c => c.FullName, opt => opt.MapFrom(c => $"{c.FirstName} {c.LastName}"))
        .ReverseMap();

      CreateMap<TicketSale, TicketSaleModel>()
        .ReverseMap();

      CreateMap<TicketInfo, TicketModel>()
      .ReverseMap();

      CreateMap<TicketMessage, TicketInfo>()
        .ForMember(t => t.Id, opt => opt.Ignore())
        .ForMember(t => t.Acts, 
          opt => opt.MapFrom(d => string.Join(',', d.Acts)))
        .ForMember(t => t.ShowDate, 
          opt => opt.MapFrom(d => d.ShowDate.ToDateTime()))
        .ForMember(t => t.VenueName,
          opt => opt.MapFrom(d => d.VenueName))
        .ForMember(a => a.AddressLine1,
          opt => opt.MapFrom(x => x.Address1))
        .ForMember(a => a.AddressLine2,
          opt => opt.MapFrom(x => x.Address2))
        .ForMember(a => a.AddressLine3,
          opt => opt.MapFrom(x => x.Address3))
        .ForMember(a => a.CityTown,
          opt => opt.MapFrom(x => x.CityTown))
        .ForMember(a => a.StateProvince,
          opt => opt.MapFrom(x => x.StateProvince))
        .ForMember(a => a.PostalCode,
          opt => opt.MapFrom(x => x.PostalCode))
        .ForMember(a => a.Country,
          opt => opt.MapFrom(x => x.Country))
        .ForMember(a => a.PhoneNumber,
          opt => opt.MapFrom(x => x.Phone));
    }
  }
}
