using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Manning.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvatarModels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FileContent = table.Column<byte[]>(type: "bytea", nullable: true),
                    ContentType = table.Column<string>(type: "text", nullable: true),
                    OperatorID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvatarModels", x => x.ID);
                });

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
                name: "StationStateModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StationID = table.Column<int>(type: "integer", nullable: false),
                    OperatorID = table.Column<int>(type: "integer", nullable: false),
                    IsTrainee = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationStateModel", x => x.ID);
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
                name: "WorkdayHistory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShiftDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ShiftName = table.Column<string>(type: "text", nullable: false),
                    StationStateID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkdayHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkdayHistory_StationStateModel_StationStateID",
                        column: x => x.StationStateID,
                        principalTable: "StationStateModel",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StationName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ZoneID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Station_Zone_ZoneID",
                        column: x => x.ZoneID,
                        principalTable: "Zone",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AssignedOperatorsModels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OperatorID = table.Column<int>(type: "integer", nullable: true),
                    StationID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedOperatorsModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssignedOperatorsModels_Operator_OperatorID",
                        column: x => x.OperatorID,
                        principalTable: "Operator",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AssignedOperatorsModels_Station_StationID",
                        column: x => x.StationID,
                        principalTable: "Station",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TrainingRequirement",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequirementDescription = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    StationID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingRequirement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrainingRequirement_Station_StationID",
                        column: x => x.StationID,
                        principalTable: "Station",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedOperatorsModels_OperatorID",
                table: "AssignedOperatorsModels",
                column: "OperatorID");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedOperatorsModels_StationID",
                table: "AssignedOperatorsModels",
                column: "StationID");

            migrationBuilder.CreateIndex(
                name: "IX_Station_ZoneID",
                table: "Station",
                column: "ZoneID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRequirement_StationID",
                table: "TrainingRequirement",
                column: "StationID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkdayHistory_StationStateID",
                table: "WorkdayHistory",
                column: "StationStateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedOperatorsModels");

            migrationBuilder.DropTable(
                name: "AvatarModels");

            migrationBuilder.DropTable(
                name: "ClockModel");

            migrationBuilder.DropTable(
                name: "OperatorCompletedTraining");

            migrationBuilder.DropTable(
                name: "TrainingRequirement");

            migrationBuilder.DropTable(
                name: "WorkdayHistory");

            migrationBuilder.DropTable(
                name: "Operator");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "StationStateModel");

            migrationBuilder.DropTable(
                name: "Zone");
        }
    }
}
