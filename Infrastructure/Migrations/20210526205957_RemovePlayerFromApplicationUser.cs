using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RemovePlayerFromApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Player_PlayerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PlayerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "TournamentsSelectedFor",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TournamentsSelectedFor",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "TournamentsSelectedFor",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "TournamentsSelectedFor",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Tournaments",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tournaments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Tournaments",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Tournaments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "TournamentPositions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TournamentPositions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "TournamentPositions",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "TournamentPositions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "TeamsTournaments",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TeamsTournaments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "TeamsTournaments",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "TeamsTournaments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "TeamsScores",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TeamsScores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "TeamsScores",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "TeamsScores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Teams",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Teams",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Teams",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Teams",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Prizes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Prizes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Prizes",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Prizes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Player",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Player",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Player",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Player",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Matches",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Matches",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Matches",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Matches",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "TournamentsSelectedFor");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TournamentsSelectedFor");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "TournamentsSelectedFor");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "TournamentsSelectedFor");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "TournamentPositions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TournamentPositions");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "TournamentPositions");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "TournamentPositions");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "TeamsTournaments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TeamsTournaments");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "TeamsTournaments");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "TeamsTournaments");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "TeamsScores");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TeamsScores");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "TeamsScores");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "TeamsScores");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlayerId",
                table: "AspNetUsers",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Player_PlayerId",
                table: "AspNetUsers",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
