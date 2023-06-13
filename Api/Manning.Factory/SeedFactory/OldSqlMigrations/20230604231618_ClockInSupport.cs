// using System;
// using Microsoft.EntityFrameworkCore.Migrations;

// #nullable disable

// namespace ManningApi.Migrations
// {
//     public partial class ClockInSupport : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.CreateTable(
//                 name: "ClockModel",
//                 columns: table => new
//                 {
//                     ID = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("SqlServer:Identity", "1, 1"),
//                     ClockCardNumber = table.Column<int>(type: "int", nullable: false),
//                     OperatorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
//                     ClockInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
//                     ClockOutTime = table.Column<DateTime>(type: "datetime2", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_ClockModel", x => x.ID);
//                 });
//         }

//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropTable(
//                 name: "ClockModel");
//         }
//     }
// }
