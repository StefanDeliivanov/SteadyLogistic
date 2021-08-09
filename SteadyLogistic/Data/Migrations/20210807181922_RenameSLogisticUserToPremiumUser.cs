namespace SteadyLogistic.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RenameSLogisticUserToPremiumUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Freights_SLogisticsUsers_UserId",
                table: "Freights");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_SLogisticsUsers_UserId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_SLogisticsUsers_AspNetUsers_Id",
                table: "SLogisticsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SLogisticsUsers_Companies_CompanyId",
                table: "SLogisticsUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SLogisticsUsers",
                table: "SLogisticsUsers");

            migrationBuilder.RenameTable(
                name: "SLogisticsUsers",
                newName: "PremiumUsers");

            migrationBuilder.RenameIndex(
                name: "IX_SLogisticsUsers_PhoneNumber",
                table: "PremiumUsers",
                newName: "IX_PremiumUsers_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_SLogisticsUsers_Email",
                table: "PremiumUsers",
                newName: "IX_PremiumUsers_Email");

            migrationBuilder.RenameIndex(
                name: "IX_SLogisticsUsers_CompanyId",
                table: "PremiumUsers",
                newName: "IX_PremiumUsers_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PremiumUsers",
                table: "PremiumUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Freights_PremiumUsers_UserId",
                table: "Freights",
                column: "UserId",
                principalTable: "PremiumUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_PremiumUsers_UserId",
                table: "Managers",
                column: "UserId",
                principalTable: "PremiumUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PremiumUsers_AspNetUsers_Id",
                table: "PremiumUsers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PremiumUsers_Companies_CompanyId",
                table: "PremiumUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Freights_PremiumUsers_UserId",
                table: "Freights");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_PremiumUsers_UserId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_PremiumUsers_AspNetUsers_Id",
                table: "PremiumUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PremiumUsers_Companies_CompanyId",
                table: "PremiumUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PremiumUsers",
                table: "PremiumUsers");

            migrationBuilder.RenameTable(
                name: "PremiumUsers",
                newName: "SLogisticsUsers");

            migrationBuilder.RenameIndex(
                name: "IX_PremiumUsers_PhoneNumber",
                table: "SLogisticsUsers",
                newName: "IX_SLogisticsUsers_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_PremiumUsers_Email",
                table: "SLogisticsUsers",
                newName: "IX_SLogisticsUsers_Email");

            migrationBuilder.RenameIndex(
                name: "IX_PremiumUsers_CompanyId",
                table: "SLogisticsUsers",
                newName: "IX_SLogisticsUsers_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SLogisticsUsers",
                table: "SLogisticsUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Freights_SLogisticsUsers_UserId",
                table: "Freights",
                column: "UserId",
                principalTable: "SLogisticsUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_SLogisticsUsers_UserId",
                table: "Managers",
                column: "UserId",
                principalTable: "SLogisticsUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SLogisticsUsers_AspNetUsers_Id",
                table: "SLogisticsUsers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SLogisticsUsers_Companies_CompanyId",
                table: "SLogisticsUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}