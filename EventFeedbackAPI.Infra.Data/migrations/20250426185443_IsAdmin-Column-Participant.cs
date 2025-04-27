using Microsoft.EntityFrameworkCore.Migrations;

namespace EventFeedbackAPI.Infra.Data.Migrations
{
    public partial class IsAdminColumnParticipant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Participant",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Participant");
        }
    }
}
