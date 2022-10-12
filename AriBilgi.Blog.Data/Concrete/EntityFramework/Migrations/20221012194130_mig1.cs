using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AriBilgi.Blog.Data.Concrete.EntityFramework.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 12, 22, 41, 29, 324, DateTimeKind.Local).AddTicks(5781));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 12, 22, 41, 29, 326, DateTimeKind.Local).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 12, 22, 41, 29, 327, DateTimeKind.Local).AddTicks(7223));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 12, 22, 41, 29, 330, DateTimeKind.Local).AddTicks(183));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 12, 22, 41, 29, 328, DateTimeKind.Local).AddTicks(8427));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 15, 44, 36, 810, DateTimeKind.Local).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 15, 44, 36, 815, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 15, 44, 36, 817, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 15, 44, 36, 820, DateTimeKind.Local).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 15, 44, 36, 819, DateTimeKind.Local).AddTicks(1698));
        }
    }
}
