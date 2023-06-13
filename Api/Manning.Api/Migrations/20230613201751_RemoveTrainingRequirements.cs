using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Manning.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTrainingRequirements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingRequirement_TrainingRequirementsType_TrainingRequir~",
                table: "TrainingRequirement");

            migrationBuilder.DropTable(
                name: "TrainingRequirementsType");

            migrationBuilder.DropIndex(
                name: "IX_TrainingRequirement_TrainingRequirementTypeId",
                table: "TrainingRequirement");

            migrationBuilder.DropColumn(
                name: "TrainingRequirementTypeId",
                table: "TrainingRequirement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingRequirementTypeId",
                table: "TrainingRequirement",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRequirement_TrainingRequirementTypeId",
                table: "TrainingRequirement",
                column: "TrainingRequirementTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingRequirement_TrainingRequirementsType_TrainingRequir~",
                table: "TrainingRequirement",
                column: "TrainingRequirementTypeId",
                principalTable: "TrainingRequirementsType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
