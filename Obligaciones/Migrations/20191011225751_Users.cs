using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligaciones.Migrations
{
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contributors_WorkLoadRegistries_WorkLoadRegistryId",
                table: "Contributors");

            migrationBuilder.DropIndex(
                name: "IX_Contributors_WorkLoadRegistryId",
                table: "Contributors");

            migrationBuilder.DropColumn(
                name: "WorkLoadRegistryId",
                table: "Contributors");

            migrationBuilder.AddColumn<bool>(
                name: "Complete",
                table: "WorkLoadRegistries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ContributorId",
                table: "WorkLoadRegistries",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complete",
                table: "WorkLoadRegistries");

            migrationBuilder.DropColumn(
                name: "ContributorId",
                table: "WorkLoadRegistries");

            migrationBuilder.AddColumn<long>(
                name: "WorkLoadRegistryId",
                table: "Contributors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contributors_WorkLoadRegistryId",
                table: "Contributors",
                column: "WorkLoadRegistryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contributors_WorkLoadRegistries_WorkLoadRegistryId",
                table: "Contributors",
                column: "WorkLoadRegistryId",
                principalTable: "WorkLoadRegistries",
                principalColumn: "WorkLoadRegistryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
