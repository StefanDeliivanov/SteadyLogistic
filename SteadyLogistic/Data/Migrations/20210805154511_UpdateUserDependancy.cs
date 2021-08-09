namespace SteadyLogistic.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateUserDependancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SLogisticsUsers_Id",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TrailerTypes",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AddForeignKey(
                name: "FK_SLogisticsUsers_AspNetUsers_Id",
                table: "SLogisticsUsers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SLogisticsUsers_AspNetUsers_Id",
                table: "SLogisticsUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TrailerTypes",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SLogisticsUsers_Id",
                table: "AspNetUsers",
                column: "Id",
                principalTable: "SLogisticsUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}