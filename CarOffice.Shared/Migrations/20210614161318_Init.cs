﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarOffice.Shared.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    Gearbox = table.Column<int>(type: "int", nullable: false),
                    ShowInHome = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(38,0)", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModelYear = table.Column<int>(type: "int", nullable: true),
                    Mileage = table.Column<int>(type: "int", nullable: true),
                    SeatCount = table.Column<int>(type: "int", nullable: true),
                    WeightTotal = table.Column<decimal>(type: "decimal(38,0)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CarExtras = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("f33e24f3-6f12-4c50-bc38-2adfdca5503f"), new DateTime(2021, 6, 14, 19, 13, 17, 754, DateTimeKind.Local).AddTicks(5326), "Acura" },
                    { new Guid("97892b93-c9fd-4b85-aaae-fc059781fedf"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1795), "Mazda" },
                    { new Guid("e3171484-e982-43fc-8351-1e5230b4c7b2"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1853), "Mercedes-Benz" },
                    { new Guid("7f548d60-e1a6-4872-85ad-4eb518971f81"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1912), "Mercury" },
                    { new Guid("8215deb1-795e-4834-a6b9-abe513b96844"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1972), "Mini" },
                    { new Guid("9b0080fc-3ae6-4918-9198-789889ddb929"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2132), "Mitsubishi" },
                    { new Guid("b7b9aeb4-80d6-451a-978f-df2a0155d9e0"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2194), "Nikola" },
                    { new Guid("aa99fa44-2d4a-478c-a97d-bbae4213289d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2252), "Nissan" },
                    { new Guid("4d157823-7743-426a-97d6-4080f7553f63"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2313), "Polestar" },
                    { new Guid("1fddbfc1-d6c6-4096-a8f3-b9650304344f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2407), "Pontiac" },
                    { new Guid("d2bbdee9-055c-4e63-8343-b6bb5b89c7d2"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1734), "Maserati" },
                    { new Guid("8661494f-aade-4bcf-bc89-da977e17b50a"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2466), "Porsche" },
                    { new Guid("ec934d2c-cd37-4ec1-82bf-af24ecddb2af"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2584), "Rivian" },
                    { new Guid("9888e8ec-82b6-41de-a663-9103391cc2b6"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2643), "Rolls-Royce" },
                    { new Guid("adeeba6c-0f7d-4e86-a488-d61c9a1db94d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2736), "Saab" },
                    { new Guid("9fb687eb-20c8-436d-a6d1-4256cab0effa"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2796), "Scion" },
                    { new Guid("f3f4849b-1910-43bb-927f-f7aad4a61ff6"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2855), "Smart" },
                    { new Guid("02a78dbc-6f8d-4cc8-8559-90c18e3356f1"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2914), "Subaru" },
                    { new Guid("5b68a92e-caae-4887-bcbf-18a07a4b74ec"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2999), "Suzuki" },
                    { new Guid("f6ad4ee8-5880-4496-9534-19d058af5257"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3064), "Tesla" },
                    { new Guid("6b17cf62-8a05-4fbc-a514-4d095e77d31e"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3124), "Toyota" },
                    { new Guid("d6d3d1bf-d53e-4d6a-aef6-9e9e3ea3177f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2525), "Ram" },
                    { new Guid("cc51f122-8211-4ff5-aaf5-bb5d6d297b1b"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3217), "Volkswagen" },
                    { new Guid("1a328f77-6299-449a-8bc7-8ff6287f9b3c"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1647), "Lotus" },
                    { new Guid("9d4f8863-8a72-4e13-bc95-6ced652daea0"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1524), "Lexus" },
                    { new Guid("1edfef84-a6b6-48a9-9155-a70947e1db92"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local), "Alfa Romeo" },
                    { new Guid("d2cbdd72-bbb9-41e2-9f07-f0869521e70f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(141), "Audi" },
                    { new Guid("a55537a7-9d83-40c3-a0fc-c09729e410d4"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(265), "Bentley" },
                    { new Guid("5262dfe0-d4b3-47f8-b05e-9f09393ea2c9"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(326), "Buick" },
                    { new Guid("848e8cb4-727d-4e8a-928d-f0f37a50bd14"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(390), "BMW" },
                    { new Guid("1bcd907c-d849-4a5e-a59b-1aba88f4dcdf"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(455), "Cadillac" },
                    { new Guid("d6017ac1-3a3c-44c8-aa55-96f0f5b474e9"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(547), "Chevrolet" },
                    { new Guid("67fef7e2-3376-40a7-938a-505813cad025"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(611), "Chrysler" },
                    { new Guid("79f43907-0dbf-4779-9c74-6c132560c381"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(717), "Dodge" },
                    { new Guid("b701908e-5061-4807-a1f4-e193f86d56be"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1587), "Lincoln" },
                    { new Guid("48392d6c-ced5-4d84-afd2-89df3567fdec"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(777), "Fiat" },
                    { new Guid("7303600d-0a04-4cc9-ac15-4ef0d1fe795a"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(926), "GMC" },
                    { new Guid("13aee88a-e5ea-497c-a919-76df8094c752"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(985), "Genesis" },
                    { new Guid("cb353a94-441d-4b42-9a7b-04fe0b8fe59d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1047), "Honda" },
                    { new Guid("566f99be-75ea-44ac-a0b9-bf067b82dbd3"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1106), "Hyundai" },
                    { new Guid("ffd9866a-8463-4c7f-8bcf-52c46000eac1"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1195), "Infiniti" },
                    { new Guid("de350184-9b44-4272-9e7f-2245819858a7"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1258), "Jaguar" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("a22a51c9-2891-4303-99b3-41a0764c266c"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1317), "Jeep" },
                    { new Guid("89bd71e9-f440-456e-b083-2b0d9cba1ddb"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1376), "Kia" },
                    { new Guid("0fb2e4e8-d683-4db5-a516-54c6752b9353"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1462), "Land Rover" },
                    { new Guid("4358d45b-7525-4302-aede-aa65c9c5a7ba"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(865), "Ford" },
                    { new Guid("1d7bdf97-9519-4898-9d9f-3baa461f0908"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3278), "Volvo" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "CarExtras", "Color", "CreatedAt", "Description", "FuelType", "Gearbox", "Mileage", "ModelYear", "Price", "SeatCount", "ShowInHome", "Status", "Type", "WeightTotal" },
                values: new object[,]
                {
                    { new Guid("f33e24f3-6f12-4c50-bc38-2adfdca5503f"), new Guid("f33e24f3-6f12-4c50-bc38-2adfdca5503f"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 756, DateTimeKind.Local).AddTicks(4304), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("97892b93-c9fd-4b85-aaae-fc059781fedf"), new Guid("97892b93-c9fd-4b85-aaae-fc059781fedf"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1810), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("e3171484-e982-43fc-8351-1e5230b4c7b2"), new Guid("e3171484-e982-43fc-8351-1e5230b4c7b2"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1868), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("7f548d60-e1a6-4872-85ad-4eb518971f81"), new Guid("7f548d60-e1a6-4872-85ad-4eb518971f81"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1927), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("8215deb1-795e-4834-a6b9-abe513b96844"), new Guid("8215deb1-795e-4834-a6b9-abe513b96844"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2081), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("9b0080fc-3ae6-4918-9198-789889ddb929"), new Guid("9b0080fc-3ae6-4918-9198-789889ddb929"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2150), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("b7b9aeb4-80d6-451a-978f-df2a0155d9e0"), new Guid("b7b9aeb4-80d6-451a-978f-df2a0155d9e0"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2209), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("aa99fa44-2d4a-478c-a97d-bbae4213289d"), new Guid("aa99fa44-2d4a-478c-a97d-bbae4213289d"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2269), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("4d157823-7743-426a-97d6-4080f7553f63"), new Guid("4d157823-7743-426a-97d6-4080f7553f63"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2330), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("1fddbfc1-d6c6-4096-a8f3-b9650304344f"), new Guid("1fddbfc1-d6c6-4096-a8f3-b9650304344f"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2422), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("d2bbdee9-055c-4e63-8343-b6bb5b89c7d2"), new Guid("d2bbdee9-055c-4e63-8343-b6bb5b89c7d2"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1750), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("8661494f-aade-4bcf-bc89-da977e17b50a"), new Guid("8661494f-aade-4bcf-bc89-da977e17b50a"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2481), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("ec934d2c-cd37-4ec1-82bf-af24ecddb2af"), new Guid("ec934d2c-cd37-4ec1-82bf-af24ecddb2af"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2599), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("9888e8ec-82b6-41de-a663-9103391cc2b6"), new Guid("9888e8ec-82b6-41de-a663-9103391cc2b6"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2690), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("adeeba6c-0f7d-4e86-a488-d61c9a1db94d"), new Guid("adeeba6c-0f7d-4e86-a488-d61c9a1db94d"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2752), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("9fb687eb-20c8-436d-a6d1-4256cab0effa"), new Guid("9fb687eb-20c8-436d-a6d1-4256cab0effa"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2811), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("f3f4849b-1910-43bb-927f-f7aad4a61ff6"), new Guid("f3f4849b-1910-43bb-927f-f7aad4a61ff6"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2870), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("02a78dbc-6f8d-4cc8-8559-90c18e3356f1"), new Guid("02a78dbc-6f8d-4cc8-8559-90c18e3356f1"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2930), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("5b68a92e-caae-4887-bcbf-18a07a4b74ec"), new Guid("5b68a92e-caae-4887-bcbf-18a07a4b74ec"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3017), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("f6ad4ee8-5880-4496-9534-19d058af5257"), new Guid("f6ad4ee8-5880-4496-9534-19d058af5257"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3079), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("6b17cf62-8a05-4fbc-a514-4d095e77d31e"), new Guid("6b17cf62-8a05-4fbc-a514-4d095e77d31e"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3170), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("d6d3d1bf-d53e-4d6a-aef6-9e9e3ea3177f"), new Guid("d6d3d1bf-d53e-4d6a-aef6-9e9e3ea3177f"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2540), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("cc51f122-8211-4ff5-aaf5-bb5d6d297b1b"), new Guid("cc51f122-8211-4ff5-aaf5-bb5d6d297b1b"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3235), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("1a328f77-6299-449a-8bc7-8ff6287f9b3c"), new Guid("1a328f77-6299-449a-8bc7-8ff6287f9b3c"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1662), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("9d4f8863-8a72-4e13-bc95-6ced652daea0"), new Guid("9d4f8863-8a72-4e13-bc95-6ced652daea0"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1541), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("1edfef84-a6b6-48a9-9155-a70947e1db92"), new Guid("1edfef84-a6b6-48a9-9155-a70947e1db92"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(80), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("d2cbdd72-bbb9-41e2-9f07-f0869521e70f"), new Guid("d2cbdd72-bbb9-41e2-9f07-f0869521e70f"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(158), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("a55537a7-9d83-40c3-a0fc-c09729e410d4"), new Guid("a55537a7-9d83-40c3-a0fc-c09729e410d4"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(281), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("5262dfe0-d4b3-47f8-b05e-9f09393ea2c9"), new Guid("5262dfe0-d4b3-47f8-b05e-9f09393ea2c9"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(344), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("848e8cb4-727d-4e8a-928d-f0f37a50bd14"), new Guid("848e8cb4-727d-4e8a-928d-f0f37a50bd14"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(408), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("1bcd907c-d849-4a5e-a59b-1aba88f4dcdf"), new Guid("1bcd907c-d849-4a5e-a59b-1aba88f4dcdf"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(471), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("d6017ac1-3a3c-44c8-aa55-96f0f5b474e9"), new Guid("d6017ac1-3a3c-44c8-aa55-96f0f5b474e9"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(564), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("67fef7e2-3376-40a7-938a-505813cad025"), new Guid("67fef7e2-3376-40a7-938a-505813cad025"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(627), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("79f43907-0dbf-4779-9c74-6c132560c381"), new Guid("79f43907-0dbf-4779-9c74-6c132560c381"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(733), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("b701908e-5061-4807-a1f4-e193f86d56be"), new Guid("b701908e-5061-4807-a1f4-e193f86d56be"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1602), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("48392d6c-ced5-4d84-afd2-89df3567fdec"), new Guid("48392d6c-ced5-4d84-afd2-89df3567fdec"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(792), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("7303600d-0a04-4cc9-ac15-4ef0d1fe795a"), new Guid("7303600d-0a04-4cc9-ac15-4ef0d1fe795a"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(942), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("13aee88a-e5ea-497c-a919-76df8094c752"), new Guid("13aee88a-e5ea-497c-a919-76df8094c752"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1003), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("cb353a94-441d-4b42-9a7b-04fe0b8fe59d"), new Guid("cb353a94-441d-4b42-9a7b-04fe0b8fe59d"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1062), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("566f99be-75ea-44ac-a0b9-bf067b82dbd3"), new Guid("566f99be-75ea-44ac-a0b9-bf067b82dbd3"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1122), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("ffd9866a-8463-4c7f-8bcf-52c46000eac1"), new Guid("ffd9866a-8463-4c7f-8bcf-52c46000eac1"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1212), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("de350184-9b44-4272-9e7f-2245819858a7"), new Guid("de350184-9b44-4272-9e7f-2245819858a7"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1274), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "CarExtras", "Color", "CreatedAt", "Description", "FuelType", "Gearbox", "Mileage", "ModelYear", "Price", "SeatCount", "ShowInHome", "Status", "Type", "WeightTotal" },
                values: new object[,]
                {
                    { new Guid("a22a51c9-2891-4303-99b3-41a0764c266c"), new Guid("a22a51c9-2891-4303-99b3-41a0764c266c"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1333), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("89bd71e9-f440-456e-b083-2b0d9cba1ddb"), new Guid("89bd71e9-f440-456e-b083-2b0d9cba1ddb"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1392), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("0fb2e4e8-d683-4db5-a516-54c6752b9353"), new Guid("0fb2e4e8-d683-4db5-a516-54c6752b9353"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1479), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("4358d45b-7525-4302-aede-aa65c9c5a7ba"), new Guid("4358d45b-7525-4302-aede-aa65c9c5a7ba"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(881), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("1d7bdf97-9519-4898-9d9f-3baa461f0908"), new Guid("1d7bdf97-9519-4898-9d9f-3baa461f0908"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3293), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("1c445f49-f9d3-4978-8e12-6a691d2c971f"), new Guid("f33e24f3-6f12-4c50-bc38-2adfdca5503f"), new DateTime(2021, 6, 14, 19, 13, 17, 756, DateTimeKind.Local).AddTicks(9223), "product-1-720x480.jpg" },
                    { new Guid("32e840b7-a82f-4f65-b633-3003ac18c127"), new Guid("9b0080fc-3ae6-4918-9198-789889ddb929"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2174), "product-5-720x480.jpg" },
                    { new Guid("20b8d598-8ab3-4201-925b-55b44d7d5e1a"), new Guid("9b0080fc-3ae6-4918-9198-789889ddb929"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2176), "product-6-720x480.jpg" },
                    { new Guid("84ce0edd-18e2-45ef-bc54-130057a3a6aa"), new Guid("b7b9aeb4-80d6-451a-978f-df2a0155d9e0"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2225), "product-1-720x480.jpg" },
                    { new Guid("e465ef31-dce3-4af5-b1c5-6496aeda9846"), new Guid("b7b9aeb4-80d6-451a-978f-df2a0155d9e0"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2227), "product-2-720x480.jpg" },
                    { new Guid("88cbcad8-cd08-4592-8c6a-ee99ffb7d598"), new Guid("b7b9aeb4-80d6-451a-978f-df2a0155d9e0"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2229), "product-3-720x480.jpg" },
                    { new Guid("8f3d3024-5569-4c70-a5cf-51da869e7b97"), new Guid("b7b9aeb4-80d6-451a-978f-df2a0155d9e0"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2231), "product-4-720x480.jpg" },
                    { new Guid("64adef92-adb1-4842-9be2-a9e500a4f078"), new Guid("b7b9aeb4-80d6-451a-978f-df2a0155d9e0"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2233), "product-5-720x480.jpg" },
                    { new Guid("5521dfd7-0677-4c2b-bd69-100d262996a3"), new Guid("b7b9aeb4-80d6-451a-978f-df2a0155d9e0"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2235), "product-6-720x480.jpg" },
                    { new Guid("96eb20c5-9cef-4c04-8890-dfffb49c96ab"), new Guid("aa99fa44-2d4a-478c-a97d-bbae4213289d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2285), "product-1-720x480.jpg" },
                    { new Guid("4bb2f37e-d9d9-432a-8ddc-ffe377037202"), new Guid("aa99fa44-2d4a-478c-a97d-bbae4213289d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2287), "product-2-720x480.jpg" },
                    { new Guid("24cca7f8-a465-4688-82c7-1f697ffa384d"), new Guid("aa99fa44-2d4a-478c-a97d-bbae4213289d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2290), "product-3-720x480.jpg" },
                    { new Guid("e56d7b76-09dd-4187-82e9-7f887cb1096c"), new Guid("aa99fa44-2d4a-478c-a97d-bbae4213289d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2291), "product-4-720x480.jpg" },
                    { new Guid("b6069d47-032f-4526-84c6-7eab1dbf307e"), new Guid("aa99fa44-2d4a-478c-a97d-bbae4213289d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2293), "product-5-720x480.jpg" },
                    { new Guid("85db2908-6a7a-4e63-94e3-683cbc82e646"), new Guid("aa99fa44-2d4a-478c-a97d-bbae4213289d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2297), "product-6-720x480.jpg" },
                    { new Guid("e9aa88cf-f1b6-43ff-9b84-f641c5d64d9f"), new Guid("4d157823-7743-426a-97d6-4080f7553f63"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2378), "product-1-720x480.jpg" },
                    { new Guid("ea021c67-0e8f-427d-8602-36383bcbd456"), new Guid("4d157823-7743-426a-97d6-4080f7553f63"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2381), "product-2-720x480.jpg" },
                    { new Guid("d79799e0-cbc2-4414-904d-4391e982d33b"), new Guid("4d157823-7743-426a-97d6-4080f7553f63"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2382), "product-3-720x480.jpg" },
                    { new Guid("fa7f8d1d-258f-4a25-a748-94b0eeee2afe"), new Guid("8661494f-aade-4bcf-bc89-da977e17b50a"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2507), "product-5-720x480.jpg" },
                    { new Guid("674f6a86-d4c4-4c04-9449-1417dfd5884c"), new Guid("8661494f-aade-4bcf-bc89-da977e17b50a"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2505), "product-4-720x480.jpg" },
                    { new Guid("fe268d91-009b-4731-99b5-d25cbc69877c"), new Guid("8661494f-aade-4bcf-bc89-da977e17b50a"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2503), "product-3-720x480.jpg" },
                    { new Guid("bab23409-e0d6-401c-b0ba-4e81644a99e5"), new Guid("8661494f-aade-4bcf-bc89-da977e17b50a"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2499), "product-2-720x480.jpg" },
                    { new Guid("2d4c8c9f-1ad9-46e8-8959-7e57dcbdf9b9"), new Guid("8661494f-aade-4bcf-bc89-da977e17b50a"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2497), "product-1-720x480.jpg" },
                    { new Guid("74540808-ed0d-4d28-a9be-d2a7ee6f5cb2"), new Guid("1fddbfc1-d6c6-4096-a8f3-b9650304344f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2450), "product-6-720x480.jpg" },
                    { new Guid("9a762a28-35d6-44a7-b8dd-0e476896f55f"), new Guid("9b0080fc-3ae6-4918-9198-789889ddb929"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2172), "product-4-720x480.jpg" },
                    { new Guid("0582b1df-4915-4e34-84a3-6764cc53c323"), new Guid("1fddbfc1-d6c6-4096-a8f3-b9650304344f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2448), "product-5-720x480.jpg" },
                    { new Guid("b1710dd7-f473-490a-836e-4caa34fd2d70"), new Guid("1fddbfc1-d6c6-4096-a8f3-b9650304344f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2443), "product-3-720x480.jpg" },
                    { new Guid("a1264230-f582-401e-b6aa-0234fed145f8"), new Guid("1fddbfc1-d6c6-4096-a8f3-b9650304344f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2441), "product-2-720x480.jpg" },
                    { new Guid("d2261f9d-0ab0-4dc8-ac1b-12b656a45775"), new Guid("1fddbfc1-d6c6-4096-a8f3-b9650304344f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2439), "product-1-720x480.jpg" },
                    { new Guid("69fa66e8-1a8f-47cc-ba96-cd05c99ace7e"), new Guid("4d157823-7743-426a-97d6-4080f7553f63"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2390), "product-6-720x480.jpg" },
                    { new Guid("7bcca15f-a7aa-49b9-bd97-0723bb7c74d9"), new Guid("4d157823-7743-426a-97d6-4080f7553f63"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2388), "product-5-720x480.jpg" },
                    { new Guid("ebe3b259-fa9a-4339-9f96-368975e1a6b0"), new Guid("4d157823-7743-426a-97d6-4080f7553f63"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2384), "product-4-720x480.jpg" },
                    { new Guid("0bec91a6-94aa-482a-8ac1-5a7268b526ba"), new Guid("1fddbfc1-d6c6-4096-a8f3-b9650304344f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2447), "product-4-720x480.jpg" },
                    { new Guid("924f7d55-1cdf-4f17-a5c8-56daadade95a"), new Guid("8661494f-aade-4bcf-bc89-da977e17b50a"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2509), "product-6-720x480.jpg" },
                    { new Guid("ec436983-86aa-4ef9-bdab-31f6e258441a"), new Guid("9b0080fc-3ae6-4918-9198-789889ddb929"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2170), "product-3-720x480.jpg" },
                    { new Guid("a3a9a432-c51b-4ab9-b0fc-29987be14ed9"), new Guid("9b0080fc-3ae6-4918-9198-789889ddb929"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2167), "product-1-720x480.jpg" },
                    { new Guid("2d20bfa0-f725-421e-9eda-afbb69fa5d6a"), new Guid("1a328f77-6299-449a-8bc7-8ff6287f9b3c"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1717), "product-6-720x480.jpg" },
                    { new Guid("c74bb3f6-f35f-4603-b234-80fb2236fd38"), new Guid("d2bbdee9-055c-4e63-8343-b6bb5b89c7d2"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1767), "product-1-720x480.jpg" },
                    { new Guid("457f2735-1b35-4562-a0be-34499cd6be4d"), new Guid("d2bbdee9-055c-4e63-8343-b6bb5b89c7d2"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1769), "product-2-720x480.jpg" },
                    { new Guid("ad73b1e9-b145-4325-8edc-75d116a95742"), new Guid("d2bbdee9-055c-4e63-8343-b6bb5b89c7d2"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1771), "product-3-720x480.jpg" },
                    { new Guid("ccd8f66a-1cda-4335-8c84-6cbbff5851bc"), new Guid("d2bbdee9-055c-4e63-8343-b6bb5b89c7d2"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1773), "product-4-720x480.jpg" },
                    { new Guid("ee67427c-a78b-4039-96d9-3bfbbe2ecfa8"), new Guid("d2bbdee9-055c-4e63-8343-b6bb5b89c7d2"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1777), "product-5-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("14722ba2-441e-497d-9b83-068506b85779"), new Guid("d2bbdee9-055c-4e63-8343-b6bb5b89c7d2"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1779), "product-6-720x480.jpg" },
                    { new Guid("6a2b5d90-4b8e-43b8-9ace-cee64ca08d03"), new Guid("97892b93-c9fd-4b85-aaae-fc059781fedf"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1826), "product-1-720x480.jpg" },
                    { new Guid("75eae2e7-9947-4ae1-863f-e91360d282fd"), new Guid("97892b93-c9fd-4b85-aaae-fc059781fedf"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1828), "product-2-720x480.jpg" },
                    { new Guid("40d0e468-ccf2-41e1-8fee-6561e1bec521"), new Guid("97892b93-c9fd-4b85-aaae-fc059781fedf"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1830), "product-3-720x480.jpg" },
                    { new Guid("9bdc581b-837b-426a-a049-70699d5d158c"), new Guid("97892b93-c9fd-4b85-aaae-fc059781fedf"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1834), "product-4-720x480.jpg" },
                    { new Guid("719928c7-0f39-4eb0-a569-72158d5acf01"), new Guid("97892b93-c9fd-4b85-aaae-fc059781fedf"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1835), "product-5-720x480.jpg" },
                    { new Guid("8cbf40de-4002-477c-9330-4506584eeeaa"), new Guid("97892b93-c9fd-4b85-aaae-fc059781fedf"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1837), "product-6-720x480.jpg" },
                    { new Guid("062cd0d8-8261-4d10-b1fa-434a20a84704"), new Guid("e3171484-e982-43fc-8351-1e5230b4c7b2"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1885), "product-1-720x480.jpg" },
                    { new Guid("131efb90-1878-4743-9ad3-26fd610506ba"), new Guid("e3171484-e982-43fc-8351-1e5230b4c7b2"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1887), "product-2-720x480.jpg" },
                    { new Guid("333f2bcf-4677-4351-b730-844ad0421e89"), new Guid("e3171484-e982-43fc-8351-1e5230b4c7b2"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1891), "product-3-720x480.jpg" },
                    { new Guid("76c46ea6-0e24-4ba2-ba25-ec77736f6857"), new Guid("e3171484-e982-43fc-8351-1e5230b4c7b2"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1893), "product-4-720x480.jpg" },
                    { new Guid("b6f4c6e1-f54c-4f4f-8914-cce6826669aa"), new Guid("8215deb1-795e-4834-a6b9-abe513b96844"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2115), "product-6-720x480.jpg" },
                    { new Guid("e4f32745-bd5b-470b-8d87-402ada0fc958"), new Guid("8215deb1-795e-4834-a6b9-abe513b96844"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2113), "product-5-720x480.jpg" },
                    { new Guid("3139c324-a995-4184-9438-495ba6914a53"), new Guid("8215deb1-795e-4834-a6b9-abe513b96844"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2111), "product-4-720x480.jpg" },
                    { new Guid("807a7383-68cd-4a11-9a0b-026511e62eb0"), new Guid("8215deb1-795e-4834-a6b9-abe513b96844"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2109), "product-3-720x480.jpg" },
                    { new Guid("9270979c-c50a-49a6-babd-f11d083052f7"), new Guid("8215deb1-795e-4834-a6b9-abe513b96844"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2107), "product-2-720x480.jpg" },
                    { new Guid("016e2bf8-1db5-4606-9580-978ab592d7c2"), new Guid("8215deb1-795e-4834-a6b9-abe513b96844"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2105), "product-1-720x480.jpg" },
                    { new Guid("47eb02cd-b570-4e64-95d3-46b7dc682cff"), new Guid("9b0080fc-3ae6-4918-9198-789889ddb929"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2169), "product-2-720x480.jpg" },
                    { new Guid("10418ca4-d610-445e-b1d5-b34816bf26ed"), new Guid("7f548d60-e1a6-4872-85ad-4eb518971f81"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1955), "product-6-720x480.jpg" },
                    { new Guid("7aaacabc-faf7-4a9f-8426-a00450be0fcf"), new Guid("7f548d60-e1a6-4872-85ad-4eb518971f81"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1952), "product-4-720x480.jpg" },
                    { new Guid("53c1bb68-3b64-45b7-a4ef-8a4df3f3b292"), new Guid("7f548d60-e1a6-4872-85ad-4eb518971f81"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1950), "product-3-720x480.jpg" },
                    { new Guid("1917736b-72d8-4d93-ab0c-d1a95336ad7a"), new Guid("7f548d60-e1a6-4872-85ad-4eb518971f81"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1948), "product-2-720x480.jpg" },
                    { new Guid("c8b60472-eddd-41f9-96a2-fa97d42c3d55"), new Guid("7f548d60-e1a6-4872-85ad-4eb518971f81"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1944), "product-1-720x480.jpg" },
                    { new Guid("c3cbb6a5-d30b-4ddd-84f8-2005f3af69ab"), new Guid("e3171484-e982-43fc-8351-1e5230b4c7b2"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1897), "product-6-720x480.jpg" },
                    { new Guid("6a05fafe-63c0-4311-be74-0695557882eb"), new Guid("e3171484-e982-43fc-8351-1e5230b4c7b2"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1895), "product-5-720x480.jpg" },
                    { new Guid("731f7be6-27aa-4a14-b5a9-e34c8e00c45f"), new Guid("7f548d60-e1a6-4872-85ad-4eb518971f81"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1953), "product-5-720x480.jpg" },
                    { new Guid("47943f12-22de-43ad-b3ce-5c70bb5bc1de"), new Guid("d6d3d1bf-d53e-4d6a-aef6-9e9e3ea3177f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2557), "product-1-720x480.jpg" },
                    { new Guid("b629176a-4583-4f16-ae3a-1db7e46ce78f"), new Guid("d6d3d1bf-d53e-4d6a-aef6-9e9e3ea3177f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2561), "product-2-720x480.jpg" },
                    { new Guid("b69d781b-b4d9-4e41-a83f-35072db92e43"), new Guid("d6d3d1bf-d53e-4d6a-aef6-9e9e3ea3177f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2563), "product-3-720x480.jpg" },
                    { new Guid("7f47ff47-4499-44aa-852b-6d6e937f4052"), new Guid("02a78dbc-6f8d-4cc8-8559-90c18e3356f1"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2954), "product-4-720x480.jpg" },
                    { new Guid("e85e706d-057d-4847-ad4c-22345d1a466a"), new Guid("02a78dbc-6f8d-4cc8-8559-90c18e3356f1"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2956), "product-5-720x480.jpg" },
                    { new Guid("80e79bfd-fe88-43e0-95a1-1dc7cf355f83"), new Guid("02a78dbc-6f8d-4cc8-8559-90c18e3356f1"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2958), "product-6-720x480.jpg" },
                    { new Guid("66174646-f8cc-489d-891f-4a9513922125"), new Guid("5b68a92e-caae-4887-bcbf-18a07a4b74ec"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3034), "product-1-720x480.jpg" },
                    { new Guid("40d1f7ee-b589-4bc7-9826-4a887d70f111"), new Guid("5b68a92e-caae-4887-bcbf-18a07a4b74ec"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3036), "product-2-720x480.jpg" },
                    { new Guid("9997473b-cb42-4027-ac24-da8e134af5e8"), new Guid("5b68a92e-caae-4887-bcbf-18a07a4b74ec"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3040), "product-3-720x480.jpg" },
                    { new Guid("4e9dff39-0eaa-48f8-ab8e-c686b134f3af"), new Guid("5b68a92e-caae-4887-bcbf-18a07a4b74ec"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3042), "product-4-720x480.jpg" },
                    { new Guid("9a5f6f27-0d81-47c7-9728-fed4e91aa8b0"), new Guid("5b68a92e-caae-4887-bcbf-18a07a4b74ec"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3043), "product-5-720x480.jpg" },
                    { new Guid("681a8e70-a445-4bc5-9c1e-bc466095f4c5"), new Guid("5b68a92e-caae-4887-bcbf-18a07a4b74ec"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3045), "product-6-720x480.jpg" },
                    { new Guid("fc92d227-c4f9-4526-8323-388a5a47c84d"), new Guid("f6ad4ee8-5880-4496-9534-19d058af5257"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3096), "product-1-720x480.jpg" },
                    { new Guid("f1f9b2ad-c34d-40d3-83d4-3fddca5b010d"), new Guid("f6ad4ee8-5880-4496-9534-19d058af5257"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3100), "product-2-720x480.jpg" },
                    { new Guid("c202e3c5-dba2-4672-8d7d-bc0a9e88a598"), new Guid("f6ad4ee8-5880-4496-9534-19d058af5257"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3102), "product-3-720x480.jpg" },
                    { new Guid("61366bbc-7330-4041-977d-2c983d3eeacd"), new Guid("f6ad4ee8-5880-4496-9534-19d058af5257"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3104), "product-4-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("3afbf876-bcd9-4d16-bcbd-35627c30221b"), new Guid("f6ad4ee8-5880-4496-9534-19d058af5257"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3106), "product-5-720x480.jpg" },
                    { new Guid("82703bd6-7e2b-4338-a9fe-f2ba9b745004"), new Guid("f6ad4ee8-5880-4496-9534-19d058af5257"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3108), "product-6-720x480.jpg" },
                    { new Guid("1b672f51-2e9c-4909-b7ef-ebca8c11447c"), new Guid("6b17cf62-8a05-4fbc-a514-4d095e77d31e"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3191), "product-1-720x480.jpg" },
                    { new Guid("a805500f-ee92-4c34-a268-00aea598b96e"), new Guid("6b17cf62-8a05-4fbc-a514-4d095e77d31e"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3193), "product-2-720x480.jpg" },
                    { new Guid("86bcabb9-5629-4d55-81e0-a94c436adbb8"), new Guid("1d7bdf97-9519-4898-9d9f-3baa461f0908"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3316), "product-4-720x480.jpg" },
                    { new Guid("14225a29-29ff-431c-bc6c-8ef902cecaa1"), new Guid("1d7bdf97-9519-4898-9d9f-3baa461f0908"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3314), "product-3-720x480.jpg" },
                    { new Guid("ee4513c5-d093-4018-903a-ab18f02f1c9b"), new Guid("1d7bdf97-9519-4898-9d9f-3baa461f0908"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3312), "product-2-720x480.jpg" },
                    { new Guid("2dafcb9c-3303-4c00-8f80-84867af84e13"), new Guid("1d7bdf97-9519-4898-9d9f-3baa461f0908"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3310), "product-1-720x480.jpg" },
                    { new Guid("ad3e0832-8fbc-4d56-9f85-35e9f5c88261"), new Guid("cc51f122-8211-4ff5-aaf5-bb5d6d297b1b"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3261), "product-6-720x480.jpg" },
                    { new Guid("5f8835cd-05df-4977-b341-9a34e3e50005"), new Guid("cc51f122-8211-4ff5-aaf5-bb5d6d297b1b"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3259), "product-5-720x480.jpg" },
                    { new Guid("3ade8052-986f-4167-bac5-2872cfa3f127"), new Guid("02a78dbc-6f8d-4cc8-8559-90c18e3356f1"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2950), "product-3-720x480.jpg" },
                    { new Guid("2d96f723-f06e-4219-80e7-23fc2a6ceb96"), new Guid("cc51f122-8211-4ff5-aaf5-bb5d6d297b1b"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3257), "product-4-720x480.jpg" },
                    { new Guid("e87f89ce-dd17-4647-9766-0c6cefe38d79"), new Guid("cc51f122-8211-4ff5-aaf5-bb5d6d297b1b"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3253), "product-2-720x480.jpg" },
                    { new Guid("63f5cd02-787e-475e-94db-30d3d11b8a54"), new Guid("cc51f122-8211-4ff5-aaf5-bb5d6d297b1b"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3251), "product-1-720x480.jpg" },
                    { new Guid("e9c4d7ca-dad4-4f48-b683-1a318b39907a"), new Guid("6b17cf62-8a05-4fbc-a514-4d095e77d31e"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3201), "product-6-720x480.jpg" },
                    { new Guid("485cee55-b9c2-456c-9451-4b793d4e2059"), new Guid("6b17cf62-8a05-4fbc-a514-4d095e77d31e"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3199), "product-5-720x480.jpg" },
                    { new Guid("e7c6d804-db76-4ed6-8281-1491e824abb9"), new Guid("6b17cf62-8a05-4fbc-a514-4d095e77d31e"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3197), "product-4-720x480.jpg" },
                    { new Guid("8bc23759-d7f0-4a4f-8d0d-75ae14ce6018"), new Guid("6b17cf62-8a05-4fbc-a514-4d095e77d31e"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3195), "product-3-720x480.jpg" },
                    { new Guid("1abf9fa6-9c12-4c32-8853-7bb10011d4bd"), new Guid("cc51f122-8211-4ff5-aaf5-bb5d6d297b1b"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3255), "product-3-720x480.jpg" },
                    { new Guid("1e1e3dcf-d499-47ce-aac0-ee45af18ce20"), new Guid("02a78dbc-6f8d-4cc8-8559-90c18e3356f1"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2948), "product-2-720x480.jpg" },
                    { new Guid("38a7f653-94bd-4814-82a7-45520d8352df"), new Guid("02a78dbc-6f8d-4cc8-8559-90c18e3356f1"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2946), "product-1-720x480.jpg" },
                    { new Guid("adba5439-4f87-4044-b35a-9b29498da155"), new Guid("f3f4849b-1910-43bb-927f-f7aad4a61ff6"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2898), "product-6-720x480.jpg" },
                    { new Guid("a975a298-e138-452a-8d56-a258d390b7ec"), new Guid("9888e8ec-82b6-41de-a663-9103391cc2b6"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2716), "product-5-720x480.jpg" },
                    { new Guid("8015d31d-7a1f-44d3-aa92-ad6cd3ffa210"), new Guid("9888e8ec-82b6-41de-a663-9103391cc2b6"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2714), "product-4-720x480.jpg" },
                    { new Guid("e06dfb79-a289-4255-a50b-8705f512f0ee"), new Guid("9888e8ec-82b6-41de-a663-9103391cc2b6"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2712), "product-3-720x480.jpg" },
                    { new Guid("3dcd6892-cc98-42d4-9a7e-a061d7601936"), new Guid("9888e8ec-82b6-41de-a663-9103391cc2b6"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2711), "product-2-720x480.jpg" },
                    { new Guid("d09ec949-fb78-4c84-8e6e-e8eb3d7b31a2"), new Guid("9888e8ec-82b6-41de-a663-9103391cc2b6"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2709), "product-1-720x480.jpg" },
                    { new Guid("6208aafc-43b6-4f6e-b43b-ff8960bba753"), new Guid("ec934d2c-cd37-4ec1-82bf-af24ecddb2af"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2627), "product-6-720x480.jpg" },
                    { new Guid("706f075f-1ff8-4521-96af-4fc288844652"), new Guid("9888e8ec-82b6-41de-a663-9103391cc2b6"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2718), "product-6-720x480.jpg" },
                    { new Guid("6c56ef40-8677-4fbd-b1f8-b6e9779df38d"), new Guid("ec934d2c-cd37-4ec1-82bf-af24ecddb2af"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2626), "product-5-720x480.jpg" },
                    { new Guid("445ae47a-d470-4f2e-be9d-6c4c4294ff11"), new Guid("ec934d2c-cd37-4ec1-82bf-af24ecddb2af"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2622), "product-3-720x480.jpg" },
                    { new Guid("bfe37e25-55dc-4e0d-a1a0-c75ba421af6a"), new Guid("ec934d2c-cd37-4ec1-82bf-af24ecddb2af"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2620), "product-2-720x480.jpg" },
                    { new Guid("50d82969-b457-40fa-9c9b-aedfd6a85e95"), new Guid("ec934d2c-cd37-4ec1-82bf-af24ecddb2af"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2618), "product-1-720x480.jpg" },
                    { new Guid("fdf806ef-f9ad-437c-9cd7-32720e87f4de"), new Guid("d6d3d1bf-d53e-4d6a-aef6-9e9e3ea3177f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2568), "product-6-720x480.jpg" },
                    { new Guid("bed74c7e-8d55-4d4c-afa4-c9b801c8ac65"), new Guid("d6d3d1bf-d53e-4d6a-aef6-9e9e3ea3177f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2567), "product-5-720x480.jpg" },
                    { new Guid("246748a2-ae9f-4994-9ff5-cb551f19a22a"), new Guid("d6d3d1bf-d53e-4d6a-aef6-9e9e3ea3177f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2565), "product-4-720x480.jpg" },
                    { new Guid("9b6fcc5e-f6c6-49da-a4b3-4ef424cc65d6"), new Guid("ec934d2c-cd37-4ec1-82bf-af24ecddb2af"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2624), "product-4-720x480.jpg" },
                    { new Guid("3688cae4-73fc-4770-b87b-9d0c443cf905"), new Guid("1a328f77-6299-449a-8bc7-8ff6287f9b3c"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1713), "product-5-720x480.jpg" },
                    { new Guid("b6c75a48-4d6f-4f66-a3db-1267cb5ec6ae"), new Guid("adeeba6c-0f7d-4e86-a488-d61c9a1db94d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2769), "product-1-720x480.jpg" },
                    { new Guid("905681ff-c71c-4e60-87f7-cd039c560419"), new Guid("adeeba6c-0f7d-4e86-a488-d61c9a1db94d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2773), "product-3-720x480.jpg" },
                    { new Guid("759b6932-07f6-480e-ab99-99861a5792d9"), new Guid("f3f4849b-1910-43bb-927f-f7aad4a61ff6"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2896), "product-5-720x480.jpg" },
                    { new Guid("f1c0784a-5b24-4dbc-8e5c-df668cf8f835"), new Guid("f3f4849b-1910-43bb-927f-f7aad4a61ff6"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2892), "product-4-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("b304df19-452e-44b3-8be7-bc03031e4908"), new Guid("f3f4849b-1910-43bb-927f-f7aad4a61ff6"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2890), "product-3-720x480.jpg" },
                    { new Guid("38f74462-114b-4773-9cd0-4ef505702f48"), new Guid("f3f4849b-1910-43bb-927f-f7aad4a61ff6"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2888), "product-2-720x480.jpg" },
                    { new Guid("9a95f74e-d311-4849-9a3c-bb672761c3d5"), new Guid("f3f4849b-1910-43bb-927f-f7aad4a61ff6"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2886), "product-1-720x480.jpg" },
                    { new Guid("4fec346a-e818-45ed-88cc-c33322a2fc4e"), new Guid("9fb687eb-20c8-436d-a6d1-4256cab0effa"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2839), "product-6-720x480.jpg" },
                    { new Guid("4e15c3e5-54f6-4b70-9a33-076b00fadaa1"), new Guid("adeeba6c-0f7d-4e86-a488-d61c9a1db94d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2771), "product-2-720x480.jpg" },
                    { new Guid("92008efa-b5e6-4642-8ac4-85cc0e5f42f0"), new Guid("9fb687eb-20c8-436d-a6d1-4256cab0effa"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2835), "product-5-720x480.jpg" },
                    { new Guid("190f76e1-5bd9-4da8-b750-51eb235de8ff"), new Guid("9fb687eb-20c8-436d-a6d1-4256cab0effa"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2832), "product-3-720x480.jpg" },
                    { new Guid("d1c09a8d-d3ee-4e94-bfa9-4015e7df36c9"), new Guid("9fb687eb-20c8-436d-a6d1-4256cab0effa"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2830), "product-2-720x480.jpg" },
                    { new Guid("9b6740b5-a5a2-479e-aade-f4259f66c2e6"), new Guid("9fb687eb-20c8-436d-a6d1-4256cab0effa"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2828), "product-1-720x480.jpg" },
                    { new Guid("779ad675-c144-4244-a2b6-2f12aaa6d30e"), new Guid("adeeba6c-0f7d-4e86-a488-d61c9a1db94d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2778), "product-6-720x480.jpg" },
                    { new Guid("bf85aca7-6d18-453a-af44-6e3b35e6c863"), new Guid("adeeba6c-0f7d-4e86-a488-d61c9a1db94d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2776), "product-5-720x480.jpg" },
                    { new Guid("afae9253-8ea9-4805-bd04-ac7044f17242"), new Guid("adeeba6c-0f7d-4e86-a488-d61c9a1db94d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2775), "product-4-720x480.jpg" },
                    { new Guid("92d13b6e-fdc9-4a17-8444-1642704c10d2"), new Guid("9fb687eb-20c8-436d-a6d1-4256cab0effa"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(2833), "product-4-720x480.jpg" },
                    { new Guid("75d477b2-55b5-4f00-9202-a5f905278c34"), new Guid("1a328f77-6299-449a-8bc7-8ff6287f9b3c"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1711), "product-4-720x480.jpg" },
                    { new Guid("bd702270-8912-4c0b-9dee-7f7532d98667"), new Guid("1a328f77-6299-449a-8bc7-8ff6287f9b3c"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1709), "product-3-720x480.jpg" },
                    { new Guid("ac1552af-0352-4a33-b492-3c394839d6f4"), new Guid("1a328f77-6299-449a-8bc7-8ff6287f9b3c"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1707), "product-2-720x480.jpg" },
                    { new Guid("63f2a3aa-eeab-45f4-b0ff-7a456e0bb6b8"), new Guid("1bcd907c-d849-4a5e-a59b-1aba88f4dcdf"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(490), "product-2-720x480.jpg" },
                    { new Guid("fb6fb5be-9d40-44d1-a286-d9e4a5426d63"), new Guid("1bcd907c-d849-4a5e-a59b-1aba88f4dcdf"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(492), "product-3-720x480.jpg" },
                    { new Guid("d21e5be1-bea4-46a2-bda6-751803218d3d"), new Guid("1bcd907c-d849-4a5e-a59b-1aba88f4dcdf"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(522), "product-4-720x480.jpg" },
                    { new Guid("627f82ba-9d53-4f2a-bd1e-95e24e188e09"), new Guid("1bcd907c-d849-4a5e-a59b-1aba88f4dcdf"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(524), "product-5-720x480.jpg" },
                    { new Guid("3fa92b1c-16d9-44a3-9c32-d101280cbc44"), new Guid("1bcd907c-d849-4a5e-a59b-1aba88f4dcdf"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(526), "product-6-720x480.jpg" },
                    { new Guid("f02d5b4a-d160-4a1c-aa14-5df1d6419596"), new Guid("d6017ac1-3a3c-44c8-aa55-96f0f5b474e9"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(581), "product-1-720x480.jpg" },
                    { new Guid("de9a5c47-41c8-4981-81b4-6d6be4c17124"), new Guid("d6017ac1-3a3c-44c8-aa55-96f0f5b474e9"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(583), "product-2-720x480.jpg" },
                    { new Guid("f7035cc4-2ca1-4065-8b7c-3b4276671525"), new Guid("d6017ac1-3a3c-44c8-aa55-96f0f5b474e9"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(585), "product-3-720x480.jpg" },
                    { new Guid("2b24150f-8472-45d9-8500-331506dfec00"), new Guid("d6017ac1-3a3c-44c8-aa55-96f0f5b474e9"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(587), "product-4-720x480.jpg" },
                    { new Guid("7786ac82-989d-4442-90f7-310b4bbd4af4"), new Guid("d6017ac1-3a3c-44c8-aa55-96f0f5b474e9"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(588), "product-5-720x480.jpg" },
                    { new Guid("f5c247ca-f3b6-4082-bf95-cb11b9e4f223"), new Guid("d6017ac1-3a3c-44c8-aa55-96f0f5b474e9"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(592), "product-6-720x480.jpg" },
                    { new Guid("1435c872-8910-4ee7-87b6-c2000be469ec"), new Guid("67fef7e2-3376-40a7-938a-505813cad025"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(688), "product-1-720x480.jpg" },
                    { new Guid("e56e7fd6-cca3-4957-b7b8-f89630eea673"), new Guid("67fef7e2-3376-40a7-938a-505813cad025"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(690), "product-2-720x480.jpg" },
                    { new Guid("9e1f6e68-3686-4487-ba8c-a297ac7fe5f3"), new Guid("67fef7e2-3376-40a7-938a-505813cad025"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(692), "product-3-720x480.jpg" },
                    { new Guid("6890c58e-cb4f-4992-81f6-ca3834bf969b"), new Guid("67fef7e2-3376-40a7-938a-505813cad025"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(694), "product-4-720x480.jpg" },
                    { new Guid("3c044265-0c15-4dfb-9ab8-afb8e8a5a4e3"), new Guid("67fef7e2-3376-40a7-938a-505813cad025"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(697), "product-5-720x480.jpg" },
                    { new Guid("fe2bfc83-8561-421d-9055-e3bde1d39385"), new Guid("67fef7e2-3376-40a7-938a-505813cad025"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(699), "product-6-720x480.jpg" },
                    { new Guid("23c22980-84eb-4ea0-a197-fceaaee95fac"), new Guid("4358d45b-7525-4302-aede-aa65c9c5a7ba"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(902), "product-2-720x480.jpg" },
                    { new Guid("28c480ac-e1e7-4970-a4cb-ffbbfccaa811"), new Guid("4358d45b-7525-4302-aede-aa65c9c5a7ba"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(898), "product-1-720x480.jpg" },
                    { new Guid("7e2c1dc5-25c9-464c-8a57-ce957e19a11f"), new Guid("48392d6c-ced5-4d84-afd2-89df3567fdec"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(819), "product-6-720x480.jpg" },
                    { new Guid("5a64d088-f4e9-4f4c-a0f7-76e1f4c4ab02"), new Guid("48392d6c-ced5-4d84-afd2-89df3567fdec"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(818), "product-5-720x480.jpg" },
                    { new Guid("664f88e9-c2cc-4d96-b873-f3340771301e"), new Guid("48392d6c-ced5-4d84-afd2-89df3567fdec"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(816), "product-4-720x480.jpg" },
                    { new Guid("dba83280-6664-49c1-a9fe-8157a81000b5"), new Guid("48392d6c-ced5-4d84-afd2-89df3567fdec"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(814), "product-3-720x480.jpg" },
                    { new Guid("18c229fe-9010-49dc-8908-0814f963093a"), new Guid("1bcd907c-d849-4a5e-a59b-1aba88f4dcdf"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(488), "product-1-720x480.jpg" },
                    { new Guid("0b9a08c6-480c-43ab-b5ef-afddf0bae244"), new Guid("48392d6c-ced5-4d84-afd2-89df3567fdec"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(811), "product-2-720x480.jpg" },
                    { new Guid("b791f196-c277-4ca6-8b63-4242b6cb4bf0"), new Guid("79f43907-0dbf-4779-9c74-6c132560c381"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(761), "product-6-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("300f2875-2879-4895-a9b8-ff085cf7c2c0"), new Guid("79f43907-0dbf-4779-9c74-6c132560c381"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(759), "product-5-720x480.jpg" },
                    { new Guid("05590c70-7f4c-4332-a9f7-649f5544e212"), new Guid("79f43907-0dbf-4779-9c74-6c132560c381"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(757), "product-4-720x480.jpg" },
                    { new Guid("4ac2c16c-bbcb-4be8-9b70-ff8393b44713"), new Guid("79f43907-0dbf-4779-9c74-6c132560c381"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(753), "product-3-720x480.jpg" },
                    { new Guid("bf599e05-77ef-4745-b829-94f815c60a68"), new Guid("79f43907-0dbf-4779-9c74-6c132560c381"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(751), "product-2-720x480.jpg" },
                    { new Guid("83ffb436-9983-432b-935f-6fc0c7022405"), new Guid("79f43907-0dbf-4779-9c74-6c132560c381"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(749), "product-1-720x480.jpg" },
                    { new Guid("c567103b-c909-497f-b428-c26478d7207e"), new Guid("48392d6c-ced5-4d84-afd2-89df3567fdec"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(809), "product-1-720x480.jpg" },
                    { new Guid("a797ad2b-d35d-462a-89c6-6dfa18987dd7"), new Guid("848e8cb4-727d-4e8a-928d-f0f37a50bd14"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(435), "product-6-720x480.jpg" },
                    { new Guid("73704631-066a-42ee-8f53-37d24ceb0f49"), new Guid("848e8cb4-727d-4e8a-928d-f0f37a50bd14"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(433), "product-5-720x480.jpg" },
                    { new Guid("54ead6d1-dd47-4100-81fd-2887ded386ec"), new Guid("848e8cb4-727d-4e8a-928d-f0f37a50bd14"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(431), "product-4-720x480.jpg" },
                    { new Guid("20ffbe6c-20a5-4f6d-a8dc-e0b3afc59c63"), new Guid("d2cbdd72-bbb9-41e2-9f07-f0869521e70f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(238), "product-3-720x480.jpg" },
                    { new Guid("418ee6bf-1f76-4f72-a023-1592ac3b108d"), new Guid("d2cbdd72-bbb9-41e2-9f07-f0869521e70f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(233), "product-2-720x480.jpg" },
                    { new Guid("4bf9d8d1-fe8c-42c0-a3b8-b49edcdd187d"), new Guid("d2cbdd72-bbb9-41e2-9f07-f0869521e70f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(231), "product-1-720x480.jpg" },
                    { new Guid("5307eaab-8be5-44cd-9065-3cfc527629f9"), new Guid("1edfef84-a6b6-48a9-9155-a70947e1db92"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(120), "product-6-720x480.jpg" },
                    { new Guid("42109222-bc05-42be-9411-66a4a0f34448"), new Guid("1edfef84-a6b6-48a9-9155-a70947e1db92"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(118), "product-5-720x480.jpg" },
                    { new Guid("15e5f37f-43cd-4542-996b-286858529053"), new Guid("1edfef84-a6b6-48a9-9155-a70947e1db92"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(116), "product-4-720x480.jpg" },
                    { new Guid("20eece2b-d95b-40ef-8f49-2228a3fc2fdc"), new Guid("d2cbdd72-bbb9-41e2-9f07-f0869521e70f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(240), "product-4-720x480.jpg" },
                    { new Guid("068042aa-23ca-4d81-8d13-5ffc01445b93"), new Guid("1edfef84-a6b6-48a9-9155-a70947e1db92"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(111), "product-3-720x480.jpg" },
                    { new Guid("41eadc00-97c4-4610-a31e-b4411162ddcf"), new Guid("1edfef84-a6b6-48a9-9155-a70947e1db92"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(107), "product-1-720x480.jpg" },
                    { new Guid("e48b4ea6-4201-46d1-9378-1f8276a9b9a6"), new Guid("f33e24f3-6f12-4c50-bc38-2adfdca5503f"), new DateTime(2021, 6, 14, 19, 13, 17, 756, DateTimeKind.Local).AddTicks(9825), "product-6-720x480.jpg" },
                    { new Guid("3ebc9d01-cd31-4bd4-8647-c0ec19b534e2"), new Guid("f33e24f3-6f12-4c50-bc38-2adfdca5503f"), new DateTime(2021, 6, 14, 19, 13, 17, 756, DateTimeKind.Local).AddTicks(9822), "product-5-720x480.jpg" },
                    { new Guid("ee165a89-4bcd-486e-9d8a-d8eee72cc4da"), new Guid("f33e24f3-6f12-4c50-bc38-2adfdca5503f"), new DateTime(2021, 6, 14, 19, 13, 17, 756, DateTimeKind.Local).AddTicks(9810), "product-4-720x480.jpg" },
                    { new Guid("5247cf8a-a6ce-42ac-a295-e4fa8dafcfdf"), new Guid("f33e24f3-6f12-4c50-bc38-2adfdca5503f"), new DateTime(2021, 6, 14, 19, 13, 17, 756, DateTimeKind.Local).AddTicks(9808), "product-3-720x480.jpg" },
                    { new Guid("7c114e60-5ac6-4373-b9a5-ab9bae7d3656"), new Guid("f33e24f3-6f12-4c50-bc38-2adfdca5503f"), new DateTime(2021, 6, 14, 19, 13, 17, 756, DateTimeKind.Local).AddTicks(9802), "product-2-720x480.jpg" },
                    { new Guid("8856f534-f4d9-4b71-b9c1-6c8bef8ab245"), new Guid("1edfef84-a6b6-48a9-9155-a70947e1db92"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(109), "product-2-720x480.jpg" },
                    { new Guid("77d1833d-bd75-46f2-b1a8-5240fb91ad17"), new Guid("4358d45b-7525-4302-aede-aa65c9c5a7ba"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(904), "product-3-720x480.jpg" },
                    { new Guid("a0003aeb-ad6a-44aa-ad10-9d8dd798bd2a"), new Guid("d2cbdd72-bbb9-41e2-9f07-f0869521e70f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(242), "product-5-720x480.jpg" },
                    { new Guid("10b8eed3-a7f5-49af-bdc9-38f785ebad05"), new Guid("a55537a7-9d83-40c3-a0fc-c09729e410d4"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(299), "product-1-720x480.jpg" },
                    { new Guid("e996cd9e-7d85-4589-bedc-8e21e0c82cfc"), new Guid("848e8cb4-727d-4e8a-928d-f0f37a50bd14"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(429), "product-3-720x480.jpg" },
                    { new Guid("c545e4ca-0d3e-43aa-8c00-562938698099"), new Guid("848e8cb4-727d-4e8a-928d-f0f37a50bd14"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(427), "product-2-720x480.jpg" },
                    { new Guid("425f058b-af4e-4c86-8414-5da973b5f454"), new Guid("848e8cb4-727d-4e8a-928d-f0f37a50bd14"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(425), "product-1-720x480.jpg" },
                    { new Guid("a552ddb9-f500-4ecd-a6dd-a71b8818151f"), new Guid("5262dfe0-d4b3-47f8-b05e-9f09393ea2c9"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(374), "product-6-720x480.jpg" },
                    { new Guid("debc8e9d-78e1-425c-94f6-dec70632db42"), new Guid("5262dfe0-d4b3-47f8-b05e-9f09393ea2c9"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(372), "product-5-720x480.jpg" },
                    { new Guid("1b3334d4-bf65-485d-9778-0ea13756fad7"), new Guid("5262dfe0-d4b3-47f8-b05e-9f09393ea2c9"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(370), "product-4-720x480.jpg" },
                    { new Guid("fe016d40-f0cd-4264-872f-b29c9e495eb3"), new Guid("d2cbdd72-bbb9-41e2-9f07-f0869521e70f"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(243), "product-6-720x480.jpg" },
                    { new Guid("4d1dfcbf-bbbd-4063-aedc-004ad42e4d7e"), new Guid("5262dfe0-d4b3-47f8-b05e-9f09393ea2c9"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(368), "product-3-720x480.jpg" },
                    { new Guid("a5d0cb1e-4bc6-4c22-b691-0100e4afa520"), new Guid("5262dfe0-d4b3-47f8-b05e-9f09393ea2c9"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(364), "product-1-720x480.jpg" },
                    { new Guid("78568e45-66a9-4bcf-b530-acf8b30ce91c"), new Guid("a55537a7-9d83-40c3-a0fc-c09729e410d4"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(311), "product-6-720x480.jpg" },
                    { new Guid("ef3df49e-fab7-4c0e-ba72-d967f4769a78"), new Guid("a55537a7-9d83-40c3-a0fc-c09729e410d4"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(309), "product-5-720x480.jpg" },
                    { new Guid("24fb8535-c5bb-402f-807d-ac65dd120c0c"), new Guid("a55537a7-9d83-40c3-a0fc-c09729e410d4"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(307), "product-4-720x480.jpg" },
                    { new Guid("f2e99679-28e7-4178-ad24-3d520f63f6a2"), new Guid("a55537a7-9d83-40c3-a0fc-c09729e410d4"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(306), "product-3-720x480.jpg" },
                    { new Guid("5e9da5bf-c6f0-4065-8283-ab29aa3e57d6"), new Guid("a55537a7-9d83-40c3-a0fc-c09729e410d4"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(304), "product-2-720x480.jpg" },
                    { new Guid("1a8e9ecf-3fc9-4651-804a-d373befe05a4"), new Guid("5262dfe0-d4b3-47f8-b05e-9f09393ea2c9"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(366), "product-2-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("9f2b6fad-c4e6-4e9f-a668-2e2d5059936e"), new Guid("1d7bdf97-9519-4898-9d9f-3baa461f0908"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3318), "product-5-720x480.jpg" },
                    { new Guid("ec2b2ffe-db96-4375-8d80-ea82445c3c90"), new Guid("4358d45b-7525-4302-aede-aa65c9c5a7ba"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(906), "product-4-720x480.jpg" },
                    { new Guid("d63e1cf0-2bef-47f7-90d0-ffea93a0a431"), new Guid("4358d45b-7525-4302-aede-aa65c9c5a7ba"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(910), "product-6-720x480.jpg" },
                    { new Guid("ca7d730d-79c3-48cc-b948-242792909f4d"), new Guid("a22a51c9-2891-4303-99b3-41a0764c266c"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1349), "product-1-720x480.jpg" },
                    { new Guid("77d194e3-cc6f-4ceb-b865-ec54974e8ecd"), new Guid("a22a51c9-2891-4303-99b3-41a0764c266c"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1351), "product-2-720x480.jpg" },
                    { new Guid("e139515a-02a9-4d9a-9a7c-c3c3ded04fe5"), new Guid("a22a51c9-2891-4303-99b3-41a0764c266c"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1355), "product-3-720x480.jpg" },
                    { new Guid("f6206a05-733b-4750-a29d-85adc38882c5"), new Guid("a22a51c9-2891-4303-99b3-41a0764c266c"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1357), "product-4-720x480.jpg" },
                    { new Guid("bd2d5f06-6328-47ae-9247-1f2e2de85a9d"), new Guid("a22a51c9-2891-4303-99b3-41a0764c266c"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1359), "product-5-720x480.jpg" },
                    { new Guid("f48cf63a-ddc0-4950-a41c-2510555d1b81"), new Guid("a22a51c9-2891-4303-99b3-41a0764c266c"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1361), "product-6-720x480.jpg" },
                    { new Guid("b445b6f1-892c-4d86-8943-5cc533ac77cd"), new Guid("89bd71e9-f440-456e-b083-2b0d9cba1ddb"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1408), "product-1-720x480.jpg" },
                    { new Guid("a9c9e7cc-e8da-47a7-8ce1-338bdd533ee4"), new Guid("89bd71e9-f440-456e-b083-2b0d9cba1ddb"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1412), "product-2-720x480.jpg" },
                    { new Guid("3129530e-ee31-4988-81ee-751e37590d5d"), new Guid("89bd71e9-f440-456e-b083-2b0d9cba1ddb"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1414), "product-3-720x480.jpg" },
                    { new Guid("5647c17b-a4ba-43e5-a842-f31f070f18bc"), new Guid("89bd71e9-f440-456e-b083-2b0d9cba1ddb"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1416), "product-4-720x480.jpg" },
                    { new Guid("4bbd9f99-7675-422d-8adc-4052ddfdf884"), new Guid("89bd71e9-f440-456e-b083-2b0d9cba1ddb"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1418), "product-5-720x480.jpg" },
                    { new Guid("4b721da9-7b7b-4c47-8ab6-a48afdfaea14"), new Guid("89bd71e9-f440-456e-b083-2b0d9cba1ddb"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1420), "product-6-720x480.jpg" },
                    { new Guid("60d300f1-1497-42d5-b2fb-78904300b2ea"), new Guid("0fb2e4e8-d683-4db5-a516-54c6752b9353"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1498), "product-1-720x480.jpg" },
                    { new Guid("e9a14c91-d1dd-4b09-9838-41cef7e34a0f"), new Guid("0fb2e4e8-d683-4db5-a516-54c6752b9353"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1500), "product-2-720x480.jpg" },
                    { new Guid("6fdaeb60-eee5-46b8-bae4-feb2e547003f"), new Guid("0fb2e4e8-d683-4db5-a516-54c6752b9353"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1502), "product-3-720x480.jpg" },
                    { new Guid("e2e487a8-de48-46bd-a437-8fdb83dafa9d"), new Guid("0fb2e4e8-d683-4db5-a516-54c6752b9353"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1504), "product-4-720x480.jpg" },
                    { new Guid("098e2ada-9052-4434-8c05-f5abe11a56f5"), new Guid("0fb2e4e8-d683-4db5-a516-54c6752b9353"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1506), "product-5-720x480.jpg" },
                    { new Guid("6a6a4c50-858c-460c-bc44-71d913934dfe"), new Guid("1a328f77-6299-449a-8bc7-8ff6287f9b3c"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1705), "product-1-720x480.jpg" },
                    { new Guid("0857a0e8-2f3d-4446-9ca2-fe174def57b4"), new Guid("b701908e-5061-4807-a1f4-e193f86d56be"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1629), "product-6-720x480.jpg" },
                    { new Guid("72919e6c-9a35-4fe5-9111-924eb4c696f5"), new Guid("b701908e-5061-4807-a1f4-e193f86d56be"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1627), "product-5-720x480.jpg" },
                    { new Guid("8ccd6f41-5ddc-4483-9f61-b1f81c1548cc"), new Guid("b701908e-5061-4807-a1f4-e193f86d56be"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1625), "product-4-720x480.jpg" },
                    { new Guid("fd0089ff-0302-4b62-9a88-9c802ec251fe"), new Guid("b701908e-5061-4807-a1f4-e193f86d56be"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1624), "product-3-720x480.jpg" },
                    { new Guid("b68bea9b-0108-41c0-aea4-02f6b4be75cc"), new Guid("b701908e-5061-4807-a1f4-e193f86d56be"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1622), "product-2-720x480.jpg" },
                    { new Guid("266f1857-1349-457f-9dff-a1f6f47a70fa"), new Guid("de350184-9b44-4272-9e7f-2245819858a7"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1302), "product-6-720x480.jpg" },
                    { new Guid("ad902a99-8aec-490a-b9e7-2ce3c1310349"), new Guid("b701908e-5061-4807-a1f4-e193f86d56be"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1620), "product-1-720x480.jpg" },
                    { new Guid("7ad5a94f-5580-49f0-bdde-52b19bc98493"), new Guid("9d4f8863-8a72-4e13-bc95-6ced652daea0"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1565), "product-5-720x480.jpg" },
                    { new Guid("76519466-9b23-449c-a25a-171915a663ca"), new Guid("9d4f8863-8a72-4e13-bc95-6ced652daea0"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1564), "product-4-720x480.jpg" },
                    { new Guid("788fc5e9-c753-48e4-a4b9-38e2cfb1e949"), new Guid("9d4f8863-8a72-4e13-bc95-6ced652daea0"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1562), "product-3-720x480.jpg" },
                    { new Guid("bcde6243-d958-4eff-89c8-19faaf44a366"), new Guid("9d4f8863-8a72-4e13-bc95-6ced652daea0"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1560), "product-2-720x480.jpg" },
                    { new Guid("189b08ff-416f-4abd-9cab-a307bcc93cdc"), new Guid("9d4f8863-8a72-4e13-bc95-6ced652daea0"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1558), "product-1-720x480.jpg" },
                    { new Guid("d7394661-b8e1-41d2-a605-7ab7e9324151"), new Guid("0fb2e4e8-d683-4db5-a516-54c6752b9353"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1508), "product-6-720x480.jpg" },
                    { new Guid("252a5b35-6294-44fd-b898-c3d74c1a03b1"), new Guid("9d4f8863-8a72-4e13-bc95-6ced652daea0"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1567), "product-6-720x480.jpg" },
                    { new Guid("dcf4c6cc-de9b-47b2-97bc-61b7309bb25a"), new Guid("de350184-9b44-4272-9e7f-2245819858a7"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1300), "product-5-720x480.jpg" },
                    { new Guid("5ca9058a-8af0-4644-a3fe-631add7e962c"), new Guid("de350184-9b44-4272-9e7f-2245819858a7"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1298), "product-4-720x480.jpg" },
                    { new Guid("55f68219-2eef-4c13-b584-d996fb67a176"), new Guid("de350184-9b44-4272-9e7f-2245819858a7"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1294), "product-3-720x480.jpg" },
                    { new Guid("429951f0-cef4-40e4-841f-29245571c278"), new Guid("cb353a94-441d-4b42-9a7b-04fe0b8fe59d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1081), "product-2-720x480.jpg" },
                    { new Guid("b07e69a1-166b-43ab-86dd-b46e8b7dd6c8"), new Guid("cb353a94-441d-4b42-9a7b-04fe0b8fe59d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1079), "product-1-720x480.jpg" },
                    { new Guid("d340de89-a639-4a54-b29c-c7f0a9eab27f"), new Guid("13aee88a-e5ea-497c-a919-76df8094c752"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1029), "product-6-720x480.jpg" },
                    { new Guid("400e9217-4c39-45f1-be18-4a8468d126c7"), new Guid("13aee88a-e5ea-497c-a919-76df8094c752"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1027), "product-5-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("06e7db37-3501-4d36-990e-794972a21078"), new Guid("13aee88a-e5ea-497c-a919-76df8094c752"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1026), "product-4-720x480.jpg" },
                    { new Guid("389d33cc-f31d-4df8-9e21-1867bde2e9be"), new Guid("13aee88a-e5ea-497c-a919-76df8094c752"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1024), "product-3-720x480.jpg" },
                    { new Guid("7b2e8fa9-d754-408e-9a7d-e1fa4f13318b"), new Guid("cb353a94-441d-4b42-9a7b-04fe0b8fe59d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1083), "product-3-720x480.jpg" },
                    { new Guid("b43509c6-6bed-433e-8645-0684d258ce14"), new Guid("13aee88a-e5ea-497c-a919-76df8094c752"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1022), "product-2-720x480.jpg" },
                    { new Guid("aa236a24-ef0e-470f-b26c-b406409cbaa0"), new Guid("7303600d-0a04-4cc9-ac15-4ef0d1fe795a"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(970), "product-6-720x480.jpg" },
                    { new Guid("3a3094c0-0812-4572-9d33-d0d32ea8f1d1"), new Guid("7303600d-0a04-4cc9-ac15-4ef0d1fe795a"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(968), "product-5-720x480.jpg" },
                    { new Guid("284cdd1f-97cc-4893-953d-8a8737ef7fce"), new Guid("7303600d-0a04-4cc9-ac15-4ef0d1fe795a"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(966), "product-4-720x480.jpg" },
                    { new Guid("30cf5063-262b-44c3-93e1-0e132ea70584"), new Guid("7303600d-0a04-4cc9-ac15-4ef0d1fe795a"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(964), "product-3-720x480.jpg" },
                    { new Guid("d7fb2fa0-0d9e-49d4-9a98-85458af94d8b"), new Guid("7303600d-0a04-4cc9-ac15-4ef0d1fe795a"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(962), "product-2-720x480.jpg" },
                    { new Guid("dca664ae-56bb-44ae-b0bb-5d7ee8a68414"), new Guid("7303600d-0a04-4cc9-ac15-4ef0d1fe795a"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(960), "product-1-720x480.jpg" },
                    { new Guid("9cc08b47-9d88-4702-84f2-585e1b6fc899"), new Guid("13aee88a-e5ea-497c-a919-76df8094c752"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1020), "product-1-720x480.jpg" },
                    { new Guid("d3b37ddd-5cd3-43b9-91b5-b22e793789af"), new Guid("4358d45b-7525-4302-aede-aa65c9c5a7ba"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(908), "product-5-720x480.jpg" },
                    { new Guid("10f157ef-3506-4d69-8dbd-262d9cdeb0bd"), new Guid("cb353a94-441d-4b42-9a7b-04fe0b8fe59d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1085), "product-4-720x480.jpg" },
                    { new Guid("e1383bb5-c352-4197-a295-1e5e80aabde7"), new Guid("cb353a94-441d-4b42-9a7b-04fe0b8fe59d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1088), "product-6-720x480.jpg" },
                    { new Guid("d49b47fa-008d-450c-a32d-7c8553bf02ad"), new Guid("de350184-9b44-4272-9e7f-2245819858a7"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1292), "product-2-720x480.jpg" },
                    { new Guid("e40979a0-e22b-4f51-b5e1-6f886a6780fc"), new Guid("de350184-9b44-4272-9e7f-2245819858a7"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1290), "product-1-720x480.jpg" },
                    { new Guid("e0740635-a4ea-4d8c-b0ae-ce4c57d79791"), new Guid("ffd9866a-8463-4c7f-8bcf-52c46000eac1"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1242), "product-6-720x480.jpg" },
                    { new Guid("cd1c8f69-4fba-44d6-a90b-b36e8e2aac4f"), new Guid("ffd9866a-8463-4c7f-8bcf-52c46000eac1"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1240), "product-5-720x480.jpg" },
                    { new Guid("853c5655-fcb7-457a-8387-e83c199c23a1"), new Guid("ffd9866a-8463-4c7f-8bcf-52c46000eac1"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1237), "product-4-720x480.jpg" },
                    { new Guid("900cb91c-13b2-4580-9ea7-7868a6a44206"), new Guid("ffd9866a-8463-4c7f-8bcf-52c46000eac1"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1235), "product-3-720x480.jpg" },
                    { new Guid("bc0fd00b-d9b0-4f3a-b9bd-7c41548938b5"), new Guid("cb353a94-441d-4b42-9a7b-04fe0b8fe59d"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1086), "product-5-720x480.jpg" },
                    { new Guid("abd3ca93-65ff-48a3-9b88-d098c1ae62b7"), new Guid("ffd9866a-8463-4c7f-8bcf-52c46000eac1"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1233), "product-2-720x480.jpg" },
                    { new Guid("3f3a78aa-8f01-4765-8495-c627c6e87af5"), new Guid("566f99be-75ea-44ac-a0b9-bf067b82dbd3"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1177), "product-6-720x480.jpg" },
                    { new Guid("34a51565-757e-46c5-91e4-170c78dde808"), new Guid("566f99be-75ea-44ac-a0b9-bf067b82dbd3"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1173), "product-5-720x480.jpg" },
                    { new Guid("23d47aac-ce48-4f13-9973-bf02df5d8ec5"), new Guid("566f99be-75ea-44ac-a0b9-bf067b82dbd3"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1171), "product-4-720x480.jpg" },
                    { new Guid("493793de-48b0-43e8-915f-8e65e9a7020f"), new Guid("566f99be-75ea-44ac-a0b9-bf067b82dbd3"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1169), "product-3-720x480.jpg" },
                    { new Guid("951dcd49-c8d9-40bd-9b34-e0b4bbf85df7"), new Guid("566f99be-75ea-44ac-a0b9-bf067b82dbd3"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1167), "product-2-720x480.jpg" },
                    { new Guid("34224e54-ee65-45f4-b7a4-8f1883823df9"), new Guid("566f99be-75ea-44ac-a0b9-bf067b82dbd3"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1165), "product-1-720x480.jpg" },
                    { new Guid("cfdf2076-55e9-4528-804a-6dc5849365db"), new Guid("ffd9866a-8463-4c7f-8bcf-52c46000eac1"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(1231), "product-1-720x480.jpg" },
                    { new Guid("82623e01-7405-4b8d-9a6e-424110a9c879"), new Guid("1d7bdf97-9519-4898-9d9f-3baa461f0908"), new DateTime(2021, 6, 14, 19, 13, 17, 757, DateTimeKind.Local).AddTicks(3319), "product-6-720x480.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CarId",
                table: "Images",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}