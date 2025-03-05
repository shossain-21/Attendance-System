using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AttendanceSystem.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTeacherAttendanceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseScheduleId = table.Column<int>(type: "int", nullable: false),
                    Class1 = table.Column<bool>(type: "bit", nullable: false),
                    Class2 = table.Column<bool>(type: "bit", nullable: false),
                    Class3 = table.Column<bool>(type: "bit", nullable: false),
                    Class4 = table.Column<bool>(type: "bit", nullable: false),
                    Class5 = table.Column<bool>(type: "bit", nullable: false),
                    Class6 = table.Column<bool>(type: "bit", nullable: false),
                    Class7 = table.Column<bool>(type: "bit", nullable: false),
                    Class8 = table.Column<bool>(type: "bit", nullable: false),
                    Class9 = table.Column<bool>(type: "bit", nullable: false),
                    Class10 = table.Column<bool>(type: "bit", nullable: false),
                    Class11 = table.Column<bool>(type: "bit", nullable: false),
                    Class12 = table.Column<bool>(type: "bit", nullable: false),
                    Class13 = table.Column<bool>(type: "bit", nullable: false),
                    Class14 = table.Column<bool>(type: "bit", nullable: false),
                    Class15 = table.Column<bool>(type: "bit", nullable: false),
                    Class16 = table.Column<bool>(type: "bit", nullable: false),
                    Class17 = table.Column<bool>(type: "bit", nullable: false),
                    Class18 = table.Column<bool>(type: "bit", nullable: false),
                    Class19 = table.Column<bool>(type: "bit", nullable: false),
                    Class20 = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherAttendances_CourseSchedules_CourseScheduleId",
                        column: x => x.CourseScheduleId,
                        principalTable: "CourseSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TeacherAttendances_CourseTeachers_CourseTeacherId",
                        column: x => x.CourseTeacherId,
                        principalTable: "CourseTeachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAttendances_CourseScheduleId",
                table: "TeacherAttendances",
                column: "CourseScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAttendances_CourseTeacherId",
                table: "TeacherAttendances",
                column: "CourseTeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherAttendances");
        }
    }
}
