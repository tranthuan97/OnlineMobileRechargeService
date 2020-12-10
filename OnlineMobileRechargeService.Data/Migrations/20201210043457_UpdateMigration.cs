using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMobileRechargeService.Data.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.AddPrimaryKey(
            //    name: "Transactions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProviderId = table.Column<int>(type: "int", nullable: false),
            //        SimtypeId = table.Column<int>(type: "int", nullable: false),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        VASId = table.Column<int>(type: "int", nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
            //        PaymentCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Transactions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Transactions_AppUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AppUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Transactions_Providers_ProviderId",
            //            column: x => x.ProviderId,
            //            principalTable: "Providers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Transactions_SimTypes_SimtypeId",
            //            column: x => x.SimtypeId,
            //            principalTable: "SimTypes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Transactions_VAS_VASId",
            //            column: x => x.VASId,
            //            principalTable: "VAS",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.AddForeignKey(
        name: "FK_Transactions_SimTypes_SimTypeId",
        table: "Transactions",
        column: "SimTypeId",
         principalTable: "SimTypes",
                        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);



            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SimtypeId",
                table: "Transactions",
                column: "SimtypeId");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfigs");

            migrationBuilder.DropTable(
                name: "CallerTunes");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "CustomerCareNumbers");

            migrationBuilder.DropTable(
                name: "DNDTransactions");

            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "ModeInCategories");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "PBPTransactions");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UserInPlans");

            migrationBuilder.DropTable(
                name: "VASInProviders");

            migrationBuilder.DropTable(
                name: "DNDCategories");

            migrationBuilder.DropTable(
                name: "DNDModes");

            migrationBuilder.DropTable(
                name: "SimTypes");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "VAS");
        }
    }
}
