using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.SalesAPI.Data.Entities;

namespace TicketScalper.SalesAPI.Data
{
  /// <summary>
  /// Sample data generator
  /// </summary>
  public static class SalesSeedProvider
  {
    /// <summary>
    /// Generates the customers.
    /// </summary>
    /// <returns></returns>
    public static Customer[] GenerateCustomers()
    {
      return new Customer[]
      {
        new Customer()
        {
          Id = 1,
          FirstName = "Shawn",
          LastName = "Wildermuth",
          PhoneNumber = "404-555-1212",
          AddressLine1 = "123 Main Street",
          CityTown = "Atlanta",
          StateProvince = "GA",
          PostalCode = "12345",
          UserName = "shawn@wildermuth.com"
        }
      };
    }

    internal static TicketSale[] GenerateSales()
    {
      return new TicketSale[]
      {
        new TicketSale()
        {
          Id = 1,
          ApprovalCode = "12345",
          Completed = true,
          CustomerId = 1,
          PaymentType = "Credit Card",
          TransactionNumber = "7287391829",
          TransactionTotal = 399.54m
        }
      };
    }

    internal static TicketInfo[] GenerateTicketInfos()
    {
      return new TicketInfo[]
      {
        new TicketInfo()
        {
          Id = 1,
          Acts = "Styx and REO Speedwagon",
          VenueName = "Variety Playhouse",
          AddressLine1 = "123 Main Street",
          CityTown =  "Atlanta",
          StateProvince = "GA",
          PostalCode = "30307",
          Price = 69.99m,
          Seat = "General Admission",
          ShowName = "We're Still Alive Tour",
          ShowDate = new DateTime(2020, 11, 1),
          SaleId = 1
        },
        new TicketInfo()
        {
          Id = 2,
          Acts = "Styx and REO Speedwagon",
          VenueName = "Variety Playhouse",
          AddressLine1 = "123 Main Street",
          CityTown =  "Atlanta",
          StateProvince = "GA",
          PostalCode = "30307",
          Price = 69.99m,
          Seat = "General Admission",
          ShowName = "We're Still Alive Tour",
          ShowDate = new DateTime(2020, 11, 1),
          SaleId = 1
        },
        new TicketInfo()
        {
          Id = 3,
          Acts = "Styx and REO Speedwagon",
          VenueName = "Variety Playhouse",
          AddressLine1 = "123 Main Street",
          CityTown =  "Atlanta",
          StateProvince = "GA",
          PostalCode = "30307",
          Price = 69.99m,
          Seat = "General Admission",
          ShowName = "We're Still Alive Tour",
          ShowDate = new DateTime(2020, 11, 1),
          SaleId = 1
        },
        new TicketInfo()
        {
          Id = 4,
          Acts = "Styx and REO Speedwagon",
          VenueName = "Variety Playhouse",
          AddressLine1 = "123 Main Street",
          CityTown =  "Atlanta",
          StateProvince = "GA",
          PostalCode = "30307",
          Price = 69.99m,
          Seat = "General Admission",
          ShowName = "We're Still Alive Tour",
          ShowDate = new DateTime(2020, 11, 1),
          SaleId = 1
        },
      };
    }
  }
}
