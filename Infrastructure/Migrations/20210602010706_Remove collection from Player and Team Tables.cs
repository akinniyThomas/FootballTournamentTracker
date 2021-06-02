using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RemovecollectionfromPlayerandTeamTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TournamentsSelectedFor_Players_PlayerId",
                table: "TournamentsSelectedFor");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "TournamentsSelectedFor",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentsSelectedFor_Players_PlayerId",
                table: "TournamentsSelectedFor",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TournamentsSelectedFor_Players_PlayerId",
                table: "TournamentsSelectedFor");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "TournamentsSelectedFor",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentsSelectedFor_Players_PlayerId",
                table: "TournamentsSelectedFor",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
