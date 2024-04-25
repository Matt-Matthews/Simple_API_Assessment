using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple_API_Assessment.Migrations
{
    public partial class ModelFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Applicants_ApplicantId",
                table: "Skills");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantId",
                table: "Skills",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Applicants_ApplicantId",
                table: "Skills",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Applicants_ApplicantId",
                table: "Skills");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantId",
                table: "Skills",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Applicants_ApplicantId",
                table: "Skills",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
