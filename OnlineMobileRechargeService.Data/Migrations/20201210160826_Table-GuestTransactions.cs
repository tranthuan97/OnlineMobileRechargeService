using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMobileRechargeService.Data.Migrations
{
    public partial class TableGuestTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuestTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    SimtypeId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestTransactions_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestTransactions_SimTypes_SimtypeId",
                        column: x => x.SimtypeId,
                        principalTable: "SimTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestTransactions_PlanId",
                table: "GuestTransactions",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestTransactions_SimtypeId",
                table: "GuestTransactions",
                column: "SimtypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestTransactions");
        }
    }
}
