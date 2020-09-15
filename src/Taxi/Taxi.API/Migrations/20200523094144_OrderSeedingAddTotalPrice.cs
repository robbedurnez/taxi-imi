using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.API.Migrations
{
    public partial class OrderSeedingAddTotalPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "6c076bed-0dac-4774-a483-c8c1a4010558");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec287194-9661-4997-912c-6ee2ca038197");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000001", "12cb5833-6060-465b-92dd-a500792404d9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000002", "c636a7fa-3bd0-4f1e-a0fe-13a3a2d0c39c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000003", "c636a7fa-3bd0-4f1e-a0fe-13a3a2d0c39c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000004", "260a8a1e-93f3-44bb-8112-9050bdcfe7dc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "12cb5833-6060-465b-92dd-a500792404d9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12cb5833-6060-465b-92dd-a500792404d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "260a8a1e-93f3-44bb-8112-9050bdcfe7dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c636a7fa-3bd0-4f1e-a0fe-13a3a2d0c39c");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "CompanyId", "Created", "CustomerId", "DriverId", "Latitude", "Longitude", "PostalCode", "UserId" },
                values: new object[] { "d8fe1ae1-c963-48df-adb8-d6a1ae73f572", "Ringlaan 33", "", "Koekelare", null, null, null, null, 51.091836999999998, 2.977001, "8680", "00000000-0000-0000-0000-000000000004" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "977d1f92-5bcd-48f4-8917-783ba32a1f22", "60f595e1-bc0d-4dc1-a184-c22d30df6f0a", "Admin", "ADMIN" },
                    { "8ee00934-3964-44a7-a3b1-fb8ab8789d5c", "47adfea3-1ebc-4e7f-83f7-7f28089041f7", "Driver", "DRIVER" },
                    { "4126da1a-9871-41ac-9e38-53d46918da6f", "6051f859-7a8a-4b31-bdc9-aeecaa840967", "Company", "COMPANY" },
                    { "cfb4db8a-ac98-4759-ae91-26923ce587fd", "d39491a5-ae79-4216-830a-94288b7cb014", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f1f0cf7-fbc6-4359-bb98-4463569e2a4a", "AQAAAAEAACcQAAAAELHJY11gAlIoEElMdM8ufXFJwPrgXZxG+UCwwkbxhoprWu47eyByVvvVp/YLcRCsxw==", "779aa9dd-3b9e-438c-a47c-a1f66c1dfaf8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17e4c56a-08eb-4923-8391-9cabc0d90bc1", "AQAAAAEAACcQAAAAELnaXeCFcPgUbpmOi1HPN+U9KmEK8zB5QiczXL147ngya3LXNHM4oOYgR6E7xJCTvg==", "46e68dc1-b17e-4905-adbe-3820de3cd2c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6a56cb6-1f5d-4887-a554-ac5f5db43493", "AQAAAAEAACcQAAAAEKpVU8pvj5FTbCl2xFIluey5oSP10lXetZctfim4BO4g8izOV85KOvskI5I4A03mSQ==", "7f43d991-7f56-4948-86f4-a02193e04a19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c116f1d5-4f68-480e-8826-8ed96c6add0c", "AQAAAAEAACcQAAAAEGYUBA4DkH3C0+WYD0wv9S7NGruNDwmNCrywaV4E9g2O1cbDt8UR9HNMvwC8gHeX0g==", "ee954aa7-ae68-47ad-bdde-ae999ffd3621" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e922976-3e01-487e-9209-6ff3b8d2b406", "AQAAAAEAACcQAAAAEDrMI1Oev4xvF+gX6qBm7qg6CyWUvSXHsSYLQ38WjgAzEAebHpyD42OB6108bxMV6g==", "0a1b1c9e-7172-4e20-bde3-8bc8d307c99c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9e00567-8f1c-4263-8795-b9632834cf6b", "AQAAAAEAACcQAAAAEKArBKUtTTjjDenIT/C0te32QkXkYGZF2pzFbSS+0HzNyE7B5Q34uVQpem3A2OVwKw==", "f101677e-e18d-41b7-8df4-ab9a445f83ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97e128be-57e1-4b4c-9e7e-58545dc3a41b", "AQAAAAEAACcQAAAAEFQ5xB9f1NOuf6Qc3puP9f1VIymyYlADTLWmcCvKq/P6UkGTe0HJHuCSKQouykt0Yw==", "ced52978-7fc3-419b-8eb0-95327416f943" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a420c57-f1b8-4bfd-addd-ebbcacb85f4d", "AQAAAAEAACcQAAAAEO+59pruYsFWV/01ckw7waF8IpRhwA8MoaFMLOUO7jw1YkTa+K/DH9wQXF4jyuUiKg==", "169c48e4-b828-43fe-af25-8bb82a67fe2b" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                column: "Created",
                value: new DateTime(2020, 5, 23, 11, 41, 44, 655, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "Created",
                value: new DateTime(2020, 5, 23, 11, 41, 44, 655, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "Created",
                value: new DateTime(2020, 5, 23, 11, 41, 44, 670, DateTimeKind.Local).AddTicks(3020));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "Created",
                value: new DateTime(2020, 5, 23, 11, 41, 44, 670, DateTimeKind.Local).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "Created",
                value: new DateTime(2020, 5, 23, 11, 41, 44, 670, DateTimeKind.Local).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                column: "Created",
                value: new DateTime(2020, 5, 23, 11, 41, 44, 670, DateTimeKind.Local).AddTicks(2820));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "Created",
                value: new DateTime(2020, 5, 23, 11, 41, 44, 675, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "Created",
                value: new DateTime(2020, 5, 23, 11, 41, 44, 675, DateTimeKind.Local).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 23, 11, 41, 44, 691, DateTimeKind.Local).AddTicks(6770), 25m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 23, 11, 41, 44, 691, DateTimeKind.Local).AddTicks(6940), 31.4m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000300",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 23, 11, 41, 44, 691, DateTimeKind.Local).AddTicks(7050), 20.19m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000400",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 23, 11, 41, 44, 691, DateTimeKind.Local).AddTicks(7210), 7.68m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000500",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 23, 11, 41, 44, 691, DateTimeKind.Local).AddTicks(7320), 22.76m });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000002", "8ee00934-3964-44a7-a3b1-fb8ab8789d5c" },
                    { "00000000-0000-0000-0000-000000000003", "8ee00934-3964-44a7-a3b1-fb8ab8789d5c" },
                    { "00000000-0000-0000-0000-000000000004", "4126da1a-9871-41ac-9e38-53d46918da6f" },
                    { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "cfb4db8a-ac98-4759-ae91-26923ce587fd" },
                    { "00000000-0000-0000-0000-000000000001", "cfb4db8a-ac98-4759-ae91-26923ce587fd" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "d8fe1ae1-c963-48df-adb8-d6a1ae73f572");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "977d1f92-5bcd-48f4-8917-783ba32a1f22");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000001", "cfb4db8a-ac98-4759-ae91-26923ce587fd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000002", "8ee00934-3964-44a7-a3b1-fb8ab8789d5c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000003", "8ee00934-3964-44a7-a3b1-fb8ab8789d5c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000004", "4126da1a-9871-41ac-9e38-53d46918da6f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "cfb4db8a-ac98-4759-ae91-26923ce587fd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4126da1a-9871-41ac-9e38-53d46918da6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ee00934-3964-44a7-a3b1-fb8ab8789d5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfb4db8a-ac98-4759-ae91-26923ce587fd");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "CompanyId", "Created", "CustomerId", "DriverId", "Latitude", "Longitude", "PostalCode", "UserId" },
                values: new object[] { "6c076bed-0dac-4774-a483-c8c1a4010558", "Ringlaan 33", "", "Koekelare", null, null, null, null, 51.091836999999998, 2.977001, "8680", "00000000-0000-0000-0000-000000000004" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ec287194-9661-4997-912c-6ee2ca038197", "2b9ba29d-d02d-45d1-af6a-64de092c8fce", "Admin", "ADMIN" },
                    { "c636a7fa-3bd0-4f1e-a0fe-13a3a2d0c39c", "8d1a8faa-b961-47f5-a25d-2cfba646c993", "Driver", "DRIVER" },
                    { "260a8a1e-93f3-44bb-8112-9050bdcfe7dc", "a3e3bc38-715f-482c-b3ab-7ffd7bca32c6", "Company", "COMPANY" },
                    { "12cb5833-6060-465b-92dd-a500792404d9", "20493452-2ff0-440e-b333-a2c799869623", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e08a65b8-310d-4461-a023-8b9200bfe4b0", "AQAAAAEAACcQAAAAENUFPFGz4imrn7dehc5wo3gKWJ2QNlUmVBYL5CVSEI/xReJ5ucPlMPpoO2pAkA7Jrw==", "1a5a9ef7-b35f-4fef-8891-d817fe7de8f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "725a545c-38cf-4a8d-a7c5-53431912bdf8", "AQAAAAEAACcQAAAAEC3qcaGMAOs11x3G+O5SLucQVxHv+zPw0X0iSUR30FIpXIkv8d9GYVPIXYs0AfJn8g==", "66a06915-882c-4c13-a0e3-50d3b9e98ff8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "856d71bd-2934-47de-8a0a-5f3e8ff1af81", "AQAAAAEAACcQAAAAEBxBkqt1qNrHzvzzurV8qHc4JOgYhTTPZseZhGVhePUHYLk8iTFnnqAUREn8c8/vcg==", "c5d769a0-2a1d-4cd9-9d9b-201a7cf975b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d033701-e9d5-4802-b759-545721ef81be", "AQAAAAEAACcQAAAAEAns0/E2k9F08YhZS29W3/KicnQJtLDTjTmxm4Q8NdPapkuX79xYw8whKGe1FD/7Dg==", "fa71ca69-148c-4def-aa91-46ac4cc1028c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e618b08e-2e78-4f8a-8236-623633f5b07c", "AQAAAAEAACcQAAAAEOY35O8QDP2cWgqzaC5Z7ukEthAczy9QoTXFBRDtcEwJBFV09XR9/IEk01ccvuQi+Q==", "0f1b8616-7684-42d9-b007-8c25a0ddefe4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9c810d9-74b4-450a-86b7-c985bc6f905e", "AQAAAAEAACcQAAAAENw77v9h1aIw0OScZv80RCYw8Rg3xKlxojh4coHdOoJt5RiL3rZI23M9B7p47ncc2Q==", "95e3d366-2fb9-451f-9f15-febc0cd569f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce131d90-aea6-4402-b250-312838f80bdc", "AQAAAAEAACcQAAAAEFJOBrU9oCH2fSF3Bx14to2KJRLiSxOmMpVukpvIhaGhg6pME8vpJliwjnoUogou7Q==", "833b8809-8f8f-4f99-b363-af2daa745766" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7e56ac0-baec-4e2e-8e3c-c6c43a745ae3", "AQAAAAEAACcQAAAAEFapkP8+DyTMdaudaqMZ1perHj9T/375RUJWIJyHG37Z7f4Wgm8Bbal55NOQjv/2rQ==", "5940e791-5577-4d4c-a5f7-dd40625c25bd" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 655, DateTimeKind.Local).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 655, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 655, DateTimeKind.Local).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 655, DateTimeKind.Local).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 655, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 655, DateTimeKind.Local).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 655, DateTimeKind.Local).AddTicks(5430));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 655, DateTimeKind.Local).AddTicks(5610));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 22, 16, 42, 43, 655, DateTimeKind.Local).AddTicks(7990), 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 22, 16, 42, 43, 655, DateTimeKind.Local).AddTicks(8140), 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000300",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 22, 16, 42, 43, 655, DateTimeKind.Local).AddTicks(8250), 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000400",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 22, 16, 42, 43, 655, DateTimeKind.Local).AddTicks(8340), 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000500",
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2020, 5, 22, 16, 42, 43, 655, DateTimeKind.Local).AddTicks(8440), 0m });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000002", "c636a7fa-3bd0-4f1e-a0fe-13a3a2d0c39c" },
                    { "00000000-0000-0000-0000-000000000003", "c636a7fa-3bd0-4f1e-a0fe-13a3a2d0c39c" },
                    { "00000000-0000-0000-0000-000000000004", "260a8a1e-93f3-44bb-8112-9050bdcfe7dc" },
                    { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "12cb5833-6060-465b-92dd-a500792404d9" },
                    { "00000000-0000-0000-0000-000000000001", "12cb5833-6060-465b-92dd-a500792404d9" }
                });
        }
    }
}
