using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace penca.lb.data.Migrations
{
    public partial class addcompetitionteam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchResults_Matches_MatchId",
                table: "MatchResults");

            migrationBuilder.DropIndex(
                name: "IX_MatchResults_MatchId",
                table: "MatchResults");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "MatchResults");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Stages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AwayScore",
                table: "MatchResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeScore",
                table: "MatchResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "WinnerId",
                table: "MatchResults",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ResultId",
                table: "Matches",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompetitionTeam",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionId = table.Column<long>(type: "bigint", nullable: true),
                    TeamId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionTeam_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompetitionTeam_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_WinnerId",
                table: "MatchResults",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ResultId",
                table: "Matches",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionTeam_CompetitionId",
                table: "CompetitionTeam",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionTeam_TeamId",
                table: "CompetitionTeam",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchResults_ResultId",
                table: "Matches",
                column: "ResultId",
                principalTable: "MatchResults",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchResults_Teams_WinnerId",
                table: "MatchResults",
                column: "WinnerId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchResults_ResultId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchResults_Teams_WinnerId",
                table: "MatchResults");

            migrationBuilder.DropTable(
                name: "CompetitionTeam");

            migrationBuilder.DropIndex(
                name: "IX_MatchResults_WinnerId",
                table: "MatchResults");

            migrationBuilder.DropIndex(
                name: "IX_Matches_ResultId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "AwayScore",
                table: "MatchResults");

            migrationBuilder.DropColumn(
                name: "HomeScore",
                table: "MatchResults");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "MatchResults");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Matches");

            migrationBuilder.AddColumn<long>(
                name: "MatchId",
                table: "MatchResults",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_MatchId",
                table: "MatchResults",
                column: "MatchId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchResults_Matches_MatchId",
                table: "MatchResults",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
