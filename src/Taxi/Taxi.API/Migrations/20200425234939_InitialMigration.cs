using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartPrice = table.Column<double>(nullable: false),
                    PricePerKm = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DriverId = table.Column<string>(nullable: true),
                    FromId = table.Column<string>(nullable: true),
                    ToId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
                    DriverId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "CompanyId", "Created", "CustomerId", "DriverId", "Latitude", "Longitude", "PostalCode", "UserId" },
                values: new object[,]
                {
                    { "31588e97-5c6b-48dd-89a1-edd92deb3bbb", "Provinciebaan 28", "", "Koekelare", null, null, null, null, 51.073039000000001, 2.975749, "8680", "31588e97-5c6b-48dd-89a1-edd92deb3bcb" },
                    { "31588e97-5c6b-48dd-89a1-edd92deb3ccc", "Kleine stationsstraat 12", "", "Koekelare", null, null, null, null, 51.091222999999999, 2.9746260000000002, "8680", "31588e97-5c6b-48dd-89a1-edd92deb3bcb" },
                    { "4d6b5430-2454-45ca-9617-dff7c847abc2", "Ringlaan 33", "", "Koekelare", null, null, null, null, 51.091836999999998, 2.977001, "8680", "00000000-0000-0000-0000-000000000004" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "edd6b435-5986-42e3-8517-a44af9f6b59a", "4c943ab4-5d49-47c0-9a16-a9894a7af094", "Admin", "ADMIN" },
                    { "08517b2f-66c3-468d-a5fc-c0d9bbba6208", "34822778-f2f0-4589-a32a-606835d2f15e", "Driver", "DRIVER" },
                    { "ae39515f-29fc-49c4-95f5-e18f2ec7acdb", "8fb07fbf-04b0-4353-84e7-44ba76960194", "Company", "COMPANY" },
                    { "565e1f6e-9348-46ef-9cc0-ed93f8bba435", "6e88ef91-126e-4deb-9819-cb97acde8b98", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000021", 0, "2fa5c7f7-1188-4376-a1fb-ae8cda2a1beb", "customer8@taxi.com", false, false, null, "CUSTOMER8@TAXI.COM", "CUSTOMER8@TAXI.COM", "AQAAAAEAACcQAAAAEBHvkvceoVf8G5juemQ0YoXrod/9GUAibscT3z8Dji1cqBOh5ebhM62wXEltJ78ctw==", "+32497645255", false, "e1dcc856-7afb-4a19-aa4c-b42f915f753b", false, "customer8@taxi.com" },
                    { "00000000-0000-0000-0000-000000000020", 0, "0777832c-230e-46a4-85a9-4e9325fa797f", "customer7@taxi.com", false, false, null, "CUSTOMER7@TAXI.COM", "CUSTOMER7@TAXI.COM", "AQAAAAEAACcQAAAAEHmysxuC/mR9V+tL/72kctynuJKT5W4ZcJHWeUI79PxTkM51IhshrnDOsY1Y/iatqg==", "+32497645255", false, "d4f4b0d3-8058-417e-a237-1b4c3e628f7c", false, "customer7@taxi.com" },
                    { "00000000-0000-0000-0000-000000000004", 0, "d7e75c14-286b-4115-ba14-23ea2df43010", "company1@taxi.com", false, false, null, "COMPANY1@TAXI.COM", "COMPANY1", "AQAAAAEAACcQAAAAELKxrhUIdlzLbAy3FuJeC5/OjBFALTBXHW9KaduGs2QzgEvZ5lp8LPtlN2MdFURqKw==", "+32497645255", false, "3685714f-f24c-4a57-987c-98614d272324", false, "Company1" },
                    { "00000000-0000-0000-0000-000000000010", 0, "2fcfde87-c155-4ab9-9863-ca903fd2f88c", "company2@taxi.com", false, false, null, "COMPANY2@TAXI.COM", "COMPANY2", "AQAAAAEAACcQAAAAEJGb24UAMV6DCdVYaBQPpgvwC2gEKte2pjXwJZ9CbT5wKzwyQ6PUQuGVZG9jVSoNog==", "+32497643255", false, "c5916563-0a5f-4348-9579-dec0c4ca19c6", false, "Company2" },
                    { "00000000-0000-0000-0000-000000000002", 0, "0d5937a7-d6d2-4a95-94a5-6b4c7c5bc96f", "driver1@taxi.com", false, false, null, "DRIVER1@TAXI.COM", "DRIVER1@TAXI.COM", "AQAAAAEAACcQAAAAEOG4eedqntXysDxFatK3iitiOEjiAcs4/qTWG7am/UOT/2+meyAIiWzzepfNN5V6Bw==", "+32497645255", false, "983fb6bc-79f2-472e-878a-7d04752aadef", false, "driver1@taxi.com" },
                    { "00000000-0000-0000-0000-000000000001", 0, "4072dfba-677e-4e93-824f-9fd78badc9af", "durnez.anthony@gmail.com", false, false, null, "DURNEZ.ANTHONY@GMAIL.COM", "DURNEZ.ANTHONY@gmail.COM", "AQAAAAEAACcQAAAAENEGXtjoEOQSE6Fg7b9W7eXDrplnYfvYi7t4pYUqQlU0F8kOne5iwNRb4EXNbfgA4g==", "+32497645255", false, "c4f74d93-7603-453d-9357-fe56d7cc37e5", false, "durnez.anthony@GMAIL.com" },
                    { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", 0, "1f754c67-c4b6-4f23-9300-0fd2529d6dbf", "durnez.robbe@hotmail.com", false, false, null, "DURNEZ.ROBBE@HOTMAIL.COM", "DURNEZ.ROBBE@HOTMAIL.COM", "AQAAAAEAACcQAAAAEA0LsZINHAwtjnL6tiiDE6Y9zMfmkFzaAFg4Keeb0umbqyaGSKMPTTOhxQLPkma8KA==", "+32497635255", false, "28d4a26d-f7f5-40e7-bf55-a5cf9b2a7da9", false, "durnez.robbe@hotmail.com" },
                    { "00000000-0000-0000-0000-000000000003", 0, "3303bee4-8812-4b05-b616-c576e12502e2", "driver2@taxi.com", false, false, null, "DRIVER2@TAXI.COM", "DRIVER2@TAXI.COM", "AQAAAAEAACcQAAAAEOwTcg7h1c4zZt0azkwnQBXk0t4MokxB+W50hwHB6EoWcqjPWWusGgw8jsn6bHa7Dg==", "+32497645255", false, "afe78433-a36b-484d-8e6c-ed875de0354c", false, "driver2@taxi.com" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Created", "Name", "PricePerKm", "StartPrice", "UserType" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 4, 26, 1, 49, 39, 674, DateTimeKind.Local).AddTicks(2380), "Maxi Tarco", 2.0, 5.0, 2 },
                    { "00000000-0000-0000-0000-000000000010", new DateTime(2020, 4, 26, 1, 49, 39, 674, DateTimeKind.Local).AddTicks(2600), "Company 2", 1.5, 10.0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Created", "FirstName", "LastName", "UserType" },
                values: new object[,]
                {
                    { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", new DateTime(2020, 4, 26, 1, 49, 39, 682, DateTimeKind.Local).AddTicks(8390), "Robbe", "Durnez", 0 },
                    { "00000000-0000-0000-0000-000000000001", new DateTime(2020, 4, 26, 1, 49, 39, 682, DateTimeKind.Local).AddTicks(8530), "Anthony", "Durnez", 0 },
                    { "00000000-0000-0000-0000-000000000020", new DateTime(2020, 4, 26, 1, 49, 39, 682, DateTimeKind.Local).AddTicks(8630), "User7", "Taxi", 0 },
                    { "00000000-0000-0000-0000-000000000021", new DateTime(2020, 4, 26, 1, 49, 39, 682, DateTimeKind.Local).AddTicks(8730), "User8", "Taxi", 0 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CompanyId", "Created", "Date", "DriverId", "FromId", "State", "ToId", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000400", null, new DateTime(2020, 4, 26, 1, 49, 39, 699, DateTimeKind.Local).AddTicks(110), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000002", "31588e97-5c6b-48dd-89a1-edd92deb3bbb", 0, "31588e97-5c6b-48dd-89a1-edd92deb3ccc", 0.0, "31588e97-5c6b-48dd-89a1-edd92deb3bcb" },
                    { "00000000-0000-0000-0000-000000000100", null, new DateTime(2020, 4, 26, 1, 49, 39, 698, DateTimeKind.Local).AddTicks(9710), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000002", "31588e97-5c6b-48dd-89a1-edd92deb3bbb", 0, "31588e97-5c6b-48dd-89a1-edd92deb3ccc", 0.0, "31588e97-5c6b-48dd-89a1-edd92deb3bcb" },
                    { "00000000-0000-0000-0000-000000000200", null, new DateTime(2020, 4, 26, 1, 49, 39, 698, DateTimeKind.Local).AddTicks(9940), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000002", "31588e97-5c6b-48dd-89a1-edd92deb3bbb", 1, "31588e97-5c6b-48dd-89a1-edd92deb3ccc", 0.0, "31588e97-5c6b-48dd-89a1-edd92deb3bcb" },
                    { "00000000-0000-0000-0000-000000000300", null, new DateTime(2020, 4, 26, 1, 49, 39, 699, DateTimeKind.Local).AddTicks(30), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000002", "31588e97-5c6b-48dd-89a1-edd92deb3bbb", 1, "31588e97-5c6b-48dd-89a1-edd92deb3ccc", 0.0, "31588e97-5c6b-48dd-89a1-edd92deb3bcb" },
                    { "00000000-0000-0000-0000-000000000500", null, new DateTime(2020, 4, 26, 1, 49, 39, 699, DateTimeKind.Local).AddTicks(190), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000002", "31588e97-5c6b-48dd-89a1-edd92deb3bbb", 2, "31588e97-5c6b-48dd-89a1-edd92deb3ccc", 0.0, "31588e97-5c6b-48dd-89a1-edd92deb3bcb" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "565e1f6e-9348-46ef-9cc0-ed93f8bba435" },
                    { "00000000-0000-0000-0000-000000000001", "565e1f6e-9348-46ef-9cc0-ed93f8bba435" },
                    { "00000000-0000-0000-0000-000000000002", "08517b2f-66c3-468d-a5fc-c0d9bbba6208" },
                    { "00000000-0000-0000-0000-000000000003", "08517b2f-66c3-468d-a5fc-c0d9bbba6208" },
                    { "00000000-0000-0000-0000-000000000004", "ae39515f-29fc-49c4-95f5-e18f2ec7acdb" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CompanyId", "Created", "FirstName", "IsActive", "IsAvailable", "LastName", "Latitude", "Longitude", "UserType" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000004", new DateTime(2020, 4, 26, 1, 49, 39, 686, DateTimeKind.Local).AddTicks(6200), "Taxi", true, true, "Driver1", 51.086199999999998, 2.9763999999999999, 1 },
                    { "00000000-0000-0000-0000-000000000003", "00000000-0000-0000-0000-000000000004", new DateTime(2020, 4, 26, 1, 49, 39, 686, DateTimeKind.Local).AddTicks(6360), "Taxi", true, false, "Driver200", 51.091799999999999, 2.9746000000000001, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CompanyId",
                table: "Addresses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DriverId",
                table: "Addresses",
                column: "DriverId");

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
                name: "IX_Drivers_CompanyId",
                table: "Drivers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CompanyId",
                table: "Orders",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

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
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
