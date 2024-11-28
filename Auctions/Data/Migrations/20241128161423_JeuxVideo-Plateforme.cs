using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auctions.Data.Migrations
{
    /// <inheritdoc />
    public partial class JeuxVideoPlateforme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Listings_ListingId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "ListingId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ActusVMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Auteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActusVMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActusVMs_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JeuxVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeuxVideos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plateformes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plateformes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JeuxVideoPlateformes",
                columns: table => new
                {
                    JeuxVideoId = table.Column<int>(type: "int", nullable: false),
                    PlateformeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeuxVideoPlateformes", x => new { x.JeuxVideoId, x.PlateformeId });
                    table.ForeignKey(
                        name: "FK_JeuxVideoPlateformes_JeuxVideos_JeuxVideoId",
                        column: x => x.JeuxVideoId,
                        principalTable: "JeuxVideos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JeuxVideoPlateformes_Plateformes_PlateformeId",
                        column: x => x.PlateformeId,
                        principalTable: "Plateformes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "JeuxVideos",
                columns: new[] { "Id", "Description", "Image", "Titre" },
                values: new object[,]
                {
                    { 1, "super bon jeux", "https://www.google.com/url?sa=i&url=https%3A%2F%2Ffr.tripadvisor.ca%2FRestaurants-g181733-c31-Brossard_Quebec.html&psig=AOvVaw3hUHWS986UP-e8wtSJ0uxa&ust=1731761632327000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCIi6pPmw3okDFQAAAAAdAAAAABAE", "Cyberpunk 2077" },
                    { 2, "super bon jeux", "https://www.google.com/url?sa=i&url=https%3A%2F%2Ffr.tripadvisor.ca%2FRestaurants-g181733-c31-Brossard_Quebec.html&psig=AOvVaw3hUHWS986UP-e8wtSJ0uxa&ust=1731761632327000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCIi6pPmw3okDFQAAAAAdAAAAABAE", "The Witcher 3" },
                    { 3, "super bon jeux", "https://www.google.com/url?sa=i&url=https%3A%2F%2Ffr.tripadvisor.ca%2FRestaurants-g181733-c31-Brossard_Quebec.html&psig=AOvVaw3hUHWS986UP-e8wtSJ0uxa&ust=1731761632327000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCIi6pPmw3okDFQAAAAAdAAAAABAE", "GTA V" },
                    { 4, "super bon jeux", "https://www.google.com/url?sa=i&url=https%3A%2F%2Ffr.tripadvisor.ca%2FRestaurants-g181733-c31-Brossard_Quebec.html&psig=AOvVaw3hUHWS986UP-e8wtSJ0uxa&ust=1731761632327000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCIi6pPmw3okDFQAAAAAdAAAAABAE", "Red Dead Redemption 2" }
                });

            migrationBuilder.InsertData(
                table: "Plateformes",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "PC" },
                    { 2, "PS4" },
                    { 3, "Xbox One" },
                    { 4, "Switch" }
                });

            migrationBuilder.InsertData(
                table: "JeuxVideoPlateformes",
                columns: new[] { "JeuxVideoId", "PlateformeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActusVMs_IdentityUserId",
                table: "ActusVMs",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JeuxVideoPlateformes_PlateformeId",
                table: "JeuxVideoPlateformes",
                column: "PlateformeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Listings_ListingId",
                table: "Comments",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Listings_ListingId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "ActusVMs");

            migrationBuilder.DropTable(
                name: "JeuxVideoPlateformes");

            migrationBuilder.DropTable(
                name: "JeuxVideos");

            migrationBuilder.DropTable(
                name: "Plateformes");

            migrationBuilder.AlterColumn<int>(
                name: "ListingId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Listings_ListingId",
                table: "Comments",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id");
        }
    }
}
