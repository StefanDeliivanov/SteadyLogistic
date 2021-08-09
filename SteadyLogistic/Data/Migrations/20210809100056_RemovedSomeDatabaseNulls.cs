namespace SteadyLogistic.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemovedSomeDatabaseNulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_PremiumUsers_UserId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_CompanyId_UserId",
                table: "Managers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Managers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_CompanyId_UserId",
                table: "Managers",
                columns: new[] { "CompanyId", "UserId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_PremiumUsers_UserId",
                table: "Managers",
                column: "UserId",
                principalTable: "PremiumUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_PremiumUsers_UserId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_CompanyId_UserId",
                table: "Managers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Managers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_CompanyId_UserId",
                table: "Managers",
                columns: new[] { "CompanyId", "UserId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_PremiumUsers_UserId",
                table: "Managers",
                column: "UserId",
                principalTable: "PremiumUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}