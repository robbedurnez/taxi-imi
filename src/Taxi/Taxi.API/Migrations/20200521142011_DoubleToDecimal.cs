using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.API.Migrations
{
    public partial class DoubleToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "4d6b5430-2454-45ca-9617-dff7c847abc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edd6b435-5986-42e3-8517-a44af9f6b59a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000001", "565e1f6e-9348-46ef-9cc0-ed93f8bba435" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000002", "08517b2f-66c3-468d-a5fc-c0d9bbba6208" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000003", "08517b2f-66c3-468d-a5fc-c0d9bbba6208" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000004", "ae39515f-29fc-49c4-95f5-e18f2ec7acdb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "565e1f6e-9348-46ef-9cc0-ed93f8bba435" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08517b2f-66c3-468d-a5fc-c0d9bbba6208");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "565e1f6e-9348-46ef-9cc0-ed93f8bba435");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae39515f-29fc-49c4-95f5-e18f2ec7acdb");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "StartPrice",
                table: "Companies",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerKm",
                table: "Companies",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "CompanyId", "Created", "CustomerId", "DriverId", "Latitude", "Longitude", "PostalCode", "UserId" },
                values: new object[] { "5e9f6f77-fb49-4ff4-8003-d948a8f1bed7", "Ringlaan 33", "", "Koekelare", null, null, null, null, 51.091836999999998, 2.977001, "8680", "00000000-0000-0000-0000-000000000004" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "73243b97-52b1-41c6-8521-f455fe9072fa", "8ccb0d97-95ec-4440-b0cb-51ba469e9d43", "Admin", "ADMIN" },
                    { "733a8b9d-197d-486a-a82f-3e034c6f4d11", "e28a105f-0a64-405a-9a75-200172125807", "Driver", "DRIVER" },
                    { "353d5cf4-8ed9-4622-97d4-dbf0959ec233", "2426a2f1-8326-4ac7-8854-9f1818196b90", "Company", "COMPANY" },
                    { "78943822-274e-434a-817a-38d7801b07df", "2963e5a7-1732-408f-a544-c45f171f04cc", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3494bbc-2b4c-4304-bd8b-a21e76c61b16", "AQAAAAEAACcQAAAAEH7x7tRK/er4LvgBk5OF2HLghomTqjNb7z0BWYRXbZPZ/V1tovkEB1PklvvORWjkyg==", "3b8091c3-ae3b-4fc5-9896-09f04ed83fab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34fa5943-fec2-4164-9a5f-f42b7df021ec", "AQAAAAEAACcQAAAAEJrY16mBJvRzLEJ4JaPwbdcQv+56oZg7HqK5eAWPSu6NvONitaN2+bDxkfZA64oT2w==", "f67992db-87e9-49fa-a44e-39263c9993ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13149875-4166-4747-8937-bcb206b49c2c", "AQAAAAEAACcQAAAAEGrCAfd3Mu/L2SaXjBABO0sY6uqxc4UO45dxP15qxDjghspYoFcl6rKqUMrDQLEJsQ==", "3d647ce6-bcbe-4a9f-b981-c59c729e374d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77212a09-164b-48e9-bad9-492aa954d83c", "AQAAAAEAACcQAAAAEMk1kADJVa7RH+gfgRwIM2c1+msGRpkGVUQivnXG+ERTb+MwoMJIgcqrd9vpoMrIvg==", "eeddb684-214f-4d64-8f64-b7739f9a50fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf4495ca-3ed9-4b28-ac41-cb9f9dea7f3a", "AQAAAAEAACcQAAAAECdHTyb4LrGcJWcFFm2EDshc6AI/W6U3/XaLTNKUYKEoWS/pLlhbk4+JHQVBzXCi4Q==", "6847d23a-bd97-4bba-8d9f-a61693a70e04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5aa926f-d4a5-4658-bee5-4a3dd9d8ed3d", "AQAAAAEAACcQAAAAEHcxZ9S2OadLB/xtqZYMjfSg66d75T+43N8IXwzg4W4wrdgxymH/4gd4jPM5Tv4JqA==", "6c3fb60f-e3e6-46c6-a494-d3688f0594cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d162dbc0-ee5e-48b1-92b2-2cd7c647fa23", "AQAAAAEAACcQAAAAEJjAX/Q3gV0NkSuYADz7BKLor1vjKtll3ERDdjlsDqoh/+tm4kZD2stsGVGmy7pmIQ==", "bd46745e-347b-40f0-8344-7d44389cc270" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d37950b-73d4-476a-9efb-08e59808943f", "AQAAAAEAACcQAAAAEH4/r+pQYlKRHE7zAbA8BhdgENLD4VXs6owu2PqJ78Amzvj1PthnNnLiChO/AvY4DQ==", "5cab5ef1-3e0f-4964-a6c9-ad8dde6ba0f5" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                columns: new[] { "Created", "PricePerKm", "StartPrice" },
                values: new object[] { new DateTime(2020, 5, 21, 16, 20, 11, 446, DateTimeKind.Local).AddTicks(9030), 2m, 5m });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                columns: new[] { "Created", "PricePerKm", "StartPrice" },
                values: new object[] { new DateTime(2020, 5, 21, 16, 20, 11, 446, DateTimeKind.Local).AddTicks(9210), 1.5m, 10m });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 458, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 458, DateTimeKind.Local).AddTicks(720));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 458, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 458, DateTimeKind.Local).AddTicks(480));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 461, DateTimeKind.Local).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 461, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 21, 16, 20, 11, 473, DateTimeKind.Local).AddTicks(2520), 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 21, 16, 20, 11, 473, DateTimeKind.Local).AddTicks(2650), 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000300",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 21, 16, 20, 11, 473, DateTimeKind.Local).AddTicks(2800), 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000400",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 21, 16, 20, 11, 473, DateTimeKind.Local).AddTicks(2890), 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000500",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 21, 16, 20, 11, 473, DateTimeKind.Local).AddTicks(2980), 0m });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000002", "733a8b9d-197d-486a-a82f-3e034c6f4d11" },
                    { "00000000-0000-0000-0000-000000000003", "733a8b9d-197d-486a-a82f-3e034c6f4d11" },
                    { "00000000-0000-0000-0000-000000000004", "353d5cf4-8ed9-4622-97d4-dbf0959ec233" },
                    { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "78943822-274e-434a-817a-38d7801b07df" },
                    { "00000000-0000-0000-0000-000000000001", "78943822-274e-434a-817a-38d7801b07df" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "5e9f6f77-fb49-4ff4-8003-d948a8f1bed7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73243b97-52b1-41c6-8521-f455fe9072fa");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000001", "78943822-274e-434a-817a-38d7801b07df" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000002", "733a8b9d-197d-486a-a82f-3e034c6f4d11" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000003", "733a8b9d-197d-486a-a82f-3e034c6f4d11" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000004", "353d5cf4-8ed9-4622-97d4-dbf0959ec233" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "78943822-274e-434a-817a-38d7801b07df" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "353d5cf4-8ed9-4622-97d4-dbf0959ec233");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "733a8b9d-197d-486a-a82f-3e034c6f4d11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78943822-274e-434a-817a-38d7801b07df");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "Orders",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<double>(
                name: "StartPrice",
                table: "Companies",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PricePerKm",
                table: "Companies",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "CompanyId", "Created", "CustomerId", "DriverId", "Latitude", "Longitude", "PostalCode", "UserId" },
                values: new object[] { "4d6b5430-2454-45ca-9617-dff7c847abc2", "Ringlaan 33", "", "Koekelare", null, null, null, null, 51.091836999999998, 2.977001, "8680", "00000000-0000-0000-0000-000000000004" });

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4072dfba-677e-4e93-824f-9fd78badc9af", "AQAAAAEAACcQAAAAENEGXtjoEOQSE6Fg7b9W7eXDrplnYfvYi7t4pYUqQlU0F8kOne5iwNRb4EXNbfgA4g==", "c4f74d93-7603-453d-9357-fe56d7cc37e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d5937a7-d6d2-4a95-94a5-6b4c7c5bc96f", "AQAAAAEAACcQAAAAEOG4eedqntXysDxFatK3iitiOEjiAcs4/qTWG7am/UOT/2+meyAIiWzzepfNN5V6Bw==", "983fb6bc-79f2-472e-878a-7d04752aadef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3303bee4-8812-4b05-b616-c576e12502e2", "AQAAAAEAACcQAAAAEOwTcg7h1c4zZt0azkwnQBXk0t4MokxB+W50hwHB6EoWcqjPWWusGgw8jsn6bHa7Dg==", "afe78433-a36b-484d-8e6c-ed875de0354c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7e75c14-286b-4115-ba14-23ea2df43010", "AQAAAAEAACcQAAAAELKxrhUIdlzLbAy3FuJeC5/OjBFALTBXHW9KaduGs2QzgEvZ5lp8LPtlN2MdFURqKw==", "3685714f-f24c-4a57-987c-98614d272324" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fcfde87-c155-4ab9-9863-ca903fd2f88c", "AQAAAAEAACcQAAAAEJGb24UAMV6DCdVYaBQPpgvwC2gEKte2pjXwJZ9CbT5wKzwyQ6PUQuGVZG9jVSoNog==", "c5916563-0a5f-4348-9579-dec0c4ca19c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0777832c-230e-46a4-85a9-4e9325fa797f", "AQAAAAEAACcQAAAAEHmysxuC/mR9V+tL/72kctynuJKT5W4ZcJHWeUI79PxTkM51IhshrnDOsY1Y/iatqg==", "d4f4b0d3-8058-417e-a237-1b4c3e628f7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fa5c7f7-1188-4376-a1fb-ae8cda2a1beb", "AQAAAAEAACcQAAAAEBHvkvceoVf8G5juemQ0YoXrod/9GUAibscT3z8Dji1cqBOh5ebhM62wXEltJ78ctw==", "e1dcc856-7afb-4a19-aa4c-b42f915f753b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f754c67-c4b6-4f23-9300-0fd2529d6dbf", "AQAAAAEAACcQAAAAEA0LsZINHAwtjnL6tiiDE6Y9zMfmkFzaAFg4Keeb0umbqyaGSKMPTTOhxQLPkma8KA==", "28d4a26d-f7f5-40e7-bf55-a5cf9b2a7da9" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                columns: new[] { "Created", "PricePerKm", "StartPrice" },
                values: new object[] { new DateTime(2020, 4, 26, 1, 49, 39, 943, DateTimeKind.Local).AddTicks(6400), 2.0, 5.0 });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                columns: new[] { "Created", "PricePerKm", "StartPrice" },
                values: new object[] { new DateTime(2020, 4, 26, 1, 49, 39, 943, DateTimeKind.Local).AddTicks(6610), 1.5, 10.0 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "Created",
                value: new DateTime(2020, 4, 26, 1, 49, 39, 943, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "Created",
                value: new DateTime(2020, 4, 26, 1, 49, 39, 943, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "Created",
                value: new DateTime(2020, 4, 26, 1, 49, 39, 943, DateTimeKind.Local).AddTicks(8740));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                column: "Created",
                value: new DateTime(2020, 4, 26, 1, 49, 39, 943, DateTimeKind.Local).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "Created",
                value: new DateTime(2020, 4, 26, 1, 49, 39, 944, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "Created",
                value: new DateTime(2020, 4, 26, 1, 49, 39, 944, DateTimeKind.Local).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 4, 26, 1, 49, 39, 944, DateTimeKind.Local).AddTicks(3680), 0.0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 4, 26, 1, 49, 39, 944, DateTimeKind.Local).AddTicks(3850), 0.0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000300",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 4, 26, 1, 49, 39, 944, DateTimeKind.Local).AddTicks(3950), 0.0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000400",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 4, 26, 1, 49, 39, 944, DateTimeKind.Local).AddTicks(4050), 0.0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000500",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 4, 26, 1, 49, 39, 944, DateTimeKind.Local).AddTicks(4150), 0.0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000002", "08517b2f-66c3-468d-a5fc-c0d9bbba6208" },
                    { "00000000-0000-0000-0000-000000000003", "08517b2f-66c3-468d-a5fc-c0d9bbba6208" },
                    { "00000000-0000-0000-0000-000000000004", "ae39515f-29fc-49c4-95f5-e18f2ec7acdb" },
                    { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "565e1f6e-9348-46ef-9cc0-ed93f8bba435" },
                    { "00000000-0000-0000-0000-000000000001", "565e1f6e-9348-46ef-9cc0-ed93f8bba435" }
                });
        }
    }
}
