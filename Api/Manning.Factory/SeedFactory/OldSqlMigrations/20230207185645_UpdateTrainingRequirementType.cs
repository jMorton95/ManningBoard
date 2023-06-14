// using Microsoft.EntityFrameworkCore.Migrations;

// #nullable disable

// namespace ManningApi.Migrations
// {
//     /// <inheritdoc />
//     public partial class UpdateTrainingRequirementType : Migration
//     {
//         /// <inheritdoc />
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_OperatorCompletedTraining_Operator_OperatorID",
//                 table: "OperatorCompletedTraining");

//             migrationBuilder.DropForeignKey(
//                 name: "FK_OperatorCompletedTraining_TrainingRequirement_TrainingRequirementID",
//                 table: "OperatorCompletedTraining");

//             migrationBuilder.DropForeignKey(
//                 name: "FK_TrainingRequirement_TrainingRequirementsType_TypeID",
//                 table: "TrainingRequirement");

//             migrationBuilder.DropForeignKey(
//                 name: "FK_WorkdayHistory_Station_StationID",
//                 table: "WorkdayHistory");

//             migrationBuilder.DropForeignKey(
//                 name: "FK_WorkdayHistory_Operator_OperatorID",
//                 table: "WorkdayHistory");

//             migrationBuilder.DropForeignKey(
//                 name: "FK_WorkdayHistory_ShiftType_ShiftID",
//                 table: "WorkdayHistory");

//             migrationBuilder.DropIndex(
//                 name: "IX_TrainingRequirement_TypeID",
//                 table: "TrainingRequirement");

//             migrationBuilder.DropColumn(
//                 name: "TypeID",
//                 table: "TrainingRequirement");

//             migrationBuilder.AlterColumn<int>(
//                 name: "ShiftID",
//                 table: "WorkdayHistory",
//                 type: "int",
//                 nullable: false,
//                 defaultValue: 0,
//                 oldClrType: typeof(int),
//                 oldType: "int",
//                 oldNullable: true);

//             migrationBuilder.AlterColumn<int>(
//                 name: "OperatorID",
//                 table: "WorkdayHistory",
//                 type: "int",
//                 nullable: false,
//                 defaultValue: 0,
//                 oldClrType: typeof(int),
//                 oldType: "int",
//                 oldNullable: true);

//             migrationBuilder.AlterColumn<int>(
//                 name: "StationID",
//                 table: "WorkdayHistory",
//                 type: "int",
//                 nullable: false,
//                 defaultValue: 0,
//                 oldClrType: typeof(int),
//                 oldType: "int",
//                 oldNullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "TrainingRequirementTypeId",
//                 table: "TrainingRequirement",
//                 type: "int",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AlterColumn<int>(
//                 name: "TrainingRequirementID",
//                 table: "OperatorCompletedTraining",
//                 type: "int",
//                 nullable: false,
//                 defaultValue: 0,
//                 oldClrType: typeof(int),
//                 oldType: "int",
//                 oldNullable: true);

//             migrationBuilder.AlterColumn<int>(
//                 name: "OperatorID",
//                 table: "OperatorCompletedTraining",
//                 type: "int",
//                 nullable: false,
//                 defaultValue: 0,
//                 oldClrType: typeof(int),
//                 oldType: "int",
//                 oldNullable: true);

//             migrationBuilder.CreateIndex(
//                 name: "IX_TrainingRequirement_TrainingRequirementTypeId",
//                 table: "TrainingRequirement",
//                 column: "TrainingRequirementTypeId");

//             migrationBuilder.AddForeignKey(
//                 name: "FK_OperatorCompletedTraining_Operator_OperatorID",
//                 table: "OperatorCompletedTraining",
//                 column: "OperatorID",
//                 principalTable: "Operator",
//                 principalColumn: "ID",
//                 onDelete: ReferentialAction.Cascade);

//             migrationBuilder.AddForeignKey(
//                 name: "FK_OperatorCompletedTraining_TrainingRequirement_TrainingRequirementID",
//                 table: "OperatorCompletedTraining",
//                 column: "TrainingRequirementID",
//                 principalTable: "TrainingRequirement",
//                 principalColumn: "ID",
//                 onDelete: ReferentialAction.Cascade);

//             migrationBuilder.AddForeignKey(
//                 name: "FK_TrainingRequirement_TrainingRequirementsType_TrainingRequirementTypeId",
//                 table: "TrainingRequirement",
//                 column: "TrainingRequirementTypeId",
//                 principalTable: "TrainingRequirementsType",
//                 principalColumn: "ID",
//                 onDelete: ReferentialAction.Cascade);

//             migrationBuilder.AddForeignKey(
//                 name: "FK_WorkdayHistory_Station_StationID",
//                 table: "WorkdayHistory",
//                 column: "StationID",
//                 principalTable: "Station",
//                 principalColumn: "ID",
//                 onDelete: ReferentialAction.Cascade);

//             migrationBuilder.AddForeignKey(
//                 name: "FK_WorkdayHistory_Operator_OperatorID",
//                 table: "WorkdayHistory",
//                 column: "OperatorID",
//                 principalTable: "Operator",
//                 principalColumn: "ID",
//                 onDelete: ReferentialAction.Cascade);

