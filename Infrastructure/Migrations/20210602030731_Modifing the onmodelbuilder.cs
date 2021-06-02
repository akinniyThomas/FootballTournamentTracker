using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Modifingtheonmodelbuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Players",
                newName: "PlayerTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                newName: "IX_Players_PlayerTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_PlayerTeamId",
                table: "Players",
                column: "PlayerTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_PlayerTeamId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "PlayerTeamId",
                table: "Players",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_PlayerTeamId",
                table: "Players",
                newName: "IX_Players_TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
