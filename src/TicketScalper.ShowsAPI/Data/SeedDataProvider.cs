using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.ShowsAPI.Data.Entities;

namespace TicketScalper.ShowsAPI.Data
{
  public static class SeedDataProvider
  {
    public static Ticket[] GenerateTickets()
    {
      return new Ticket[]
      {
        new Ticket() { Id = 1, Seat = "General Admission", OriginalPrice = 49m, CurrentPrice = 99m, ShowId = 1  },
      new Ticket() { Id =2, Seat = "General Admission", OriginalPrice = 49m, CurrentPrice = 99m, ShowId = 1 },
      new Ticket() { Id =3, Seat = "General Admission", OriginalPrice = 49m, CurrentPrice = 99m, ShowId = 1 },
      new Ticket() { Id =4, Seat = "General Admission", OriginalPrice = 49m, CurrentPrice = 99m, ShowId = 1 },
      new Ticket() { Id =5, Seat = "General Admission", OriginalPrice = 49m, CurrentPrice = 99m, ShowId = 1 },
      new Ticket() { Id =6, Seat = "General Admission", OriginalPrice = 49m, CurrentPrice = 99m, ShowId = 1 },
      new Ticket() { Id =7, Seat = "General Admission", OriginalPrice = 49m, CurrentPrice = 99m, ShowId = 1 },
      new Ticket() { Id =8, Seat = "General Admission", OriginalPrice = 49m, CurrentPrice = 99m, ShowId = 1 },
      new Ticket() { Id =9, Seat = "F11", OriginalPrice = 129m, CurrentPrice = 299m, ShowId = 2 },
      new Ticket() { Id =10, Seat = "F12", OriginalPrice = 129m, CurrentPrice = 299m, ShowId = 2 },
      new Ticket() { Id =11, Seat = "F13", OriginalPrice = 129m, CurrentPrice = 299m, ShowId = 2 },
      new Ticket() { Id =12, Seat = "F14", OriginalPrice = 129m, CurrentPrice = 299m, ShowId = 2 },
      new Ticket() { Id =13, Seat = "G01", OriginalPrice = 129m, CurrentPrice = 299m, ShowId = 2 },
      new Ticket() { Id =14, Seat = "G02", OriginalPrice = 129m, CurrentPrice = 299m, ShowId = 2 },
      new Ticket() { Id =15, Seat = "G03", OriginalPrice = 129m, CurrentPrice = 299m, ShowId = 2 },
      new Ticket() { Id =16, Seat = "G04", OriginalPrice = 129m, CurrentPrice = 299m, ShowId = 2 }
    };
    }

    public static ActShow[] GenerateActShows()
    {
      return new ActShow[]
      {
      new ActShow() { ActId = 1, ShowId = 1},
      new ActShow() { ActId = 3, ShowId = 1},
      new ActShow() { ActId = 2, ShowId = 2},
      new ActShow() { ActId = 2, ShowId = 3},
      };
    }

    public static Show[] GenerateShows()
    {
      return new Show[]
      {
        new Show()
        {
          Id = 1,
          Name = "Jethro Tull and Styx",
          Length = 1 ,
          StartDate  = new DateTime(2020, 11, 1),
          IsGeneralAdmission = true,
          VenueId = 2
          },
        new Show()
        {
          Id = 1,
          Name = "Bruce!",
          Length = 1 ,
          StartDate  = new DateTime(2020, 11, 4),
          IsGeneralAdmission = false,
          VenueId = 1
        },
        new Show()
        {
          Id = 1,
          Name = "Bruce!",
          Length = 1 ,
          StartDate  = new DateTime(2020, 11, 3),
          IsGeneralAdmission = false,
          VenueId = 1
        },
      };
    }

    public static Venue[] GenerateVenues()
    {

      return new Venue[]
      {
        new Venue()
        {
          Id = 1,
          Name = "The Omni",
          Phone = "(404) 555-1212",
          Address = new Address()
          {
            Address1 = "123 Peachtree St",
            CityTown = "Atlanta",
            StateProvince = "GA",
            PostalCode = "30303",
            Country ="USA"
          }
        },
        new Venue()
        {
          Id = 2,
          Name = "Variety Playhouse",
          Phone = "(404) 555-1213",
          Address = new Address()
          {
            Address1 = "123 Euclid Avenue",
            CityTown = "Atlanta",
            StateProvince = "GA",
            PostalCode = "30307",
            Country ="USA"
          }
        }
      };
    }

    public static Act[] GenerateActs()
    {
      return new Act[]
      {
        new Act() { Id = 1, Name = "Jethro Tull", Description = "Flute Tour"},
        new Act() { Id = 2, Name = "Bruce Springsteen", Description = "The Boss Across the World"},
        new Act() { Id = 3, Name = "Styx", Description = "We're Still Alive Tour"}
      };
    }
  }

}
