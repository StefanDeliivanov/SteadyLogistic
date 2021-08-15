using Microsoft.EntityFrameworkCore.Migrations;

namespace SteadyLogistic.Data.Migrations
{
    public partial class AddedManagerFullNameColumnToCompaniesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerFullName",
                table: "Companies",
                type: "nvarchar(41)",
                maxLength: 41,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerFullName",
                table: "Companies");
        }
    }
}
