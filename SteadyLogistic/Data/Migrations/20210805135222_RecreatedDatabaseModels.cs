namespace SteadyLogistic.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RecreatedDatabaseModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Freights_AspNetUsers_UserId",
                table: "Freights");

            migrationBuilder.DropForeignKey(
                name: "FK_Freights_LoadUnloadInfos_LoadingId",
                table: "Freights");

            migrationBuilder.DropForeignKey(
                name: "FK_Freights_LoadUnloadInfos_UnloadingId",
                table: "Freights");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_AspNetUsers_UserId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Trailers_Companies_CompanyId",
                table: "Trailers");

            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_Companies_CompanyId",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Trailers");

            migrationBuilder.DropColumn(
                name: "CargoType",
                table: "Freights");

            migrationBuilder.DropColumn(
                name: "Dimensions",
                table: "Freights");

            migrationBuilder.DropColumn(
                name: "TransportType",
                table: "Freights");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Trucks",
                newName: "FleetId");

            migrationBuilder.RenameIndex(
                name: "IX_Trucks_CompanyId",
                table: "Trucks",
                newName: "IX_Trucks_FleetId");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "Trailers",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Trailers",
                newName: "FleetId");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Trailers",
                newName: "DimensionId");

            migrationBuilder.RenameIndex(
                name: "IX_Trailers_CompanyId",
                table: "Trailers",
                newName: "IX_Trailers_FleetId");

            migrationBuilder.RenameColumn(
                name: "HeadquartersAdress",
                table: "Companies",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "FleetCount",
                table: "Companies",
                newName: "FleetId");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Trucks",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 17000);

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Trailers",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 17000);

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Freights",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CargoSizeId",
                table: "Freights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DimensionId",
                table: "Freights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Countries",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(58)",
                maxLength: 58,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Cities",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "CargoSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dimensions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fleets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fleets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fleets_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SLogisticsUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLogisticsUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SLogisticsUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrailerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailerTypes", x => x.Id);
                });

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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FreightTrailerType_TrailerTypes_TrailerTypesId",
                        column: x => x.TrailerTypesId,
                        principalTable: "TrailerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trailers_DimensionId",
                table: "Trailers",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Trailers_TypeId",
                table: "Trailers",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_CompanyId_UserId",
                table: "Managers",
                columns: new[] { "CompanyId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Freights_CargoSizeId",
                table: "Freights",
                column: "CargoSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Freights_DimensionId",
                table: "Freights",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Code",
                table: "Countries",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Email",
                table: "Companies",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Name",
                table: "Companies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_PhoneNumber",
                table: "Companies",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_VatNumber",
                table: "Companies",
                column: "VatNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_PostCode_CountryId",
                table: "Cities",
                columns: new[] { "PostCode", "CountryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fleets_CompanyId",
                table: "Fleets",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FreightTrailerType_TrailerTypesId",
                table: "FreightTrailerType",
                column: "TrailerTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_SLogisticsUsers_CompanyId",
                table: "SLogisticsUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SLogisticsUsers_Email",
                table: "SLogisticsUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SLogisticsUsers_PhoneNumber",
                table: "SLogisticsUsers",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SLogisticsUsers_Id",
                table: "AspNetUsers",
                column: "Id",
                principalTable: "SLogisticsUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Freights_CargoSizes_CargoSizeId",
                table: "Freights",
                column: "CargoSizeId",
                principalTable: "CargoSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Freights_Dimensions_DimensionId",
                table: "Freights",
                column: "DimensionId",
                principalTable: "Dimensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Freights_LoadUnloadInfos_LoadingId",
                table: "Freights",
                column: "LoadingId",
                principalTable: "LoadUnloadInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Freights_LoadUnloadInfos_UnloadingId",
                table: "Freights",
                column: "UnloadingId",
                principalTable: "LoadUnloadInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trailers_Dimensions_DimensionId",
                table: "Trailers",
                column: "DimensionId",
                principalTable: "Dimensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trailers_Fleets_FleetId",
                table: "Trailers",
                column: "FleetId",
                principalTable: "Fleets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trailers_TrailerTypes_TypeId",
                table: "Trailers",
                column: "TypeId",
                principalTable: "TrailerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_Fleets_FleetId",
                table: "Trucks",
                column: "FleetId",
                principalTable: "Fleets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SLogisticsUsers_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Freights_CargoSizes_CargoSizeId",
                table: "Freights");

            migrationBuilder.DropForeignKey(
                name: "FK_Freights_Dimensions_DimensionId",
                table: "Freights");

            migrationBuilder.DropForeignKey(
                name: "FK_Freights_LoadUnloadInfos_LoadingId",
                table: "Freights");

            migrationBuilder.DropForeignKey(
                name: "FK_Freights_LoadUnloadInfos_UnloadingId",
                table: "Freights");

            migrationBuilder.DropForeignKey(
                name: "FK_Freights_SLogisticsUsers_UserId",
                table: "Freights");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_SLogisticsUsers_UserId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Trailers_Dimensions_DimensionId",
                table: "Trailers");

            migrationBuilder.DropForeignKey(
                name: "FK_Trailers_Fleets_FleetId",
                table: "Trailers");

            migrationBuilder.DropForeignKey(
                name: "FK_Trailers_TrailerTypes_TypeId",
                table: "Trailers");

            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_Fleets_FleetId",
                table: "Trucks");

            migrationBuilder.DropTable(
                name: "CargoSizes");

            migrationBuilder.DropTable(
                name: "Dimensions");

            migrationBuilder.DropTable(
                name: "Fleets");

            migrationBuilder.DropTable(
                name: "FreightTrailerType");

            migrationBuilder.DropTable(
                name: "SLogisticsUsers");

            migrationBuilder.DropTable(
                name: "TrailerTypes");

            migrationBuilder.DropIndex(
                name: "IX_Trailers_DimensionId",
                table: "Trailers");

            migrationBuilder.DropIndex(
                name: "IX_Trailers_TypeId",
                table: "Trailers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_CompanyId_UserId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Freights_CargoSizeId",
                table: "Freights");

            migrationBuilder.DropIndex(
                name: "IX_Freights_DimensionId",
                table: "Freights");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Code",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Name",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Email",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Name",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_PhoneNumber",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_VatNumber",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Cities_PostCode_CountryId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CargoSizeId",
                table: "Freights");

            migrationBuilder.DropColumn(
                name: "DimensionId",
                table: "Freights");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "FleetId",
                table: "Trucks",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Trucks_FleetId",
                table: "Trucks",
                newName: "IX_Trucks_CompanyId");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Trailers",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "FleetId",
                table: "Trailers",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "DimensionId",
                table: "Trailers",
                newName: "Capacity");

            migrationBuilder.RenameIndex(
                name: "IX_Trailers_FleetId",
                table: "Trailers",
                newName: "IX_Trailers_CompanyId");

            migrationBuilder.RenameColumn(
                name: "FleetId",
                table: "Companies",
                newName: "FleetCount");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Companies",
                newName: "HeadquartersAdress");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Trucks",
                type: "int",
                maxLength: 17000,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Trailers",
                type: "int",
                maxLength: 17000,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Trailers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Freights",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "CargoType",
                table: "Freights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Dimensions",
                table: "Freights",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TransportType",
                table: "Freights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(56)",
                oldMaxLength: 56);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Companies",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(58)",
                oldMaxLength: 58);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Freights_AspNetUsers_UserId",
                table: "Freights",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Freights_LoadUnloadInfos_LoadingId",
                table: "Freights",
                column: "LoadingId",
                principalTable: "LoadUnloadInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Freights_LoadUnloadInfos_UnloadingId",
                table: "Freights",
                column: "UnloadingId",
                principalTable: "LoadUnloadInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_AspNetUsers_UserId",
                table: "Managers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trailers_Companies_CompanyId",
                table: "Trailers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_Companies_CompanyId",
                table: "Trucks",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}