using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstralForum.Migrations
{
    /// <inheritdoc />
    public partial class LitsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Reactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_PostId",
                table: "Reactions",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Threads_PostId",
                table: "Reactions",
                column: "PostId",
                principalTable: "Threads",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Threads_PostId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_PostId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Reactions");
        }
    }
}
