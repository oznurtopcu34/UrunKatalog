using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Returns",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 341, DateTimeKind.Local).AddTicks(794),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 859, DateTimeKind.Local).AddTicks(9246));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ReturnItems",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 350, DateTimeKind.Local).AddTicks(2865),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 861, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 339, DateTimeKind.Local).AddTicks(5215),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 859, DateTimeKind.Local).AddTicks(1933));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 336, DateTimeKind.Local).AddTicks(2276),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 857, DateTimeKind.Local).AddTicks(7465));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "News",
                type: "varchar(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FAQs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 333, DateTimeKind.Local).AddTicks(7876),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 857, DateTimeKind.Local).AddTicks(755));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ContentCategories",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 332, DateTimeKind.Local).AddTicks(2204),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 856, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Complaints",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 330, DateTimeKind.Local).AddTicks(8183),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 855, DateTimeKind.Local).AddTicks(8493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 329, DateTimeKind.Local).AddTicks(8886),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 855, DateTimeKind.Local).AddTicks(2105));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Carts",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 328, DateTimeKind.Local).AddTicks(2241),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 853, DateTimeKind.Local).AddTicks(9767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CartItems",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 329, DateTimeKind.Local).AddTicks(110),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 854, DateTimeKind.Local).AddTicks(5043));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BlogsPosts",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BlogsPosts",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 327, DateTimeKind.Local).AddTicks(1315),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 853, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "BlogsPosts",
                type: "varchar(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d290cd1d-c89e-406b-95b3-ca4d7d7068f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "098e6ab0-63c5-4314-92df-c36a635b4a03");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b536f3d1-a7d3-44be-956c-bb8cc1552127");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "9c4aebad-489c-44ac-a10e-c087a83e7ee7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b254532-9949-43ed-b7e3-62084f85e4ac", "AQAAAAIAAYagAAAAEGTims41wF6he8liWU24oK1A5oOqJJfQYGzNBFs2Gk6lgPLmMS6XuRh5ptT9UuCXlA==", "19791b3d-682b-4896-b921-01e58db8b34e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "468e59d6-b54e-4684-baa7-2ac91fb3a69d", "AQAAAAIAAYagAAAAEL/9dDuE1PF1L3hxeaTxMwUsFSv0E5CXIgWEpXX2GyUsqEwGw8plQ5PK1MJr1i27wA==", "35cec112-a4aa-4449-b789-6b8cc6783707" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ff219df-12a5-4055-8ab5-dfba79e2f7a7", "AQAAAAIAAYagAAAAEPogCz0tQHpqVaU6RoFAoia+5hBEkyvljiNNdZdvV9l3Io95cC4KfHID5BbCfY+fcw==", "41749a1f-2681-476e-a063-9ea918969ff2" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 22, 32, 36, 330, DateTimeKind.Local).AddTicks(2315));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 22, 32, 36, 330, DateTimeKind.Local).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 22, 32, 36, 330, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 22, 32, 36, 330, DateTimeKind.Local).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "ContentCategories",
                keyColumn: "ContentCategoryID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 22, 32, 36, 333, DateTimeKind.Local).AddTicks(455));

            migrationBuilder.UpdateData(
                table: "ContentCategories",
                keyColumn: "ContentCategoryID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 22, 32, 36, 333, DateTimeKind.Local).AddTicks(475));

            migrationBuilder.UpdateData(
                table: "ContentCategories",
                keyColumn: "ContentCategoryID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 22, 32, 36, 333, DateTimeKind.Local).AddTicks(477));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Returns",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 859, DateTimeKind.Local).AddTicks(9246),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 341, DateTimeKind.Local).AddTicks(794));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ReturnItems",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 861, DateTimeKind.Local).AddTicks(9472),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 350, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 859, DateTimeKind.Local).AddTicks(1933),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 339, DateTimeKind.Local).AddTicks(5215));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 857, DateTimeKind.Local).AddTicks(7465),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 336, DateTimeKind.Local).AddTicks(2276));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "News",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1500)",
                oldMaxLength: 1500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FAQs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 857, DateTimeKind.Local).AddTicks(755),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 333, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ContentCategories",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 856, DateTimeKind.Local).AddTicks(4884),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 332, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Complaints",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 855, DateTimeKind.Local).AddTicks(8493),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 330, DateTimeKind.Local).AddTicks(8183));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 855, DateTimeKind.Local).AddTicks(2105),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 329, DateTimeKind.Local).AddTicks(8886));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Carts",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 853, DateTimeKind.Local).AddTicks(9767),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 328, DateTimeKind.Local).AddTicks(2241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CartItems",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 854, DateTimeKind.Local).AddTicks(5043),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 329, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BlogsPosts",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BlogsPosts",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 21, 27, 20, 853, DateTimeKind.Local).AddTicks(1543),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2025, 2, 8, 22, 32, 36, 327, DateTimeKind.Local).AddTicks(1315));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "BlogsPosts",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1500)",
                oldMaxLength: 1500);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3d25f048-2b56-410d-8fd6-d74f3aa59caf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3d740923-f12a-4ad1-b435-be3119275fdf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "3abddb25-3243-4d6d-ac1f-e2f83f1fbdcc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "09ae7520-cd47-4d46-9640-f74ccaacb668");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de34fa6f-6556-4379-8975-c335f52d23e4", "AQAAAAIAAYagAAAAEDyhY6ESps/hiKQrUse2z/lxMDUjlJskvaxKRAp9rsiI08kFkLFnfdOlQgfU/pbgQw==", "773bb8a7-c913-494b-b4e8-c09cfea51d0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3148fbf-cf12-414d-a3ec-3998c99c0383", "AQAAAAIAAYagAAAAEIgFf4se0kjiu0J0WNRj/2YcmXK08sG7ZE2YMUEgzgZyQmNY2LjN8TCDYhjakWSHgw==", "aca6392e-96aa-4d87-a55c-96df97dadc2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "480cd81a-829f-46f2-90d9-0578708cbf71", "AQAAAAIAAYagAAAAEM+Ptdzarr08Cfrq/ckjsn4fRk9kxE5H1aDuIswYSKoNfYZnaf1r8zDuYx/clJ0QTA==", "fdad7bdf-bce9-41b6-bc2e-20190d29a7b3" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 21, 27, 20, 855, DateTimeKind.Local).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 21, 27, 20, 855, DateTimeKind.Local).AddTicks(5288));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 21, 27, 20, 855, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 21, 27, 20, 855, DateTimeKind.Local).AddTicks(5291));

            migrationBuilder.UpdateData(
                table: "ContentCategories",
                keyColumn: "ContentCategoryID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 21, 27, 20, 856, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "ContentCategories",
                keyColumn: "ContentCategoryID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 21, 27, 20, 856, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "ContentCategories",
                keyColumn: "ContentCategoryID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 21, 27, 20, 856, DateTimeKind.Local).AddTicks(7723));
        }
    }
}
