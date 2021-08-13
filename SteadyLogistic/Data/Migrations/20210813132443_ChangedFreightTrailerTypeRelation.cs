namespace SteadyLogistic.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangedFreightTrailerTypeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreightTrailerType");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "PremiumUsers",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Messages",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "TrailerTypeId",
                table: "Freights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Companies",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Freights_TrailerTypeId",
                table: "Freights",
                column: "TrailerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Freights_TrailerTypes_TrailerTypeId",
                table: "Freights",
                column: "TrailerTypeId",
                principalTable: "TrailerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Freights_TrailerTypes_TrailerTypeId",
                table: "Freights");

            migrationBuilder.DropIndex(
                name: "IX_Freights_TrailerTypeId",
                table: "Freights");

            migrationBuilder.DropColumn(
                name: "TrailerTypeId",
                table: "Freights");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "PremiumUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Messages",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45);

            migrationBuilder.CreateTable(
                name: "FreightTrailerType",
                columns: table => new
                {
                    FreightsId = table.Column<int>(type: "int", nullable: false),
                    TrailerTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreightTrailerType", x => new { x.FreightsId, x.TrailerTypesId });
                    table.ForeignKey(
                        name: "FK_FreightTrailerType_Freights_FreightsId",
                        column: x => x.FreightsId,
                        principalTable: "Freights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreightTrailerType_TrailerTypes_TrailerTypesId",
                        column: x => x.TrailerTypesId,
                        principalTable: "TrailerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FreightTrailerType_TrailerTypesId",
                table: "FreightTrailerType",
                column: "TrailerTypesId");
        }
    }
}