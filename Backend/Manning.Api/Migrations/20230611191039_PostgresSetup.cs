using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Manning.Api.Migrations
{
    /// <inheritdoc />
    public partial class PostgresSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClockModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClockCardNumber = table.Column<int>(type: "integer", nullable: false),
                    OperatorName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ClockInTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ClockOutTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClockModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Operator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClockCardNumber = table.Column<int>(type: "integer", nullable: false),
                    OperatorName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsAdministrator = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OperatorCompletedTraining",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainerClockCardNumber = table.Column<int>(type: "integer", nullable: false),
                    OperatorID = table.Column<int>(type: "integer", nullable: false),
                    TrainingRequirementID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorCompletedTraining", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShiftType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShiftName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TrainingRequirementsType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainingType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingRequirementsType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ZoneName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OpStation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StationName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ZoneID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpStation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OpStation_Zone_ZoneID",
                        column: x => x.ZoneID,
                        principalTable: "Zone",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TrainingRequirement",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequirementDescription = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TrainingRequirementTypeId = table.Column<int>(type: "integer", nullable: false),
                    OpStationID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingRequirement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrainingRequirement_OpStation_OpStationID",
                        column: x => x.OpStationID,
                        principalTable: "OpStation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingRequirement_TrainingRequirementsType_TrainingRequir~",
                        column: x => x.TrainingRequirementTypeId,
                        principalTable: "TrainingRequirementsType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkdayHistory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShiftDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OperatorID = table.Column<int>(type: "integer", nullable: false),
                    OpStationID = table.Column<int>(type: "integer", nullable: false),
                    ShiftID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkdayHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkdayHistory_OpStation_OpStationID",
                        column: x => x.OpStationID,
                        principalTable: "OpStation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkdayHistory_Operator_OperatorID",
                        column: x => x.OperatorID,
                        principalTable: "Operator",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkdayHistory_ShiftType_ShiftID",
                        column: x => x.ShiftID,
                        principalTable: "ShiftType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpStation_ZoneID",
                table: "OpStation",
                column: "ZoneID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRequirement_OpStationID",
                table: "TrainingRequirement",
                column: "OpStationID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRequirement_TrainingRequirementTypeId",
                table: "TrainingRequirement",
                column: "TrainingRequirementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkdayHistory_OperatorID",
                table: "WorkdayHistory",
                column: "OperatorID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkdayHistory_OpStationID",
                table: "WorkdayHistory",
                column: "OpStationID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkdayHistory_ShiftID",
                table: "WorkdayHistory",
                column: "ShiftID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClockModel");

            migrationBuilder.DropTable(
                name: "OperatorCompletedTraining");

            migrationBuilder.DropTable(
                name: "TrainingRequirement");

            migrationBuilder.DropTable(
                name: "WorkdayHistory");

            migrationBuilder.DropTable(
                name: "TrainingRequirementsType");

            migrationBuilder.DropTable(
                name: "OpStation");

            migrationBuilder.DropTable(
                name: "Operator");

            migrationBuilder.DropTable(
                name: "ShiftType");

            migrationBuilder.DropTable(
                name: "Zone");
        }
    }
}
