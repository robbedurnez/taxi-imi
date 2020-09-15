using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.API.Migrations
{
    public partial class OrderCompanyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "648f7248-de18-4e43-a412-da99b06c3bde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "882da067-62c0-480c-9d36-7e78285a6f63");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000001", "cb31cbf9-d1d2-4efe-89b1-73fdd35d905e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000002", "16f86128-b55e-411a-90e9-dbcd1f047ca2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000003", "16f86128-b55e-411a-90e9-dbcd1f047ca2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000004", "bf4a3982-42e2-4d40-9ae3-770cb32051e5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "cb31cbf9-d1d2-4efe-89b1-73fdd35d905e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16f86128-b55e-411a-90e9-dbcd1f047ca2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf4a3982-42e2-4d40-9ae3-770cb32051e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb31cbf9-d1d2-4efe-89b1-73fdd35d905e");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "CompanyId", "Created", "CustomerId", "DriverId", "Latitude", "Longitude", "PostalCode", "UserId" },
                values: new object[] { "80c54817-dd00-4558-a1b8-771716b2ae4b", "Ringlaan 33", "", "Koekelare", null, null, null, null, 51.091836999999998, 2.977001, "8680", "00000000-0000-0000-0000-000000000004" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "afb8583c-e097-49ae-bbb9-8e7343d42abf", "e31d4d6e-9eb9-46cf-a0e6-9db51fb41633", "Admin", "ADMIN" },
                    { "76fe4c8b-0617-49c1-b0cf-75084ff238c0", "06fa4098-1df4-4600-8b76-852aa871a81a", "Driver", "DRIVER" },
                    { "c68a9ff4-1cbb-4b46-abe8-b86fc5bb47c2", "a05e2696-5ef2-423a-8ac3-2aadac354b6c", "Company", "COMPANY" },
                    { "f242fb06-9b03-421e-8e4f-da9aa3e30db7", "6a01fda7-de81-4ae8-a169-1f67e9548004", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bbdbb4d-b703-4038-b2b7-901dc7264a24", "AQAAAAEAACcQAAAAEIs7HX4zpwL0lhUKEkEGPpQnzZm4BmhLbTDgdXpnQIBILfWjiYeFRUG43Ze+HK+8eQ==", "f1ed9849-e79d-4d3e-8d95-dcd23aaad959" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "449a0d26-0821-4735-9dfc-6bb4dfc23f87", "AQAAAAEAACcQAAAAEPwIWoEaAh8J4J1Kl1wgK+LsP5Dh84IiiA+PRv/cY7pYQy2WBbUKdXIDSMv3099Jtg==", "e9d371d2-c19d-4aff-a1e7-58a550c8ae75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fda93ba3-5c2e-478a-8159-f1521891f8a1", "AQAAAAEAACcQAAAAEMxleN1E78ZCC/neB+NYKU162RCoWQqcV/+gD2qkmt0E8WxgXj5NRPt4HtgKnkiOtw==", "89eead78-777c-471a-b315-3cce3d9f226d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cbcfa06-770c-4dff-879b-58d34819e4b7", "AQAAAAEAACcQAAAAEKOe9HDFi+ysEteyWd7N1OOWg8fO3gcy6uqV5hrIeLIV2oYcIRMC3bfcWFxEr7U6KA==", "da449b93-625f-49e6-93e6-050f30664421" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13ffd37a-eb42-4976-9a1d-53ba409783d5", "AQAAAAEAACcQAAAAENZs2TUKC5+fdfhArryfALh4/Sqf29gWofAhLOUWjxdMCv9Zb9+f1f+Ty0jOmt6UEg==", "763c23df-852d-46ef-adb2-0c64b9eea6a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5310a94-2d21-4876-882e-f85946819a72", "AQAAAAEAACcQAAAAEBRtvUPKC0P777embYBXAZKF9pTCm/ICicENaFa1ersk7ZlKJoOIMCTBzTtGoe2d3w==", "6d453c21-06c8-447e-87e8-02042aef8c7d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2c4fdef-122f-458f-b20f-d8334b7549cb", "AQAAAAEAACcQAAAAEERbgzuQCWFo1pru602SnDRVFNF+e8nKV8pVsAjXZnfnxSOcJY3iORdEM7JsSQPuvQ==", "4a185de8-681d-4bf5-afd1-96eace303b25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53889ba1-0407-4f27-8807-5257a995263a", "AQAAAAEAACcQAAAAEL3XvZu4GouGHTXM0cv1hFjsJQKdfmI0Pjz4xMuGb5PX1RI1/0oG2rdlZ0UdlSGGJg==", "3295901d-c024-4a13-a7a7-897e2b4f5d97" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                column: "Created",
                value: new DateTime(2020, 6, 1, 13, 16, 30, 967, DateTimeKind.Local).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "Created",
                value: new DateTime(2020, 6, 1, 13, 16, 30, 967, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "Created",
                value: new DateTime(2020, 6, 1, 13, 16, 30, 981, DateTimeKind.Local).AddTicks(5380));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "Created",
                value: new DateTime(2020, 6, 1, 13, 16, 30, 981, DateTimeKind.Local).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "Created",
                value: new DateTime(2020, 6, 1, 13, 16, 30, 981, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                column: "Created",
                value: new DateTime(2020, 6, 1, 13, 16, 30, 981, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "Created",
                value: new DateTime(2020, 6, 1, 13, 16, 30, 986, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "Created",
                value: new DateTime(2020, 6, 1, 13, 16, 30, 986, DateTimeKind.Local).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 6, 1, 13, 16, 31, 2, DateTimeKind.Local).AddTicks(2760) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 6, 1, 13, 16, 31, 2, DateTimeKind.Local).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000300",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 6, 1, 13, 16, 31, 2, DateTimeKind.Local).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000400",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 6, 1, 13, 16, 31, 2, DateTimeKind.Local).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000500",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 6, 1, 13, 16, 31, 2, DateTimeKind.Local).AddTicks(3440) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000002", "76fe4c8b-0617-49c1-b0cf-75084ff238c0" },
                    { "00000000-0000-0000-0000-000000000003", "76fe4c8b-0617-49c1-b0cf-75084ff238c0" },
                    { "00000000-0000-0000-0000-000000000004", "c68a9ff4-1cbb-4b46-abe8-b86fc5bb47c2" },
                    { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "f242fb06-9b03-421e-8e4f-da9aa3e30db7" },
                    { "00000000-0000-0000-0000-000000000001", "f242fb06-9b03-421e-8e4f-da9aa3e30db7" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "80c54817-dd00-4558-a1b8-771716b2ae4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afb8583c-e097-49ae-bbb9-8e7343d42abf");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000001", "f242fb06-9b03-421e-8e4f-da9aa3e30db7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000002", "76fe4c8b-0617-49c1-b0cf-75084ff238c0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000003", "76fe4c8b-0617-49c1-b0cf-75084ff238c0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000004", "c68a9ff4-1cbb-4b46-abe8-b86fc5bb47c2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "f242fb06-9b03-421e-8e4f-da9aa3e30db7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76fe4c8b-0617-49c1-b0cf-75084ff238c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c68a9ff4-1cbb-4b46-abe8-b86fc5bb47c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f242fb06-9b03-421e-8e4f-da9aa3e30db7");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "CompanyId", "Created", "CustomerId", "DriverId", "Latitude", "Longitude", "PostalCode", "UserId" },
                values: new object[] { "648f7248-de18-4e43-a412-da99b06c3bde", "Ringlaan 33", "", "Koekelare", null, null, null, null, 51.091836999999998, 2.977001, "8680", "00000000-0000-0000-0000-000000000004" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "882da067-62c0-480c-9d36-7e78285a6f63", "71ef1cf2-bab0-4303-819e-d58ba6036dc8", "Admin", "ADMIN" },
                    { "16f86128-b55e-411a-90e9-dbcd1f047ca2", "d288809f-7bb5-43ba-8b4b-9c08328e2869", "Driver", "DRIVER" },
                    { "bf4a3982-42e2-4d40-9ae3-770cb32051e5", "3399aa81-10db-49aa-befd-1e9526f4ae5f", "Company", "COMPANY" },
                    { "cb31cbf9-d1d2-4efe-89b1-73fdd35d905e", "2bc0b3e6-ef1e-46d8-a5f6-5e8e0ba676b6", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fd35c7c-37d1-4bae-947f-d6839d99ba79", "AQAAAAEAACcQAAAAEPWdeaHhieUzd00sgX7qW1JWagN5zHLf1fjPZ6yidhfbbHagWMprtM59BvwEZVj7UQ==", "505e9a21-884e-434a-b074-09e790c9ec9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "592e2efc-dcc4-475b-bab3-79269735f913", "AQAAAAEAACcQAAAAECm9fBR0XhXCxW+hz6zd6YNBRRsuh5b7JnCu+NNGqcWx1U7BWh1RS4d7ztwnQIYuDg==", "8e57b814-0bd9-45d4-a97b-26609bb76c16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc4b98df-3e48-4d73-aa78-8d7beada6067", "AQAAAAEAACcQAAAAEM/EjliIIB6+2m16oz8D0sZpcTX0wT/IUbT9E0Z6YrZk2iBOb4zocLZnPVLcf9agsg==", "66622808-c489-4ce3-9325-223dadd84f45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb4b6482-88a3-49ad-8b23-1e5fbd3c4d5c", "AQAAAAEAACcQAAAAEAoP+Fwe0SQHhAAQLho2j+2f97aCwck27KpZXENKuP9OViaAzslvhXu11IZ8Ly5D/w==", "5a6f6b1c-8598-4412-bbec-a0140f9c5b7e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0caa4a6-634e-421a-a65b-f1f7fd9880e4", "AQAAAAEAACcQAAAAENfAffbUv10inPj4wSTtIDsa8VaizNC2nzccJBw1KArfvugm8n3cUeq4xrok6rV/Cg==", "4eaf9208-ea86-4c25-90e3-59ac8e3776f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6b8cba1-e422-41f2-92f7-fe0b2eba6ae9", "AQAAAAEAACcQAAAAEJ3sSRaEUwDxS/FAc4/7OLnBq4t50ZGy8RRI1AqtQgLzyJLGf0SZ6FzB8THeHiQ9xA==", "349e613d-671d-4943-b233-a9a15d5eaf50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8ee4b48-d483-45aa-abfd-eb87060de1fa", "AQAAAAEAACcQAAAAEDVCaFsEK2XxH/lWJcMS3nR6GG6A1Qc7k8KSQADyxGG2coXZUy3TSgNCvK3/9B+qeQ==", "83c6836b-a440-4f88-bf1f-66a36e8243b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00dfc83e-68db-4115-82d3-343309811c3a", "AQAAAAEAACcQAAAAEPRocAogZDs6vAYre678rH7CLUfCixw0gvMo/pfIBFPy7cmjgxXBSaEChLCIb36Sig==", "f2d2309d-25b6-4ed6-a172-00d07c34e46a" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 32, 278, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 32, 279, DateTimeKind.Local).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 32, 279, DateTimeKind.Local).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 32, 279, DateTimeKind.Local).AddTicks(2430));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 32, 279, DateTimeKind.Local).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 32, 279, DateTimeKind.Local).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 32, 279, DateTimeKind.Local).AddTicks(5540));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 32, 279, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { null, new DateTime(2020, 5, 23, 15, 1, 32, 279, DateTimeKind.Local).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { null, new DateTime(2020, 5, 23, 15, 1, 32, 279, DateTimeKind.Local).AddTicks(8960) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000300",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { null, new DateTime(2020, 5, 23, 15, 1, 32, 279, DateTimeKind.Local).AddTicks(9150) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000400",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { null, new DateTime(2020, 5, 23, 15, 1, 32, 279, DateTimeKind.Local).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000500",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { null, new DateTime(2020, 5, 23, 15, 1, 32, 279, DateTimeKind.Local).AddTicks(9380) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000002", "16f86128-b55e-411a-90e9-dbcd1f047ca2" },
                    { "00000000-0000-0000-0000-000000000003", "16f86128-b55e-411a-90e9-dbcd1f047ca2" },
                    { "00000000-0000-0000-0000-000000000004", "bf4a3982-42e2-4d40-9ae3-770cb32051e5" },
                    { "31588e97-5c6b-48dd-89a1-edd92deb3bcb", "cb31cbf9-d1d2-4efe-89b1-73fdd35d905e" },
                    { "00000000-0000-0000-0000-000000000001", "cb31cbf9-d1d2-4efe-89b1-73fdd35d905e" }
                });
        }
    }
}
