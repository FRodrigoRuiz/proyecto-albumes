using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Albumes.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyCoverOnAlbumModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Poster",
                table: "Album",
                newName: "Cover");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cover",
                table: "Album",
                newName: "Poster");
        }
    }
}
