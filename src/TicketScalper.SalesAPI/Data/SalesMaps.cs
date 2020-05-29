using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.SalesAPI.Data.Entities;
using TicketScalper.SalesAPI.Models;

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
    }
  }
}
