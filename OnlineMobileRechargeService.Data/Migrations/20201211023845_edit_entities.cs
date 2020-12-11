using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMobileRechargeService.Data.Migrations
{
    public partial class edit_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestTransactions_SimTypes_SimtypeId",
                table: "GuestTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_SimTypes_SimtypeId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "SimTypes");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_SimtypeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_GuestTransactions_SimtypeId",
                table: "GuestTransactions");

            migrationBuilder.DropColumn(
                name: "SimtypeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SimtypeId",
                table: "GuestTransactions");

            migrationBuilder.AddColumn<string>(
                name: "Simtype",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Simtype",
                table: "GuestTransactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Simtype",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Simtype",
                table: "GuestTransactions");

            migrationBuilder.AddColumn<int>(
                name: "SimtypeId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SimtypeId",
                table: "GuestTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SimTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SimtypeId",
                table: "Transactions",
                column: "SimtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestTransactions_SimtypeId",
                table: "GuestTransactions",
                column: "SimtypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestTransactions_SimTypes_SimtypeId",
                table: "GuestTransactions",
                column: "SimtypeId",
                principalTable: "SimTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_SimTypes_SimtypeId",
                table: "Transactions",
                column: "SimtypeId",
                principalTable: "SimTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
