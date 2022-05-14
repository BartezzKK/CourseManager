using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManager.Data.Migrations
{
    public partial class FixQuestionsFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_QuizEdus_QuizEduId",
                table: "QuizQuestions");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "QuizQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "QuizEduId",
                table: "QuizQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_QuizEdus_QuizEduId",
                table: "QuizQuestions",
                column: "QuizEduId",
                principalTable: "QuizEdus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_QuizEdus_QuizEduId",
                table: "QuizQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "QuizEduId",
                table: "QuizQuestions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "QuizQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_QuizEdus_QuizEduId",
                table: "QuizQuestions",
                column: "QuizEduId",
                principalTable: "QuizEdus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
