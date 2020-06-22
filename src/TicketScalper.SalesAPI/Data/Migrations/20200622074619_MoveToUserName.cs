using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketScalper.SalesAPI.Migrations
{
    public partial class MoveToUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Sales",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "Sales",
                table: "Customers",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserName",
                value: "shawn@wildermuth.com");

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "TicketSales",
                keyColumn: "Id",
                keyValue: 1,
                column: "Completed",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "Sales",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Sales",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "{337DA5C8-115B-479D-BB1C-4E1F9C912D18}");

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "TicketSales",
                keyColumn: "Id",
                keyValue: 1,
                column: "Completed",
                value: true);
        }
    }
}
