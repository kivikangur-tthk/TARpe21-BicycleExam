using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KivikangurBicycleExam.Data.Migrations
{
    public partial class AddExamineeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamineeName",
                table: "Exam");

            migrationBuilder.AddColumn<int>(
                name: "ExamineeId",
                table: "Exam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Examinee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinee", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exam_ExamineeId",
                table: "Exam",
                column: "ExamineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Examinee_ExamineeId",
                table: "Exam",
                column: "ExamineeId",
                principalTable: "Examinee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Examinee_ExamineeId",
                table: "Exam");

            migrationBuilder.DropTable(
                name: "Examinee");

            migrationBuilder.DropIndex(
                name: "IX_Exam_ExamineeId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "ExamineeId",
                table: "Exam");

            migrationBuilder.AddColumn<string>(
                name: "ExamineeName",
                table: "Exam",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
