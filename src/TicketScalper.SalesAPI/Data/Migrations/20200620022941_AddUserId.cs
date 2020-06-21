using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketScalper.SalesAPI.Migrations
{
    public partial class AddUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Sales",
                table: "Customers",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "UserId" },
                values: new object[] { "Shawn", "{337DA5C8-115B-479D-BB1C-4E1F9C912D18}" });

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "TicketSales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Completed", "TransactionTotal" },
                values: new object[] { true, 399.54m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Sales",
                table: "Customers");

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FirstName",
                value: "Resa");

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "TicketSales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Completed", "TransactionTotal" },
                values: new object[] { true, 0m });
        }
    }
}
