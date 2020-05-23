using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketScalper.ShowsAPI.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Venues_VenueId",
                schema: "TicketScalper",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Shows_ShowId",
                schema: "TicketScalper",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                schema: "TicketScalper",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                schema: "TicketScalper",
                table: "Shows",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "TicketScalper",
                table: "Acts",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Flute Tour", "Jethro Tull" },
                    { 2, "The Boss Across the World", "Bruce Springsteen" },
                    { 3, "We're Still Alive Tour", "Styx" }
                });

            migrationBuilder.InsertData(
                schema: "TicketScalper",
                table: "Venues",
                columns: new[] { "Id", "Name", "Phone", "Address_Address1", "Address_Address2", "Address_Address3", "Address_CityTown", "Address_Country", "Address_PostalCode", "Address_StateProvince" },
                values: new object[,]
                {
                    { 1, "The Omni", "(404) 555-1212", "123 Peachtree St", null, null, "Atlanta", "USA", "30303", "GA" },
                    { 2, "Variety Playhouse", "(404) 555-1213", "123 Euclid Avenue", null, null, "Atlanta", "USA", "30307", "GA" }
                });

            migrationBuilder.InsertData(
                schema: "TicketScalper",
                table: "Shows",
                columns: new[] { "Id", "Length", "Name", "StartDate", "VenueId" },
                values: new object[] { 2, 1, "Bruce!", new DateTime(2020, 11, 4, 5, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.InsertData(
                schema: "TicketScalper",
                table: "Shows",
                columns: new[] { "Id", "Length", "Name", "StartDate", "VenueId" },
                values: new object[] { 3, 1, "Bruce!", new DateTime(2020, 11, 3, 5, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.InsertData(
                schema: "TicketScalper",
                table: "Shows",
                columns: new[] { "Id", "IsGeneralAdmission", "Length", "Name", "StartDate", "VenueId" },
                values: new object[] { 1, true, 1, "Jethro Tull and Styx", new DateTime(2020, 11, 1, 4, 0, 0, 0, DateTimeKind.Utc), 2 });

            migrationBuilder.InsertData(
                schema: "TicketScalper",
                table: "ActShows",
                columns: new[] { "ActId", "ShowId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 3, 1 },
                    { 1, 1 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                schema: "TicketScalper",
                table: "Tickets",
                columns: new[] { "Id", "CurrentPrice", "OriginalPrice", "Seat", "ShowId" },
                values: new object[,]
                {
                    { 12, 299m, 129m, "F14", 2 },
                    { 13, 299m, 129m, "G01", 2 },
                    { 14, 299m, 129m, "G02", 2 },
                    { 15, 299m, 129m, "G03", 2 },
                    { 16, 299m, 129m, "G04", 2 },
                    { 7, 99m, 49m, "General Admission", 1 },
                    { 10, 299m, 129m, "F12", 2 },
                    { 9, 299m, 129m, "F11", 2 },
                    { 1, 99m, 49m, "General Admission", 1 },
                    { 2, 99m, 49m, "General Admission", 1 },
                    { 3, 99m, 49m, "General Admission", 1 },
                    { 4, 99m, 49m, "General Admission", 1 },
                    { 5, 99m, 49m, "General Admission", 1 },
                    { 6, 99m, 49m, "General Admission", 1 },
                    { 11, 299m, 129m, "F13", 2 },
                    { 8, 99m, 49m, "General Admission", 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Venues_VenueId",
                schema: "TicketScalper",
                table: "Shows",
                column: "VenueId",
                principalSchema: "TicketScalper",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Shows_ShowId",
                schema: "TicketScalper",
                table: "Tickets",
                column: "ShowId",
                principalSchema: "TicketScalper",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Venues_VenueId",
                schema: "TicketScalper",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Shows_ShowId",
                schema: "TicketScalper",
                table: "Tickets");

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "ActShows",
                keyColumns: new[] { "ActId", "ShowId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "ActShows",
                keyColumns: new[] { "ActId", "ShowId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "ActShows",
                keyColumns: new[] { "ActId", "ShowId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "ActShows",
                keyColumns: new[] { "ActId", "ShowId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Acts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Acts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Acts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Shows",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Venues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "TicketScalper",
                table: "Venues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                schema: "TicketScalper",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                schema: "TicketScalper",
                table: "Shows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Venues_VenueId",
                schema: "TicketScalper",
                table: "Shows",
                column: "VenueId",
                principalSchema: "TicketScalper",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Shows_ShowId",
                schema: "TicketScalper",
                table: "Tickets",
                column: "ShowId",
                principalSchema: "TicketScalper",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
