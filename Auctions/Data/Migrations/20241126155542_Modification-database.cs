using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auctions.Data.Migrations
{
    /// <inheritdoc />
    public partial class Modificationdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePublication",
                table: "Actus");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Actus");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "Actus",
                newName: "ImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Actus",
                newName: "VideoUrl");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublication",
                table: "Actus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Actus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
