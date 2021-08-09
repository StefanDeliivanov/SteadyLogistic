﻿namespace SteadyLogistic.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    [DbContext(typeof(SteadyLogisticDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FreightTrailerType", b =>
                {
                    b.Property<int>("FreightsId")
                        .HasColumnType("int");

                    b.Property<int>("TrailerTypesId")
                        .HasColumnType("int");

                    b.HasKey("FreightsId", "TrailerTypesId");

                    b.HasIndex("TrailerTypesId");

                    b.ToTable("FreightTrailerType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.CargoSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("Id");

                    b.ToTable("CargoSizes");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(58)
                        .HasColumnType("nvarchar(58)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("PostCode", "Name", "CountryId")
                        .IsUnique();

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FleetId")
                        .HasColumnType("int");

                    b.Property<string>("ManagerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("VatNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("VatNumber")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Dimension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Dimensions");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Fleet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.ToTable("Fleets");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Freight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CargoSizeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DimensionId")
                        .HasColumnType("int");

                    b.Property<int>("LoadingId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnloadingId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CargoSizeId");

                    b.HasIndex("DimensionId");

                    b.HasIndex("LoadingId");

                    b.HasIndex("UnloadingId");

                    b.HasIndex("UserId");

                    b.ToTable("Freights");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.LoadUnloadInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("LoadUnloadInfos");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.PremiumUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("PremiumUsers");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Trailer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("DimensionId")
                        .HasColumnType("int");

                    b.Property<int>("FleetId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DimensionId");

                    b.HasIndex("FleetId");

                    b.HasIndex("TypeId");

                    b.ToTable("Trailers");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.TrailerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("TrailerTypes");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("FleetId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FleetId");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FreightTrailerType", b =>
                {
                    b.HasOne("SteadyLogistic.Data.Models.Freight", null)
                        .WithMany()
                        .HasForeignKey("FreightsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SteadyLogistic.Data.Models.TrailerType", null)
                        .WithMany()
                        .HasForeignKey("TrailerTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SteadyLogistic.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SteadyLogistic.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SteadyLogistic.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SteadyLogistic.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.City", b =>
                {
                    b.HasOne("SteadyLogistic.Data.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Company", b =>
                {
                    b.HasOne("SteadyLogistic.Data.Models.City", "City")
                        .WithMany("Companies")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SteadyLogistic.Data.Models.Country", "Country")
                        .WithMany("Companies")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Fleet", b =>
                {
                    b.HasOne("SteadyLogistic.Data.Models.Company", "Company")
                        .WithOne("Fleet")
                        .HasForeignKey("SteadyLogistic.Data.Models.Fleet", "CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Freight", b =>
                {
                    b.HasOne("SteadyLogistic.Data.Models.CargoSize", "CargoSize")
                        .WithMany("Freights")
                        .HasForeignKey("CargoSizeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SteadyLogistic.Data.Models.Dimension", "Dimension")
                        .WithMany("Freights")
                        .HasForeignKey("DimensionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SteadyLogistic.Data.Models.LoadUnloadInfo", "Loading")
                        .WithMany("Loadings")
                        .HasForeignKey("LoadingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SteadyLogistic.Data.Models.LoadUnloadInfo", "Unloading")
                        .WithMany("Unloadings")
                        .HasForeignKey("UnloadingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SteadyLogistic.Data.Models.PremiumUser", "User")
                        .WithMany("Freights")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CargoSize");

                    b.Navigation("Dimension");

                    b.Navigation("Loading");

                    b.Navigation("Unloading");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.LoadUnloadInfo", b =>
                {
                    b.HasOne("SteadyLogistic.Data.Models.City", "City")
                        .WithMany("LoadUnloadings")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SteadyLogistic.Data.Models.Country", "Country")
                        .WithMany("LoadUnloadings")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.PremiumUser", b =>
                {
                    b.HasOne("SteadyLogistic.Data.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SteadyLogistic.Data.Models.User", null)
                        .WithOne()
                        .HasForeignKey("SteadyLogistic.Data.Models.PremiumUser", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Trailer", b =>
                {
                    b.HasOne("SteadyLogistic.Data.Models.Dimension", "Dimension")
                        .WithMany("Trailers")
                        .HasForeignKey("DimensionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SteadyLogistic.Data.Models.Fleet", "Fleet")
                        .WithMany("Trailers")
                        .HasForeignKey("FleetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SteadyLogistic.Data.Models.TrailerType", "Type")
                        .WithMany("Trailers")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dimension");

                    b.Navigation("Fleet");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Truck", b =>
                {
                    b.HasOne("SteadyLogistic.Data.Models.Fleet", "Fleet")
                        .WithMany("Trucks")
                        .HasForeignKey("FleetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fleet");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.CargoSize", b =>
                {
                    b.Navigation("Freights");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.City", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("LoadUnloadings");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Company", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Fleet");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Country", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Companies");

                    b.Navigation("LoadUnloadings");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Dimension", b =>
                {
                    b.Navigation("Freights");

                    b.Navigation("Trailers");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.Fleet", b =>
                {
                    b.Navigation("Trailers");

                    b.Navigation("Trucks");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.LoadUnloadInfo", b =>
                {
                    b.Navigation("Loadings");

                    b.Navigation("Unloadings");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.PremiumUser", b =>
                {
                    b.Navigation("Freights");
                });

            modelBuilder.Entity("SteadyLogistic.Data.Models.TrailerType", b =>
                {
                    b.Navigation("Trailers");
                });
#pragma warning restore 612, 618
        }
    }
}