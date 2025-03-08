using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogBackASPNETCore.Migrations
{
    public partial class v04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Posts",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "slug",
                table: "Posts",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Posts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "extract",
                table: "Posts",
                newName: "Extract");

            migrationBuilder.RenameColumn(
                name: "body",
                table: "Posts",
                newName: "Body");

            migrationBuilder.RenameColumn(
                name: "slug",
                table: "Categories",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Posts",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Posts",
                newName: "slug");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Posts",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Extract",
                table: "Posts",
                newName: "extract");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Posts",
                newName: "body");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Categories",
                newName: "slug");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "name");
        }
    }
}
