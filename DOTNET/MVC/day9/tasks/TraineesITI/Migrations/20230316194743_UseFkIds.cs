using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineesITI.Migrations
{
    /// <inheritdoc />
    public partial class UseFkIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TraineeCourses_TrackCourses_TrackCourseId",
                table: "TraineeCourses");

            migrationBuilder.RenameColumn(
                name: "TrackCourseId",
                table: "TraineeCourses",
                newName: "TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_TraineeCourses_TrackCourseId",
                table: "TraineeCourses",
                newName: "IX_TraineeCourses_TraineeId");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "TraineeCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TraineeCourses_CourseId",
                table: "TraineeCourses",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeCourses_Courses_CourseId",
                table: "TraineeCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeCourses_Trainees_TraineeId",
                table: "TraineeCourses",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TraineeCourses_Courses_CourseId",
                table: "TraineeCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TraineeCourses_Trainees_TraineeId",
                table: "TraineeCourses");

            migrationBuilder.DropIndex(
                name: "IX_TraineeCourses_CourseId",
                table: "TraineeCourses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "TraineeCourses");

            migrationBuilder.RenameColumn(
                name: "TraineeId",
                table: "TraineeCourses",
                newName: "TrackCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_TraineeCourses_TraineeId",
                table: "TraineeCourses",
                newName: "IX_TraineeCourses_TrackCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeCourses_TrackCourses_TrackCourseId",
                table: "TraineeCourses",
                column: "TrackCourseId",
                principalTable: "TrackCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
