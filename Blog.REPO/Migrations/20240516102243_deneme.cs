using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.REPO.Migrations
{
    public partial class deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 13, 22, 43, 186, DateTimeKind.Local).AddTicks(8141));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 13, 22, 43, 186, DateTimeKind.Local).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 13, 22, 43, 186, DateTimeKind.Local).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 13, 22, 43, 186, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 13, 22, 43, 186, DateTimeKind.Local).AddTicks(8170));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 24, 20, 49, 36, 20, DateTimeKind.Local).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 24, 20, 49, 36, 20, DateTimeKind.Local).AddTicks(4605));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 3, 24, 20, 49, 36, 20, DateTimeKind.Local).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 3, 24, 20, 49, 36, 20, DateTimeKind.Local).AddTicks(4609));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 3, 24, 20, 49, 36, 20, DateTimeKind.Local).AddTicks(4610));
        }
    }
}
