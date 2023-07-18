using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manning.Api.Migrations
{
    /// <inheritdoc />
    public partial class FixFKDependency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkdayHistory_StationStateModel_StationStateID",
                table: "WorkdayHistory");

            migrationBuilder.DropIndex(
                name: "IX_WorkdayHistory_StationStateID",
                table: "WorkdayHistory");

            migrationBuilder.DropColumn(
                name: "StationStateID",
                table: "WorkdayHistory");

            migrationBuilder.AddColumn<bool>(
                name: "IsTrainee",
                table: "WorkdayHistory",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OperatorID",
                table: "WorkdayHistory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StationID",
                table: "WorkdayHistory",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTrainee",
                table: "WorkdayHistory");

            migrationBuilder.DropColumn(
                name: "OperatorID",
                table: "WorkdayHistory");

            migrationBuilder.DropColumn(
                name: "StationID",
                table: "WorkdayHistory");

            migrationBuilder.AddColumn<int>(
                name: "StationStateID",
                table: "WorkdayHistory",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkdayHistory_StationStateID",
                table: "WorkdayHistory",
                column: "StationStateID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkdayHistory_StationStateModel_StationStateID",
                table: "WorkdayHistory",
                column: "StationStateID",
                principalTable: "StationStateModel",
                principalColumn: "ID");
        }
    }
}
