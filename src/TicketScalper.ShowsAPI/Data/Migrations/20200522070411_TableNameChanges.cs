using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketScalper.ShowsAPI.Migrations
{
    public partial class TableNameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActShow_Acts_ActId",
                table: "ActShow");

            migrationBuilder.DropForeignKey(
                name: "FK_ActShow_Shows_ShowId",
                table: "ActShow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActShow",
                table: "ActShow");

            migrationBuilder.EnsureSchema(
                name: "TicketScalper");

            migrationBuilder.RenameTable(
                name: "Venues",
                newName: "Venues",
                newSchema: "TicketScalper");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Tickets",
                newSchema: "TicketScalper");

            migrationBuilder.RenameTable(
                name: "Shows",
                newName: "Shows",
                newSchema: "TicketScalper");

            migrationBuilder.RenameTable(
                name: "Acts",
                newName: "Acts",
                newSchema: "TicketScalper");

            migrationBuilder.RenameTable(
                name: "ActShow",
                newName: "ActShows",
                newSchema: "TicketScalper");

            migrationBuilder.RenameIndex(
                name: "IX_ActShow_ShowId",
                schema: "TicketScalper",
                table: "ActShows",
                newName: "IX_ActShows_ShowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActShows",
                schema: "TicketScalper",
                table: "ActShows",
                columns: new[] { "ActId", "ShowId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActShows_Acts_ActId",
                schema: "TicketScalper",
                table: "ActShows",
                column: "ActId",
                principalSchema: "TicketScalper",
                principalTable: "Acts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActShows_Shows_ShowId",
                schema: "TicketScalper",
                table: "ActShows",
                column: "ShowId",
                principalSchema: "TicketScalper",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActShows_Acts_ActId",
                schema: "TicketScalper",
                table: "ActShows");

            migrationBuilder.DropForeignKey(
                name: "FK_ActShows_Shows_ShowId",
                schema: "TicketScalper",
                table: "ActShows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActShows",
                schema: "TicketScalper",
                table: "ActShows");

            migrationBuilder.RenameTable(
                name: "Venues",
                schema: "TicketScalper",
                newName: "Venues");

            migrationBuilder.RenameTable(
                name: "Tickets",
                schema: "TicketScalper",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "Shows",
                schema: "TicketScalper",
                newName: "Shows");

            migrationBuilder.RenameTable(
                name: "Acts",
                schema: "TicketScalper",
                newName: "Acts");

            migrationBuilder.RenameTable(
                name: "ActShows",
                schema: "TicketScalper",
                newName: "ActShow");

            migrationBuilder.RenameIndex(
                name: "IX_ActShows_ShowId",
                table: "ActShow",
                newName: "IX_ActShow_ShowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActShow",
                table: "ActShow",
                columns: new[] { "ActId", "ShowId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActShow_Acts_ActId",
                table: "ActShow",
                column: "ActId",
                principalTable: "Acts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActShow_Shows_ShowId",
                table: "ActShow",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
