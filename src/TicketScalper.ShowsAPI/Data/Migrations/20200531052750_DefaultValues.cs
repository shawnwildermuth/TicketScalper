using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketScalper.ShowsAPI.Migrations
{
    public partial class DefaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address_StateProvince",
                schema: "TicketScalper",
                table: "Venues",
                maxLength: 50,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_PostalCode",
                schema: "TicketScalper",
                table: "Venues",
                maxLength: 50,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_Country",
                schema: "TicketScalper",
                table: "Venues",
                maxLength: 50,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_CityTown",
                schema: "TicketScalper",
                table: "Venues",
                maxLength: 50,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_Address3",
                schema: "TicketScalper",
                table: "Venues",
                maxLength: 100,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_Address2",
                schema: "TicketScalper",
                table: "Venues",
                maxLength: 100,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_Address1",
                schema: "TicketScalper",
                table: "Venues",
                maxLength: 100,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OriginalPrice",
                schema: "TicketScalper",
                table: "Tickets",
                type: "decimal(9,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentPrice",
                schema: "TicketScalper",
                table: "Tickets",
                type: "decimal(9,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsGeneralAdmission",
                value: true);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99.99m, 49.99m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99.99m, 49.99m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99.99m, 49.99m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99.99m, 49.99m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99.99m, 49.99m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99.99m, 49.99m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99.99m, 49.99m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99.99m, 49.99m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 9,
                column: "CurrentPrice",
                value: 299.99m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 10,
                column: "CurrentPrice",
                value: 299.99m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 11,
                column: "CurrentPrice",
                value: 299.99m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 12,
                column: "CurrentPrice",
                value: 299.99m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 13,
                column: "CurrentPrice",
                value: 299.99m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 14,
                column: "CurrentPrice",
                value: 299.99m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 15,
                column: "CurrentPrice",
                value: 299.99m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 16,
                column: "CurrentPrice",
                value: 299.99m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Venues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address_Address1", "Address_CityTown", "Address_Country", "Address_PostalCode", "Address_StateProvince" },
                values: new object[] { "123 Peachtree St", "Atlanta", "USA", "30303", "GA" });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Venues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address_Address1", "Address_CityTown", "Address_Country", "Address_PostalCode", "Address_StateProvince" },
                values: new object[] { "123 Euclid Avenue", "Atlanta", "USA", "30307", "GA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address_StateProvince",
                schema: "TicketScalper",
                table: "Venues",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Address_PostalCode",
                schema: "TicketScalper",
                table: "Venues",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Address_Country",
                schema: "TicketScalper",
                table: "Venues",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Address_CityTown",
                schema: "TicketScalper",
                table: "Venues",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Address_Address3",
                schema: "TicketScalper",
                table: "Venues",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Address_Address2",
                schema: "TicketScalper",
                table: "Venues",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Address_Address1",
                schema: "TicketScalper",
                table: "Venues",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "OriginalPrice",
                schema: "TicketScalper",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentPrice",
                schema: "TicketScalper",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)");

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsGeneralAdmission",
                value: true);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99m, 49m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99m, 49m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99m, 49m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99m, 49m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99m, 49m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99m, 49m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99m, 49m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CurrentPrice", "OriginalPrice" },
                values: new object[] { 99m, 49m });

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 9,
                column: "CurrentPrice",
                value: 299m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 10,
                column: "CurrentPrice",
                value: 299m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 11,
                column: "CurrentPrice",
                value: 299m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 12,
                column: "CurrentPrice",
                value: 299m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 13,
                column: "CurrentPrice",
                value: 299m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 14,
                column: "CurrentPrice",
                value: 299m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 15,
                column: "CurrentPrice",
                value: 299m);

            migrationBuilder.UpdateData(
                schema: "TicketScalper",
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 16,
                column: "CurrentPrice",
                value: 299m);
        }
    }
}
