using FastMember;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.Core.Seeding;

namespace TicketScalper.ShowsAPI.Data
{
  public class ShowSeeder : SqlServerSeederBase<ShowContext>
  {
    private const string PROPERTYNAME = "PROPERTYNAME";
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

      if (_config.GetValue<bool>("Debug:IterateDatabase"))
      {
        await Context.Database.EnsureDeletedAsync();
        await Context.Database.MigrateAsync();
      }

      if (await CanSeed())
      {
        if (!await Context.Acts.AnyAsync())
        {
          _logger.LogInformation("Attempting to Seed the Database...");
          var bulkOptions = SqlBulkCopyOptions.KeepIdentity | SqlBulkCopyOptions.UseInternalTransaction;

          // Get Connection from Context passed in
          using (var bulkCopy = new SqlBulkCopy(Context.Database.GetDbConnection().ConnectionString, bulkOptions))
          {

            await BulkWrite(bulkCopy, SeedDataProvider.GenerateActs());
            await BulkWrite(bulkCopy, SeedDataProvider.GenerateVenues());
            await BulkWrite(bulkCopy, SeedDataProvider.GenerateShows());
            await BulkWrite(bulkCopy, SeedDataProvider.GenerateActShows());
            await BulkWrite(bulkCopy, SeedDataProvider.GenerateTickets());
          }
        }
        else
        {
          _logger.LogInformation("Seeding not necessary...");
        }
      }
      else
      {
        _logger.LogError("Cannot run server...database is not updated...");
        throw new InvalidOperationException("Server cannot run, database is not up to date...");
      }
    }

    private async Task BulkWrite<T>(SqlBulkCopy bulkCopy, IEnumerable<T> data)
    {
      try
      {
        var mapping = GetMappingInfo<T>(data);

        bulkCopy.DestinationTableName = mapping.TableName;
        await bulkCopy.WriteToServerAsync(mapping.Table);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Failed to seed: {ex}");
        throw new InvalidOperationException("Seeding Failed", ex);
      }
    }

    private MappingResult GetMappingInfo<T>(IEnumerable<T> data)
    {
      var table = new DataTable();

      var entityInfo = Context.Model.GetEntityTypes(typeof(T)).FirstOrDefault();
      if (entityInfo == null) throw new InvalidOperationException("Failed to determine table type.");

      var tblName = $"[{entityInfo.GetSchema()}].[{entityInfo.GetTableName()}]";

      table.Columns.AddRange(GenerateColumns(entityInfo));

      // Store Data
      foreach (var item in data)
      {
        table.Rows.Add(GenerateRow(item, table));
      }

      return new MappingResult(tblName, table);
    }

    private object[] GenerateRow<T>(T item, DataTable table)
    {
      var values = new List<object>();

      foreach (DataColumn col in table.Columns)
      {
        var getter = (IClrPropertyGetter)col.ExtendedProperties[PROPERTYNAME];
        values.Add(getter.GetClrValue(item));
      }

      return values.ToArray();
    }

    private DataColumn[] GenerateColumns(IEntityType entityInfo)
    {
      var columns = new List<DataColumn>();

      var props = entityInfo.GetDeclaredProperties();

      foreach (var field in props) columns.Add(GenerateColumn(field));

      // Owned Properties
      foreach (var ownedEntity in entityInfo.GetNavigations().Where(n => n.GetTargetType().IsOwned()))
      {
        var targetEntityInfo = ownedEntity.GetTargetType();

        foreach (var field in targetEntityInfo.GetDeclaredProperties()
          .Where(p => !p.IsShadowProperty()))
        {
          columns.Add(GenerateColumn(field));
        }
      }

      return columns.ToArray();
    }

    private DataColumn GenerateColumn(IProperty field)
    {
      var column = new DataColumn();
      column.ColumnName = field.GetColumnName();
      column.DataType = field.ClrType;
      column.ExtendedProperties[PROPERTYNAME] = field.GetGetter();
      return column;
    }
  }
}
