using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactManningPoCAPI.Migrations
{
    public partial class OperatorAdministrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperatorCompletedTraining_Operator_OperatorID",
                table: "OperatorCompletedTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatorCompletedTraining_TrainingRequirement_TrainingRequirementID",
                table: "OperatorCompletedTraining");

            migrationBuilder.DropIndex(
                name: "IX_OperatorCompletedTraining_OperatorID",
                table: "OperatorCompletedTraining");

            migrationBuilder.DropIndex(
                name: "IX_OperatorCompletedTraining_TrainingRequirementID",
                table: "OperatorCompletedTraining");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdministrator",
                table: "Operator",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdministrator",
                table: "Operator");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorCompletedTraining_OperatorID",
                table: "OperatorCompletedTraining",
                column: "OperatorID");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorCompletedTraining_TrainingRequirementID",
                table: "OperatorCompletedTraining",
                column: "TrainingRequirementID");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorCompletedTraining_Operator_OperatorID",
                table: "OperatorCompletedTraining",
                column: "OperatorID",
                principalTable: "Operator",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorCompletedTraining_TrainingRequirement_TrainingRequirementID",
                table: "OperatorCompletedTraining",
                column: "TrainingRequirementID",
                principalTable: "TrainingRequirement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
