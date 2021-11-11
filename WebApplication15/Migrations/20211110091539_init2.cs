using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication15.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_Teacherid",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Teacherid",
                table: "Courses",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_Teacherid",
                table: "Courses",
                newName: "IX_Courses_TeacherId");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Courses",
                newName: "Teacherid");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                newName: "IX_Courses_Teacherid");

            migrationBuilder.AlterColumn<int>(
                name: "Teacherid",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_Teacherid",
                table: "Courses",
                column: "Teacherid",
                principalTable: "Teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
