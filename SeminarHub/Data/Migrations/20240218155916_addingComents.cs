using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeminarHub.Data.Migrations
{
    public partial class addingComents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Seminars",
                comment: "Seminars");

            migrationBuilder.AlterTable(
                name: "Categories",
                comment: "Seminar Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "Seminars",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Seminar Topic",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "Seminars",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Seminar ForeignKey to Organizer",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Lecturer",
                table: "Seminars",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                comment: "Seminar Lecturer",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Seminars",
                type: "int",
                nullable: false,
                comment: "Seminar Duration",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Seminars",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Seminar Details",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAndTime",
                table: "Seminars",
                type: "datetime2",
                nullable: false,
                comment: "Seminar DateAndTime",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Seminars",
                type: "int",
                nullable: false,
                comment: "Seminar ForeignKey to Category",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Seminars",
                type: "int",
                nullable: false,
                comment: "Seminar Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Catogory name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                comment: "Category Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Seminars",
                oldComment: "Seminars");

            migrationBuilder.AlterTable(
                name: "Categories",
                oldComment: "Seminar Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "Seminars",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Seminar Topic");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "Seminars",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Seminar ForeignKey to Organizer");

            migrationBuilder.AlterColumn<string>(
                name: "Lecturer",
                table: "Seminars",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldComment: "Seminar Lecturer");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Seminars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Seminar Duration");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Seminars",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Seminar Details");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAndTime",
                table: "Seminars",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Seminar DateAndTime");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Seminars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Seminar ForeignKey to Category");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Seminars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Seminar Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Catogory name");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Category Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
