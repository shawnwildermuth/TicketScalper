using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.Core.Seeding;

namespace TicketScalper.ShowsAPI.Data
{
  public class ShowSeeder : SeederBase<ShowContext>
  {
    private readonly IConfiguration _config;
    private readonly ILogger<ShowSeeder> _logger;

    public ShowSeeder(ShowContext context, IConfiguration config, ILogger<ShowSeeder> logger) : base(context)
    {
      _config = config;
      _logger = logger;
    }

    public override async Task Seed()
    {
      _logger.LogInformation("Determining if Seeding is Necessary...");

      if (await CanSeed())
      {
        if (!await Context.Acts.AnyAsync())
        {
          _logger.LogInformation("Attempting to Seed the Database...");
          using (var bulkCopy = new SqlBulkCopy(_config.GetConnectionString("ShowDb")))
          {
            await BulkWrite(bulkCopy, "[TicketScalper].[Acts]", GenerateActs());
            await BulkWrite(bulkCopy, "[TicketScalper].[Venues]", GenerateVenues());
            await BulkWrite(bulkCopy, "[TicketScalper].[Shows]", GenerateShows());
            await BulkWrite(bulkCopy, "[TicketScalper].[ActShows]", GenerateActShows());
            await BulkWrite(bulkCopy, "[TicketScalper].[Tickets]", GenerateTickets());
          }
        }
        else
        {
          _logger.LogInformation("Seed not necessary...");
        }
      }
      else
      {
        _logger.LogError("Cannot run server...database is not updated...");
        throw new InvalidOperationException("Server cannot run, database is not up to date...");
      }
    }

    private async Task BulkWrite(SqlBulkCopy bulkCopy, string tableName, DataTable dataTable)
    {
      try
      {
        bulkCopy.DestinationTableName = tableName;
        await bulkCopy.WriteToServerAsync(dataTable);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Failed to seed: {ex}");
        throw new InvalidOperationException("Seeding Failed");
      }
    }

    private DataTable GenerateTickets()
    {
      var dt = new DataTable();
      dt.Columns.Add("Id", typeof(int));
      dt.Columns.Add("Seat", typeof(string));
      dt.Columns.Add("OriginalPrice", typeof(decimal));
      dt.Columns.Add("CurrentPrice", typeof(decimal));
      dt.Columns.Add("ShowId", typeof(int));
      dt.Rows.Add(1, "General Admission", 49m, 99m, 1);
      dt.Rows.Add(2, "General Admission", 49m, 99m, 1);
      dt.Rows.Add(3, "General Admission", 49m, 99m, 1);
      dt.Rows.Add(4, "General Admission", 49m, 99m, 1);
      dt.Rows.Add(5, "General Admission", 49m, 99m, 1);
      dt.Rows.Add(6, "General Admission", 49m, 99m, 1);
      dt.Rows.Add(7, "General Admission", 49m, 99m, 1);
      dt.Rows.Add(8, "General Admission", 49m, 99m, 1);
      dt.Rows.Add(9, "F11", 129m, 399m, 2);
      dt.Rows.Add(10, "F12", 129m, 399m, 2);
      dt.Rows.Add(11, "F13", 129m, 399m, 2);
      dt.Rows.Add(12, "F14", 129m, 399m, 2);
      dt.Rows.Add(13, "G01", 129m, 399m, 2);
      dt.Rows.Add(14, "G02", 129m, 399m, 2);
      dt.Rows.Add(15, "G03", 129m, 399m, 2);
      dt.Rows.Add(16, "G04", 129m, 399m, 2);

      return dt;
    }

    private DataTable GenerateActShows()
    {
      var dt = new DataTable();
      dt.Columns.Add("ActId", typeof(int));
      dt.Columns.Add("ShowId", typeof(int));
      dt.Rows.Add(1, 1);
      dt.Rows.Add(3, 1);
      dt.Rows.Add(2, 2);

      return dt;
    }

    private DataTable GenerateShows()
    {
      var dt = new DataTable();
      dt.Columns.Add("Id", typeof(int));
      dt.Columns.Add("Name", typeof(string));
      dt.Columns.Add("StartDate", typeof(DateTime));
      dt.Columns.Add("Length", typeof(int));
      dt.Columns.Add("IsGeneralAdmission", typeof(bool));
      dt.Columns.Add("VenueId", typeof(int));
      dt.Rows.Add(1, "Jethro Tull and Styx", DateTime.Today, 1, true, 2);
      dt.Rows.Add(2, "Bruce!", DateTime.Today, 1, false, 1);

      return dt;
    }

    private DataTable GenerateVenues()
    {
      var dt = new DataTable();
      dt.Columns.Add("Id", typeof(int));
      dt.Columns.Add("Name", typeof(string));
      dt.Columns.Add("Phone", typeof(string));
      dt.Columns.Add("Address_Address1", typeof(string));
      dt.Columns.Add("Address_Address2", typeof(string));
      dt.Columns.Add("Address_Address3", typeof(string));
      dt.Columns.Add("Address_CityTown", typeof(string));
      dt.Columns.Add("Address_StateProvince", typeof(string));
      dt.Columns.Add("Address_PostalCode", typeof(string));
      dt.Columns.Add("Address_Country", typeof(string));
      dt.Rows.Add(1, 
        "The Omni", 
        "(404) 555-1212",
        "123 Peachtree St",
        "",
        "",
        "Atlanta",
        "GA",
        "30303",
        "USA");

      dt.Rows.Add(2,
        "Variety Playhouse",
        "(404) 555-1213",
        "123 Euclid Avenue",
        "",
        "",
        "Atlanta",
        "GA",
        "30303",
        "USA");

      return dt;
    }

    private DataTable GenerateActs()
    {
      var dt = new DataTable();
      dt.Columns.Add("Id", typeof(int));
      dt.Columns.Add("Name", typeof(string));
      dt.Columns.Add("Description", typeof(string));
      dt.Rows.Add(1, "Jethro Tull", "Flute Tour");
      dt.Rows.Add(2, "Bruce Springsteen", "The Boss Across the World");
      dt.Rows.Add(3, "Styx", "We're Still Alive Tour");

      return dt;
    }
  }
}
