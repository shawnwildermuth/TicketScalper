using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketScalper.SalesAPI.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(maxLength: 100, nullable: true),
                    AddressLine3 = table.Column<string>(maxLength: 100, nullable: true),
                    CityTown = table.Column<string>(maxLength: 50, nullable: true),
                    StateProvince = table.Column<string>(maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 20, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketSales",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovalCode = table.Column<string>(maxLength: 100, nullable: true),
                    PaymentType = table.Column<string>(maxLength: 20, nullable: true),
                    TransactionNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Completed = table.Column<bool>(nullable: false, defaultValue: false),
                    TransactionTotal = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketSales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Sales",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowName = table.Column<string>(maxLength: 50, nullable: true),
                    Acts = table.Column<string>(maxLength: 100, nullable: true),
                    Seat = table.Column<string>(maxLength: 20, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    ShowDate = table.Column<DateTime>(nullable: false),
                    VenueName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    AddressLine1 = table.Column<string>(maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(maxLength: 100, nullable: true),
                    AddressLine3 = table.Column<string>(maxLength: 100, nullable: true),
                    CityTown = table.Column<string>(maxLength: 50, nullable: true),
                    StateProvince = table.Column<string>(maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 20, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    SaleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketSales_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "Sales",
                        principalTable: "TicketSales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Sales",
                table: "Customers",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "CityTown", "CompanyName", "Country", "FirstName", "LastName", "PhoneNumber", "PostalCode", "StateProvince" },
                values: new object[] { 1, "123 Main Street", null, null, "Atlanta", null, null, "Resa", "Wildermuth", "404-555-1212", "12345", "GA" });

            migrationBuilder.InsertData(
                schema: "Sales",
                table: "TicketSales",
                columns: new[] { "Id", "ApprovalCode", "Completed", "CustomerId", "PaymentType", "TransactionNumber", "TransactionTotal" },
                values: new object[] { 1, "12345", true, 1, "Credit Card", "7287391829", 0m });

            migrationBuilder.InsertData(
                schema: "Sales",
                table: "Tickets",
                columns: new[] { "Id", "Acts", "AddressLine1", "AddressLine2", "AddressLine3", "CityTown", "Country", "PhoneNumber", "PostalCode", "Price", "SaleId", "Seat", "ShowDate", "ShowName", "StateProvince", "VenueName" },
                values: new object[,]
                {
                    { 1, "Styx and REO Speedwagon", "123 Main Street", null, null, "Atlanta", null, null, "30307", 69.99m, 1, "General Admission", new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "We're Still Alive Tour", "GA", "Variety Playhouse" },
                    { 2, "Styx and REO Speedwagon", "123 Main Street", null, null, "Atlanta", null, null, "30307", 69.99m, 1, "General Admission", new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "We're Still Alive Tour", "GA", "Variety Playhouse" },
                    { 3, "Styx and REO Speedwagon", "123 Main Street", null, null, "Atlanta", null, null, "30307", 69.99m, 1, "General Admission", new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "We're Still Alive Tour", "GA", "Variety Playhouse" },
                    { 4, "Styx and REO Speedwagon", "123 Main Street", null, null, "Atlanta", null, null, "30307", 69.99m, 1, "General Admission", new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "We're Still Alive Tour", "GA", "Variety Playhouse" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SaleId",
                schema: "Sales",
                table: "Tickets",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSales_CustomerId",
                schema: "Sales",
                table: "TicketSales",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "TicketSales",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Sales");
        }
    }
}
