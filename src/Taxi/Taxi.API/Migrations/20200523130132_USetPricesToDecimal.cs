using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.API.Migrations
{
    public partial class USetPricesToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Companies");

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
                value: new DateTime(2020, 5, 23, 15, 1, 31, 804, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 31, 804, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 31, 819, DateTimeKind.Local).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 31, 819, DateTimeKind.Local).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 31, 819, DateTimeKind.Local).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 31, 819, DateTimeKind.Local).AddTicks(310));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 31, 823, DateTimeKind.Local).AddTicks(7170));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "Created",
                value: new DateTime(2020, 5, 23, 15, 1, 31, 823, DateTimeKind.Local).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { null, new DateTime(2020, 5, 23, 15, 1, 31, 841, DateTimeKind.Local).AddTicks(990) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                columns: new[] { "CompanyId", "Created", "TotalPrice" },
                values: new object[] { null, new DateTime(2020, 5, 23, 15, 1, 31, 841, DateTimeKind.Local).AddTicks(1160), 20.38m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000300",
                columns: new[] { "CompanyId", "Created", "TotalPrice" },
                values: new object[] { null, new DateTime(2020, 5, 23, 15, 1, 31, 841, DateTimeKind.Local).AddTicks(1280), 21.45m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000400",
                columns: new[] { "CompanyId", "Created", "TotalPrice" },
                values: new object[] { null, new DateTime(2020, 5, 23, 15, 1, 31, 841, DateTimeKind.Local).AddTicks(1450), 19.04m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000500",
                columns: new[] { "CompanyId", "Created", "TotalPrice" },
                values: new object[] { null, new DateTime(2020, 5, 23, 15, 1, 31, 841, DateTimeKind.Local).AddTicks(1560), 22m });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

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
                value: new DateTime(2020, 5, 23, 11, 41, 45, 64, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "Created",
                value: new DateTime(2020, 5, 23, 11, 41, 45, 64, DateTimeKind.Local).AddTicks(5110));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "Created", "Email", "PhoneNumber" },
                values: new object[] { new DateTime(2020, 5, 23, 11, 41, 45, 64, DateTimeKind.Local).AddTicks(8250), "durnez.anthony@gmail.com", "+32497645255" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                columns: new[] { "Created", "Email", "PhoneNumber" },
                values: new object[] { new DateTime(2020, 5, 23, 11, 41, 45, 64, DateTimeKind.Local).AddTicks(8400), "customer7@taxi.com", "+32497645255" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                columns: new[] { "Created", "Email", "PhoneNumber" },
                values: new object[] { new DateTime(2020, 5, 23, 11, 41, 45, 64, DateTimeKind.Local).AddTicks(8540), "customer8@taxi.com", "+32497645255" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                columns: new[] { "Created", "Email", "PhoneNumber" },
                values: new object[] { new DateTime(2020, 5, 23, 11, 41, 45, 64, DateTimeKind.Local).AddTicks(8070), "durnez.robbe@hotmail.com", "+32497635255" });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "Created",
                value: new DateTime(2020, 5, 23, 11, 41, 45, 65, DateTimeKind.Local).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "Created",
                value: new DateTime(2020, 5, 23, 11, 41, 45, 65, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                columns: new[] { "CompanyId", "Created" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 5, 23, 11, 41, 45, 65, DateTimeKind.Local).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                columns: new[] { "CompanyId", "Created", "TotalPrice" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 5, 23, 11, 41, 45, 65, DateTimeKind.Local).AddTicks(6590), 31.4m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000300",
                columns: new[] { "CompanyId", "Created", "TotalPrice" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 5, 23, 11, 41, 45, 65, DateTimeKind.Local).AddTicks(6760), 20.19m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000400",
                columns: new[] { "CompanyId", "Created", "TotalPrice" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 5, 23, 11, 41, 45, 65, DateTimeKind.Local).AddTicks(7370), 7.68m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000500",
                columns: new[] { "CompanyId", "Created", "TotalPrice" },
                values: new object[] { "00000000-0000-0000-0000-000000000004", new DateTime(2020, 5, 23, 11, 41, 45, 65, DateTimeKind.Local).AddTicks(7540), 22.76m });

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
    }
}
