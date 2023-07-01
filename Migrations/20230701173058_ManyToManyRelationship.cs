using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Albumes.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlbumSong",
                columns: table => new
                {
                    AlbumsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SongsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumSong", x => new { x.AlbumsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_AlbumSong_Album_AlbumsId",
                        column: x => x.AlbumsId,
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumSong_Song_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Song",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumSong_SongsId",
                table: "AlbumSong",
                column: "SongsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumSong");

            migrationBuilder.DropTable(
                name: "Song");
        }
    }
}
