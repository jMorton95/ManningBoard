using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manning.Api.Migrations
{
    /// <inheritdoc />
    public partial class TraineeOperator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvatarModels_Operator_OperatorID",
                table: "AvatarModels");

            migrationBuilder.DropIndex(
                name: "IX_AvatarModels_OperatorID",
                table: "AvatarModels");

            migrationBuilder.AddColumn<bool>(
                name: "IsTrainee",
                table: "StationStateModel",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTrainee",
                table: "StationStateModel");

            migrationBuilder.CreateIndex(
                name: "IX_AvatarModels_OperatorID",
                table: "AvatarModels",
                column: "OperatorID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AvatarModels_Operator_OperatorID",
                table: "AvatarModels",
                column: "OperatorID",
                principalTable: "Operator",
                principalColumn: "ID");
        }
    }
}
