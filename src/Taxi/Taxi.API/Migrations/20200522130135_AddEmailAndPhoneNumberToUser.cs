using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.API.Migrations
{
    public partial class AddEmailAndPhoneNumberToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Drivers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Drivers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Companies",
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
                value: new DateTime(2020, 5, 22, 15, 1, 34, 970, DateTimeKind.Local).AddTicks(3240));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 34, 970, DateTimeKind.Local).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 34, 981, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 34, 981, DateTimeKind.Local).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 34, 981, DateTimeKind.Local).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 34, 981, DateTimeKind.Local).AddTicks(5460));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 34, 985, DateTimeKind.Local).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 34, 985, DateTimeKind.Local).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 34, 997, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 34, 997, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000300",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 34, 997, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000400",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 34, 997, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000500",
                column: "Created",
                value: new DateTime(2020, 5, 22, 15, 1, 34, 997, DateTimeKind.Local).AddTicks(9750));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Email",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Companies");

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
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 858, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 858, DateTimeKind.Local).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 858, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 858, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 858, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 858, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 859, DateTimeKind.Local).AddTicks(610));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 859, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 859, DateTimeKind.Local).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 859, DateTimeKind.Local).AddTicks(3300));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000300",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 859, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000400",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 859, DateTimeKind.Local).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000500",
                column: "Created",
                value: new DateTime(2020, 5, 21, 16, 20, 11, 859, DateTimeKind.Local).AddTicks(3600));

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
    }
}
