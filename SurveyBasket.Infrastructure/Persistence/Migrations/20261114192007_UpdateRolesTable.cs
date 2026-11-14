using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyBasket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRolesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteAnswers_Polls_PollId",
                table: "VoteAnswers");

            migrationBuilder.DropIndex(
                name: "IX_VoteAnswers_PollId",
                table: "VoteAnswers");

            migrationBuilder.DropColumn(
                name: "PollId",
                table: "VoteAnswers");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<int>(
                name: "PollId",
                table: "VoteAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoteAnswers_PollId",
                table: "VoteAnswers",
                column: "PollId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteAnswers_Polls_PollId",
                table: "VoteAnswers",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id");
        }
    }
}
