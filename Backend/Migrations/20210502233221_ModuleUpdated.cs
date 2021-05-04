using Microsoft.EntityFrameworkCore.Migrations;

namespace digitalEnsi.Migrations
{
    public partial class ModuleUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Niveau",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Niveau",
                table: "Modules");
        }
    }
}
