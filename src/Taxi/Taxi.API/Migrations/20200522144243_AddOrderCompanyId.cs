using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.API.Migrations
{
    public partial class AddOrderCompanyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "69dfce39-1e62-4a7d-9198-6fa330a0a7dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e361c9f9-4d70-45c4-9daa-39c7d59167f8");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000001", "fa739f0f-3279-4f33-ad7d-7de5519dfb85" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000002", "09826ca7-1cba-4711-824a-d3e88a383d76" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000003", "09826ca7-1cba-4711-824a-d3e88a383d76" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000004", "3006edde-70f6-41f9-974e-8f5eb2d25712" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "fa739f0f-3279-4f33-ad7d-7de5519dfb85" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09826ca7-1cba-4711-824a-d3e88a383d76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3006edde-70f6-41f9-974e-8f5eb2d25712");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa739f0f-3279-4f33-ad7d-7de5519dfb85");

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
                value: new DateTime(2020, 5, 22, 16, 42, 43, 275, DateTimeKind.Local).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 275, DateTimeKind.Local).AddTicks(2720));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 286, DateTimeKind.Local).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 286, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 286, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 286, DateTimeKind.Local).AddTicks(2950));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 290, DateTimeKind.Local).AddTicks(2840));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "Created",
                value: new DateTime(2020, 5, 22, 16, 42, 43, 290, DateTimeKind.Local).AddTicks(3010));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 5, 22, 16, 42, 43, 302, DateTimeKind.Local).AddTicks(5380) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 5, 22, 16, 42, 43, 302, DateTimeKind.Local).AddTicks(5590) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000300",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 5, 22, 16, 42, 43, 302, DateTimeKind.Local).AddTicks(5680) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000400",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 5, 22, 16, 42, 43, 302, DateTimeKind.Local).AddTicks(5770) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000500",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 5, 22, 16, 42, 43, 302, DateTimeKind.Local).AddTicks(5850) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "69dfce39-1e62-4a7d-9198-6fa330a0a7dd", "Ringlaan 33", "", "Koekelare", null, null, null, null, 51.091836999999998, 2.977001, "8680", "00000000-0000-0000-0000-000000000004" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e361c9f9-4d70-45c4-9daa-39c7d59167f8", "6f362499-3ff6-4489-9d99-855c75249913", "Admin", "ADMIN" },
                    { "09826ca7-1cba-4711-824a-d3e88a383d76", "12d03b25-3742-43e6-9a78-31507db01bb2", "Driver", "DRIVER" },
                    { "3006edde-70f6-41f9-974e-8f5eb2d25712", "e50d098f-60d3-41cf-b0f9-e35a3290b199", "Company", "COMPANY" },
                    { "fa739f0f-3279-4f33-ad7d-7de5519dfb85", "d195bcee-e197-4a0a-bc72-a4c2f37ea199", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a8eda67-5e55-41c8-ad93-d0cf7563d151", "AQAAAAEAACcQAAAAEKB1tHE/+kiaYAPQd7Zmo7vSMQzqJxjOo9bvo1Lu0qvK/9jlhfP23xeE/bEb4+l3LA==", "79368d97-e47a-4bc0-862d-102c973909e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30791eb9-37bf-477a-be47-7299c0c1402b", "AQAAAAEAACcQAAAAEFZAbtOYgqsvz7al38auOmKTOZBDrZSCEFVUdt3w/VexPlUzQEHQCPrufrZswLJ6GA==", "a43f5389-109b-4de7-b111-8c67d78db9d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e57abaf9-6391-490a-9369-18463c538827", "AQAAAAEAACcQAAAAEO17nIyYQKheEJY37xcKuOtnmpGzzme1wWNxoTNXd+MNxwBn3f2aaMw/W3FECWhXZg==", "631c9f33-4387-42fb-b9a1-b069bf1a6321" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfeec0c2-4357-4a94-af0c-235b2fd4330e", "AQAAAAEAACcQAAAAEGADrrHWJ2GQGcPMH5Tj16XarlkTDqeYjSf1V7mnQjMbpspKTCKhvx3hw03jXGqiWQ==", "9502cd7c-a6ab-4b34-9474-1c82f63a864e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "734e437c-e952-4c14-949e-40e43278bd29", "AQAAAAEAACcQAAAAEI41wba5QCHk4FfRElwHCLOlP7S85oMFAdBtPO6u97NCKmb0Rwq8mV6m46Zgskwgxw==", "cf3662eb-e1c9-41d7-8bc6-b3bf068a0859" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6e02bf1-bd6e-4e13-a012-270fab838225", "AQAAAAEAACcQAAAAENsbph0ewS8XYhtjQglUGLZa/EUFJfLHFq1ZJotJ3m/lzd1kai5/L8k51sf6NSFdhg==", "18828d92-4e55-429a-90e0-0b28c5c01bf3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3fc0dbf-2b82-4deb-acf1-b2e7a74532e8", "AQAAAAEAACcQAAAAEAE8lWOEDYLU+kouUUPtoo5GpkRs7cpO26orE8D9Foh1Wudvi9QQtJ1Dv191R29hxg==", "ec8c5a8f-cc81-4966-b517-96daf06cae66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14a06aae-a028-435c-a4b8-1bfc8cb5b5e1", "AQAAAAEAACcQAAAAECdfjMX9Lw8MIQ0aJNAfeYjQLJMeYUb4e850mjSIs+R+Wc/IYQuXQ8iXOJQiv8U6Aw==", "ffaa1f42-e2a0-42e6-85af-1defaad9162d" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 427, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 427, DateTimeKind.Local).AddTicks(1940));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 427, DateTimeKind.Local).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 427, DateTimeKind.Local).AddTicks(4300));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 427, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 427, DateTimeKind.Local).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 427, DateTimeKind.Local).AddTicks(7270));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 427, DateTimeKind.Local).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { null, new DateTime(2020, 5, 22, 15, 5, 31, 427, DateTimeKind.Local).AddTicks(9830) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { null, new DateTime(2020, 5, 22, 15, 5, 31, 427, DateTimeKind.Local).AddTicks(9950) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000300",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { null, new DateTime(2020, 5, 22, 15, 5, 31, 428, DateTimeKind.Local).AddTicks(50) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000400",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { null, new DateTime(2020, 5, 22, 15, 5, 31, 428, DateTimeKind.Local).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000500",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { null, new DateTime(2020, 5, 22, 15, 5, 31, 428, DateTimeKind.Local).AddTicks(240) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000002", "09826ca7-1cba-4711-824a-d3e88a383d76" },
                    { "00000000-0000-0000-0000-000000000003", "09826ca7-1cba-4711-824a-d3e88a383d76" },
                    { "00000000-0000-0000-0000-000000000004", "3006edde-70f6-41f9-974e-8f5eb2d25712" },
                    { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "fa739f0f-3279-4f33-ad7d-7de5519dfb85" },
                    { "00000000-0000-0000-0000-000000000001", "fa739f0f-3279-4f33-ad7d-7de5519dfb85" }
                });
        }
    }
}
