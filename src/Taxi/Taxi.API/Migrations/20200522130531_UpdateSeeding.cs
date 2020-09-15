using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.API.Migrations
{
    public partial class UpdateSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "d45d93ab-43cb-4bca-bea2-a8de4acf6a18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7624362b-3a70-424b-b146-fbe91710a51f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000001", "2d9c787d-7283-4a0b-8ef5-9426d610833c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000002", "cf3fb59e-9702-4bb0-b496-12168b48986d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000003", "cf3fb59e-9702-4bb0-b496-12168b48986d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000004", "d7811001-ce9a-4ff5-8195-48e2e947edc4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "2d9c787d-7283-4a0b-8ef5-9426d610833c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d9c787d-7283-4a0b-8ef5-9426d610833c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf3fb59e-9702-4bb0-b496-12168b48986d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7811001-ce9a-4ff5-8195-48e2e947edc4");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Drivers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Companies",
                nullable: true);

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
                value: new DateTime(2020, 5, 22, 15, 5, 31, 42, DateTimeKind.Local).AddTicks(360));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 42, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "Created", "Email", "PhoneNumber" },
                values: new object[] { new DateTime(2020, 5, 22, 15, 5, 31, 53, DateTimeKind.Local).AddTicks(570), "durnez.anthony@gmail.com", "+32497645255" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                columns: new[] { "Created", "Email", "PhoneNumber" },
                values: new object[] { new DateTime(2020, 5, 22, 15, 5, 31, 53, DateTimeKind.Local).AddTicks(690), "customer7@taxi.com", "+32497645255" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                columns: new[] { "Created", "Email", "PhoneNumber" },
                values: new object[] { new DateTime(2020, 5, 22, 15, 5, 31, 53, DateTimeKind.Local).AddTicks(860), "customer8@taxi.com", "+32497645255" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                columns: new[] { "Created", "Email", "PhoneNumber" },
                values: new object[] { new DateTime(2020, 5, 22, 15, 5, 31, 53, DateTimeKind.Local).AddTicks(420), "durnez.robbe@hotmail.com", "+32497635255" });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 57, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 57, DateTimeKind.Local).AddTicks(400));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 69, DateTimeKind.Local).AddTicks(2320));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 69, DateTimeKind.Local).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000300",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 69, DateTimeKind.Local).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000400",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 69, DateTimeKind.Local).AddTicks(2640));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000500",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 5, 31, 69, DateTimeKind.Local).AddTicks(2790));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "CompanyId", "Created", "CustomerId", "DriverId", "Latitude", "Longitude", "PostalCode", "UserId" },
                values: new object[] { "d45d93ab-43cb-4bca-bea2-a8de4acf6a18", "Ringlaan 33", "", "Koekelare", null, null, null, null, 51.091836999999998, 2.977001, "8680", "00000000-0000-0000-0000-000000000004" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7624362b-3a70-424b-b146-fbe91710a51f", "8ad4ea5e-7078-4bd3-926f-c88f15f4f6d6", "Admin", "ADMIN" },
                    { "cf3fb59e-9702-4bb0-b496-12168b48986d", "cdb3a32a-d0b7-4d81-a2d3-6bc02c27c5ec", "Driver", "DRIVER" },
                    { "d7811001-ce9a-4ff5-8195-48e2e947edc4", "33d3beff-c5dc-4ebf-8802-3f4966268cfa", "Company", "COMPANY" },
                    { "2d9c787d-7283-4a0b-8ef5-9426d610833c", "689481d7-d445-4c87-9e5e-f29b1177841e", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0858e353-62f1-4ba6-8f35-1e847f9f4f4d", "AQAAAAEAACcQAAAAEENgEWr8YeOnZYw8rPPiMyQCv5f0G2SJwZLmREdS028zUJsMQ80pwpn/EB+I/YLvdw==", "70fffd83-72c6-4d02-8489-eaa8b1ea1016" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99a5048a-3832-4be9-94f2-f8472adc1488", "AQAAAAEAACcQAAAAEPXbJ8xJhn0PfQhnpysQwUFdh1mqoVHnnvhzBSj4tpeeViP2QHgckpJ5ZoU2IUV0vQ==", "caae7214-53f9-49c6-ad26-70a84d3f576a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce26d13b-1263-4a77-ae85-78954730126d", "AQAAAAEAACcQAAAAECFPJKIVZqhUlyI1vdwaMtA6tv4xHyJWYERN+vlMjPcRg5ic4QvvpEvbA0QVycVUhg==", "17515719-b301-41ab-a300-7dcc12ccaaad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0bc9ea3e-fc07-4914-9160-a06b83496f14", "AQAAAAEAACcQAAAAEKTV8153XlLcqEddZwinDBLKxOVU7nGQqJGA37SvKf4jiAvLLRATpkFvV+8V2qQPvg==", "736c0735-e94c-4adf-8779-a4b38a4f6acb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce689494-b28d-432f-b3d8-7ef7addaf64a", "AQAAAAEAACcQAAAAEFs5kNdeJyv0nA4Lel1vJnD6/cP+m1gWS9dFmTQRVatyXyo1npbJeemZneuUKDJZSA==", "9dc49ae5-c01a-4e73-a55e-575a630a70c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb57be1b-5382-4458-99be-a4faffbe96db", "AQAAAAEAACcQAAAAEO+CvndtQOFqc3wIbD1R3+nXthQj8i1lcyTp/3bCHOdDYkqUPlgcO+wh2pb5NoVRiw==", "42f392c5-0297-459f-bc14-5359d85d5664" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee42fe49-5182-4bc7-ac46-b28734b190de", "AQAAAAEAACcQAAAAEEdlOmA0g4ZFa/XsW48335ce27qxrNEcJ68wOH596NzpZtJXRTC+wLughgb5nhzEag==", "60d90220-927d-4d3c-83fd-0c27ba62918e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00fec0e9-27ad-4575-8604-f5c7ae41072b", "AQAAAAEAACcQAAAAEJ3Eqjf/sTpYiOHYAfbHjk7HIwAHKubmRvnxchBbrvazCY24GsHHRuQ7+zmLlQ6VNA==", "7c017b27-c7f8-4d6f-be08-4452dbb45c9d" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 35, 354, DateTimeKind.Local).AddTicks(8900));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 35, 354, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "Created", "Email" },
                values: new object[] { new DateTime(2020, 5, 22, 15, 1, 35, 355, DateTimeKind.Local).AddTicks(1710), null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                columns: new[] { "Created", "Email" },
                values: new object[] { new DateTime(2020, 5, 22, 15, 1, 35, 355, DateTimeKind.Local).AddTicks(1850), null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                columns: new[] { "Created", "Email" },
                values: new object[] { new DateTime(2020, 5, 22, 15, 1, 35, 355, DateTimeKind.Local).AddTicks(1980), null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                columns: new[] { "Created", "Email" },
                values: new object[] { new DateTime(2020, 5, 22, 15, 1, 35, 355, DateTimeKind.Local).AddTicks(1560), null });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 35, 355, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 35, 355, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 35, 355, DateTimeKind.Local).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 35, 355, DateTimeKind.Local).AddTicks(7220));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000300",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 35, 355, DateTimeKind.Local).AddTicks(7320));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000400",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 35, 355, DateTimeKind.Local).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000500",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 35, 355, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000002", "cf3fb59e-9702-4bb0-b496-12168b48986d" },
                    { "00000000-0000-0000-0000-000000000003", "cf3fb59e-9702-4bb0-b496-12168b48986d" },
                    { "00000000-0000-0000-0000-000000000004", "d7811001-ce9a-4ff5-8195-48e2e947edc4" },
                    { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "2d9c787d-7283-4a0b-8ef5-9426d610833c" },
                    { "00000000-0000-0000-0000-000000000001", "2d9c787d-7283-4a0b-8ef5-9426d610833c" }
                });
        }
    }
}
