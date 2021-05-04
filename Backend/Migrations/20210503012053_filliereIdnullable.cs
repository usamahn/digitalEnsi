using Microsoft.EntityFrameworkCore.Migrations;

namespace digitalEnsi.Migrations
{
    public partial class filliereIdnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_Filieres_FiliereId",
                table: "Inscriptions");

            migrationBuilder.AlterColumn<int>(
                name: "FiliereId",
                table: "Inscriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptions_Filieres_FiliereId",
                table: "Inscriptions",
                column: "FiliereId",
                principalTable: "Filieres",
                principalColumn: "FiliereId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_Filieres_FiliereId",
                table: "Inscriptions");

            migrationBuilder.AlterColumn<int>(
                name: "FiliereId",
                table: "Inscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptions_Filieres_FiliereId",
                table: "Inscriptions",
                column: "FiliereId",
                principalTable: "Filieres",
                principalColumn: "FiliereId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
