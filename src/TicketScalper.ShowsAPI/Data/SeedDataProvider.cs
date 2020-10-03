﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.ShowsAPI.Data.Entities;

namespace TicketScalper.ShowsAPI.Data
{
  /// <summary>
  /// A provider for sample data
  /// </summary>
  public static class SeedDataProvider
  {
    /// <summary>
    /// Generates the tickets.
    /// </summary>
    /// <returns>A collection of Tickets</returns>
    public static Ticket[] GenerateTickets()
    {
      return new Ticket[]
      {
        new Ticket() { Id = 1, Date = new DateTime(2020,11,2), Seat = "General Admission", OriginalPrice = 49.99m, CurrentPrice = 99.99m, ShowId = 1  },
        new Ticket() { Id = 2, Date = new DateTime(2020,11,2), Seat = "General Admission", OriginalPrice = 49.99m, CurrentPrice = 99.99m, ShowId = 1 },
        new Ticket() { Id = 3, Date = new DateTime(2020,11,2), Seat = "General Admission", OriginalPrice = 49.99m, CurrentPrice = 99.99m, ShowId = 1 },
        new Ticket() { Id = 4, Date = new DateTime(2020,11,2), Seat = "General Admission", OriginalPrice = 49.99m, CurrentPrice = 99.99m, ShowId = 1 },
        new Ticket() { Id = 5, Date = new DateTime(2020,11,2), Seat = "General Admission", OriginalPrice = 49.99m, CurrentPrice = 99.99m, ShowId = 1 },
        new Ticket() { Id = 6, Date = new DateTime(2020,11,2), Seat = "General Admission", OriginalPrice = 49.99m, CurrentPrice = 99.99m, ShowId = 1 },
        new Ticket() { Id = 7, Date = new DateTime(2020,11,2), Seat = "General Admission", OriginalPrice = 49.99m, CurrentPrice = 99.99m, ShowId = 1 },
        new Ticket() { Id = 8, Date = new DateTime(2020,11,2), Seat = "General Admission", OriginalPrice = 49.99m, CurrentPrice = 99.99m, ShowId = 1 },
        new Ticket() { Id = 9, Date = new DateTime(2020,11,4), Seat = "F11", OriginalPrice = 129m, CurrentPrice = 299.99m, ShowId = 2 },
        new Ticket() { Id = 10, Date = new DateTime(2020,11,4), Seat = "F12", OriginalPrice = 129m, CurrentPrice = 299.99m, ShowId = 2 },
        new Ticket() { Id = 11, Date = new DateTime(2020,11,4), Seat = "F13", OriginalPrice = 129m, CurrentPrice = 299.99m, ShowId = 2 },
        new Ticket() { Id = 12, Date = new DateTime(2020,11,4), Seat = "F14", OriginalPrice = 129m, CurrentPrice = 299.99m, ShowId = 2 },
        new Ticket() { Id = 13, Date = new DateTime(2020,11,4), Seat = "G01", OriginalPrice = 129m, CurrentPrice = 299.99m, ShowId = 2 },
        new Ticket() { Id = 14, Date = new DateTime(2020,11,4), Seat = "G02", OriginalPrice = 129m, CurrentPrice = 299.99m, ShowId = 2 },
        new Ticket() { Id = 15, Date = new DateTime(2020,11,4), Seat = "G03", OriginalPrice = 129m, CurrentPrice = 299.99m, ShowId = 2 },
        new Ticket() { Id = 16, Date = new DateTime(2020,11,4), Seat = "G04", OriginalPrice = 129m, CurrentPrice = 299.99m, ShowId = 2 }
      };
    }

    /// <summary>
    /// Generates the act shows.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Generates the shows.
    /// </summary>
    /// <returns></returns>
    public static Show[] GenerateShows()
    {
      return new Show[]
      {
        new Show()
        {
          Id = 1,
          Name = "Jethro Tull and Styx",
          Length = 1 ,
          StartDate  = new DateTime(2020, 11, 1).ToUniversalTime(),
          IsGeneralAdmission = true,
          VenueId = 2
        },
        new Show()
        {
          Id = 2,
          Name = "Bruce!",
          Length = 1 ,
          StartDate  = new DateTime(2020, 11, 4).ToUniversalTime(),
          IsGeneralAdmission = false,
          VenueId = 1
        },
        new Show()
        {
          Id = 3,
          Name = "Bruce!",
          Length = 1 ,
          StartDate  = new DateTime(2020, 11, 3).ToUniversalTime(),
          IsGeneralAdmission = false,
          VenueId = 1
        },
      };
    }

    /// <summary>
    /// Generates the venues.
    /// </summary>
    /// <returns></returns>
    public static Venue[] GenerateVenues()
    {

      return new Venue[]
      {
        new Venue()
        {
          Id = 1,
          Name = "The Omni",
          Phone = "(404) 555-1212",
        },
        new Venue()
        {
          Id = 2,
          Name = "Variety Playhouse",
          Phone = "(404) 555-1213",
        }
      };
    }

    /// <summary>
    /// Generates the addresses.
    /// </summary>
    /// <returns></returns>
    public static Address[] GenerateAddresses()
    {
      return new Address[]
      {
          new Address()
          {
            Address1 = "123 Peachtree St",
            CityTown = "Atlanta",
            StateProvince = "GA",
            PostalCode = "30303",
            Country ="USA",
            VenueId = 1
          },
          new Address()
          {
            Address1 = "123 Euclid Avenue",
            CityTown = "Atlanta",
            StateProvince = "GA",
            PostalCode = "30307",
            Country ="USA",
            VenueId = 2
          }

      };
    }

    /// <summary>
    /// Generates the acts.
    /// </summary>
    /// <returns></returns>
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