//             migrationBuilder.AddForeignKey(
//                 name: "FK_WorkdayHistory_ShiftType_ShiftID",
//                 table: "WorkdayHistory",
//                 column: "ShiftID",
//                 principalTable: "ShiftType",
//                 principalColumn: "ID",
//                 onDelete: ReferentialAction.Cascade);
//         }

//         /// <inheritdoc />
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_OperatorCompletedTraining_Operator_OperatorID",
//                 table: "OperatorCompletedTraining");

//             migrationBuilder.DropForeignKey(
//                 name: "FK_OperatorCompletedTraining_TrainingRequirement_TrainingRequirementID",
//                 table: "OperatorCompletedTraining");

//             migrationBuilder.DropForeignKey(
//                 name: "FK_TrainingRequirement_TrainingRequirementsType_TrainingRequirementTypeId",
//                 table: "TrainingRequirement");

//             migrationBuilder.DropForeignKey(
//                 name: "FK_WorkdayHistory_Station_StationID",
//                 table: "WorkdayHistory");

//             migrationBuilder.DropForeignKey(
//                 name: "FK_WorkdayHistory_Operator_OperatorID",
//                 table: "WorkdayHistory");

//             migrationBuilder.DropForeignKey(
//                 name: "FK_WorkdayHistory_ShiftType_ShiftID",
//                 table: "WorkdayHistory");

//             migrationBuilder.DropIndex(
//                 name: "IX_TrainingRequirement_TrainingRequirementTypeId",
//                 table: "TrainingRequirement");

//             migrationBuilder.DropColumn(
//                 name: "TrainingRequirementTypeId",
//                 table: "TrainingRequirement");

//             migrationBuilder.AlterColumn<int>(
//                 name: "ShiftID",
//                 table: "WorkdayHistory",
//                 type: "int",
//                 nullable: true,
//                 oldClrType: typeof(int),
//                 oldType: "int");

//             migrationBuilder.AlterColumn<int>(
//                 name: "OperatorID",
//                 table: "WorkdayHistory",
//                 type: "int",
//                 nullable: true,
//                 oldClrType: typeof(int),
//                 oldType: "int");

//             migrationBuilder.AlterColumn<int>(
//                 name: "StationID",
//                 table: "WorkdayHistory",
//                 type: "int",
//                 nullable: true,
//                 oldClrType: typeof(int),
//                 oldType: "int");

//             migrationBuilder.AddColumn<int>(
//                 name: "TypeID",
//                 table: "TrainingRequirement",
//                 type: "int",
//                 nullable: true);

//             migrationBuilder.AlterColumn<int>(
//                 name: "TrainingRequirementID",
//                 table: "OperatorCompletedTraining",
//                 type: "int",
//                 nullable: true,
//                 oldClrType: typeof(int),
//                 oldType: "int");

//             migrationBuilder.AlterColumn<int>(
//                 name: "OperatorID",
//                 table: "OperatorCompletedTraining",
//                 type: "int",
//                 nullable: true,
//                 oldClrType: typeof(int),
//                 oldType: "int");

//             migrationBuilder.CreateIndex(
//                 name: "IX_TrainingRequirement_TypeID",
//                 table: "TrainingRequirement",
//                 column: "TypeID");

//             migrationBuilder.AddForeignKey(
//                 name: "FK_OperatorCompletedTraining_Operator_OperatorID",
//                 table: "OperatorCompletedTraining",
//                 column: "OperatorID",
//                 principalTable: "Operator",
//                 principalColumn: "ID");

//             migrationBuilder.AddForeignKey(
//                 name: "FK_OperatorCompletedTraining_TrainingRequirement_TrainingRequirementID",
//                 table: "OperatorCompletedTraining",
//                 column: "TrainingRequirementID",
//                 principalTable: "TrainingRequirement",
//                 principalColumn: "ID");

//             migrationBuilder.AddForeignKey(
//                 name: "FK_TrainingRequirement_TrainingRequirementsType_TypeID",
//                 table: "TrainingRequirement",
//                 column: "TypeID",
//                 principalTable: "TrainingRequirementsType",
//                 principalColumn: "ID");

//             migrationBuilder.AddForeignKey(
//                 name: "FK_WorkdayHistory_Station_StationID",
//                 table: "WorkdayHistory",
//                 column: "StationID",
//                 principalTable: "Station",
//                 principalColumn: "ID");

//             migrationBuilder.AddForeignKey(
//                 name: "FK_WorkdayHistory_Operator_OperatorID",
//                 table: "WorkdayHistory",
//                 column: "OperatorID",
//                 principalTable: "Operator",
//                 principalColumn: "ID");

//             migrationBuilder.AddForeignKey(
//                 name: "FK_WorkdayHistory_ShiftType_ShiftID",
//                 table: "WorkdayHistory",
//                 column: "ShiftID",
//                 principalTable: "ShiftType",
//                 principalColumn: "ID");
//         }
//     }
// }
