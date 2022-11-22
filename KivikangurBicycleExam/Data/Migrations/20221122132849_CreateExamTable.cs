using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KivikangurBicycleExam.Data.Migrations
{
    public partial class CreateExamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamineeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheoryResult = table.Column<int>(type: "int", nullable: true),
                    ParkingLotResult = table.Column<int>(type: "int", nullable: true),
                    SlalomResult = table.Column<int>(type: "int", nullable: true),
                    CircleResult = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exam");
        }
    }
}
