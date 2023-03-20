using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineesITI.Migrations
{
    /// <inheritdoc />
    public partial class TrackPerTrainee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackTrainees");

            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_TrackId",
                table: "Trainees",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Tracks_TrackId",
                table: "Trainees",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Tracks_TrackId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_TrackId",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "Trainees");

            migrationBuilder.CreateTable(
                name: "TrackTrainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackTrainees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackTrainees_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackTrainees_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackTrainees_TrackId",
                table: "TrackTrainees",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackTrainees_TraineeId",
                table: "TrackTrainees",
                column: "TraineeId");
        }
    }
}
