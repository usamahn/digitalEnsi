using Microsoft.EntityFrameworkCore.Migrations;

namespace digitalEnsi.Migrations
{
    public partial class SeanceUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Année_Universitaire",
                table: "Seances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Semestre",
                table: "Seances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "NoteExamenR",
                table: "Notes",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Année_Universitaire",
                table: "Seances");

            migrationBuilder.DropColumn(
                name: "Semestre",
                table: "Seances");

            migrationBuilder.AlterColumn<float>(
                name: "NoteExamenR",
                table: "Notes",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }
    }
}
