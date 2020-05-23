using System.Collections.Generic;
using System.Data;

namespace TicketScalper.ShowsAPI.Data
{
  internal class MappingResult
  {
    public readonly string TableName;
    public readonly DataTable Table;

    public MappingResult(string tblName, DataTable table)
    {
      TableName = tblName;
      Table = table;
    }

  }
}