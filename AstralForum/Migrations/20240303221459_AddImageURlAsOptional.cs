using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstralForum.Migrations
{
    /// <inheritdoc />
    public partial class AddImageURlAsOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostsTags");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ThreadCategories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ThreadCategories");

            migrationBuilder.CreateTable(
                name: "PostsTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostsTags_Threads_PostId",
                        column: x => x.PostId,
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostsTags_PostId",
                table: "PostsTags",
                column: "PostId");
        }
    }
}
