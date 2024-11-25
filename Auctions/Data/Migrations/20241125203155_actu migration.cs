using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auctions.Data.Migrations
{
    /// <inheritdoc />
    public partial class actumigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActuId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Actus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePublication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Auteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actus_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListingsVMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingsVMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListingsVMs_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ActuId",
                table: "Comments",
                column: "ActuId");

            migrationBuilder.CreateIndex(
                name: "IX_Actus_IdentityUserId",
                table: "Actus",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingsVMs_IdentityUserId",
                table: "ListingsVMs",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Actus_ActuId",
                table: "Comments",
                column: "ActuId",
                principalTable: "Actus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Actus_ActuId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Actus");

            migrationBuilder.DropTable(
                name: "ListingsVMs");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ActuId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ActuId",
                table: "Comments");
        }
    }
}
