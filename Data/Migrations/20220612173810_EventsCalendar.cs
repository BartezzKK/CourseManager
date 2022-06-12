using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManager.Data.Migrations
{
    public partial class EventsCalendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Event");
        }
    }
}
