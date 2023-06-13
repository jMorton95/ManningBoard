// using System;
// using Microsoft.EntityFrameworkCore.Migrations;

// #nullable disable

// namespace ManningApi.Migrations
// {
//     /// <inheritdoc />
//     public partial class InitialMigration : Migration
//     {
//         /// <inheritdoc />
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.CreateTable(
//                 name: "Operator",
//                 columns: table => new
//                 {
//                     ID = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("SqlServer:Identity", "1, 1"),
//                     ClockCardNumber = table.Column<int>(type: "int", nullable: false),
//                     OperatorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Operator", x => x.ID);
//                 });

//             migrationBuilder.CreateTable(
//                 name: "ShiftType",
//                 columns: table => new
//                 {
//                     ID = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("SqlServer:Identity", "1, 1"),
//                     ShiftName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_ShiftType", x => x.ID);
//                 });

//             migrationBuilder.CreateTable(
//                 name: "TrainingRequirementsType",
//                 columns: table => new
//                 {
//                     ID = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("SqlServer:Identity", "1, 1"),
//                     TrainingType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_TrainingRequirementsType", x => x.ID);
//                 });

//             migrationBuilder.CreateTable(
//                 name: "Zone",
//                 columns: table => new
//                 {
//                     ID = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("SqlServer:Identity", "1, 1"),
//                     ZoneName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Zone", x => x.ID);
//                 });

//             migrationBuilder.CreateTable(
//                 name: "OpStation",
//                 columns: table => new
//                 {
//                     ID = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("SqlServer:Identity", "1, 1"),
//                     StationName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
//                     ZoneID = table.Column<int>(type: "int", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_OpStation", x => x.ID);
//                     table.ForeignKey(
//                         name: "FK_OpStation_Zone_ZoneID",
//                         column: x => x.ZoneID,
//                         principalTable: "Zone",
//                         principalColumn: "ID");
//                 });

//             migrationBuilder.CreateTable(
//                 name: "TrainingRequirement",
//                 columns: table => new
//                 {
//                     ID = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("SqlServer:Identity", "1, 1"),
//                     RequirementDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
//                     TypeID = table.Column<int>(type: "int", nullable: true),
//                     OpStationID = table.Column<int>(type: "int", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_TrainingRequirement", x => x.ID);
//                     table.ForeignKey(
//                         name: "FK_TrainingRequirement_OpStation_OpStationID",
//                         column: x => x.OpStationID,
//                         principalTable: "OpStation",
//                         principalColumn: "ID",
//                         onDelete: ReferentialAction.Cascade);
//                     table.ForeignKey(
//                         name: "FK_TrainingRequirement_TrainingRequirementsType_TypeID",
//                         column: x => x.TypeID,
//                         principalTable: "TrainingRequirementsType",
//                         principalColumn: "ID");
//                 });

//             migrationBuilder.CreateTable(
//                 name: "WorkdayHistory",
//                 columns: table => new
//                 {
//                     ID = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("SqlServer:Identity", "1, 1"),
//                     ShiftDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
//                     OperatorID = table.Column<int>(type: "int", nullable: true),
//                     OpStationID = table.Column<int>(type: "int", nullable: true),
//                     ShiftID = table.Column<int>(type: "int", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_WorkdayHistory", x => x.ID);
//                     table.ForeignKey(
//                         name: "FK_WorkdayHistory_OpStation_OpStationID",
//                         column: x => x.OpStationID,
//                         principalTable: "OpStation",
//                         principalColumn: "ID");
//                     table.ForeignKey(
//                         name: "FK_WorkdayHistory_Operator_OperatorID",
//                         column: x => x.OperatorID,
//                         principalTable: "Operator",
//                         principalColumn: "ID");
//                     table.ForeignKey(
//                         name: "FK_WorkdayHistory_ShiftType_ShiftID",
//                         column: x => x.ShiftID,
//                         principalTable: "ShiftType",
//                         principalColumn: "ID");
//                 });

//             migrationBuilder.CreateTable(
//                 name: "OperatorCompletedTraining",
//                 columns: table => new
//                 {
//                     ID = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("SqlServer:Identity", "1, 1"),
//                     TrainerClockCardNumber = table.Column<int>(type: "int", nullable: false),
//                     OperatorID = table.Column<int>(type: "int", nullable: true),
//                     TrainingRequirementID = table.Column<int>(type: "int", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_OperatorCompletedTraining", x => x.ID);
//                     table.ForeignKey(
//                         name: "FK_OperatorCompletedTraining_Operator_OperatorID",
//                         column: x => x.OperatorID,
//                         principalTable: "Operator",
//                         principalColumn: "ID");
//                     table.ForeignKey(
//                         name: "FK_OperatorCompletedTraining_TrainingRequirement_TrainingRequirementID",
//                         column: x => x.TrainingRequirementID,
//                         principalTable: "TrainingRequirement",
//                         principalColumn: "ID");
//                 });

//             migrationBuilder.CreateIndex(
//                 name: "IX_OperatorCompletedTraining_OperatorID",
//                 table: "OperatorCompletedTraining",
//                 column: "OperatorID");

//             migrationBuilder.CreateIndex(
//                 name: "IX_OperatorCompletedTraining_TrainingRequirementID",
//                 table: "OperatorCompletedTraining",
//                 column: "TrainingRequirementID");

//             migrationBuilder.CreateIndex(
//                 name: "IX_OpStation_ZoneID",
//                 table: "OpStation",
//                 column: "ZoneID");

//             migrationBuilder.CreateIndex(
//                 name: "IX_TrainingRequirement_OpStationID",
//                 table: "TrainingRequirement",
//                 column: "OpStationID");

//             migrationBuilder.CreateIndex(
//                 name: "IX_TrainingRequirement_TypeID",
//                 table: "TrainingRequirement",
//                 column: "TypeID");

//             migrationBuilder.CreateIndex(
//                 name: "IX_WorkdayHistory_OperatorID",
//                 table: "WorkdayHistory",
//                 column: "OperatorID");

//             migrationBuilder.CreateIndex(
//                 name: "IX_WorkdayHistory_OpStationID",
//                 table: "WorkdayHistory",
//                 column: "OpStationID");

//             migrationBuilder.CreateIndex(
//                 name: "IX_WorkdayHistory_ShiftID",
//                 table: "WorkdayHistory",
//                 column: "ShiftID");
//         }

//         /// <inheritdoc />
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropTable(
//                 name: "OperatorCompletedTraining");

//             migrationBuilder.DropTable(
//                 name: "WorkdayHistory");

//             migrationBuilder.DropTable(
//                 name: "TrainingRequirement");

//             migrationBuilder.DropTable(
//                 name: "Operator");

//             migrationBuilder.DropTable(
//                 name: "ShiftType");

//             migrationBuilder.DropTable(
//                 name: "OpStation");

//             migrationBuilder.DropTable(
//                 name: "TrainingRequirementsType");

//             migrationBuilder.DropTable(
//                 name: "Zone");
//         }
//     }
// }
