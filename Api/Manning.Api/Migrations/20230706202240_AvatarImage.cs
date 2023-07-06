using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Manning.Api.Migrations
{
    /// <inheritdoc />
    public partial class AvatarImage : Migration
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
                    table.ForeignKey(
                        name: "FK_AvatarModels_Operator_OperatorID",
                        column: x => x.OperatorID,
                        principalTable: "Operator",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvatarModels_OperatorID",
                table: "AvatarModels",
                column: "OperatorID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvatarModels");
        }
    }
}
