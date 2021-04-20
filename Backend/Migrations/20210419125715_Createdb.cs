using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace digitalEnsi.Migrations
{
    public partial class Createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiliereId",
                table: "Inscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cin",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateNaissance",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Administrateurs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrateurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrateurs_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filieres",
                columns: table => new
                {
                    FiliereId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libelleFiliere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacité = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filieres", x => x.FiliereId);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibelleModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    VolumeHoraire = table.Column<float>(type: "real", nullable: false),
                    Semestre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibelleService = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "FiliereModule",
                columns: table => new
                {
                    FilieresFiliereId = table.Column<int>(type: "int", nullable: false),
                    ModulesModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiliereModule", x => new { x.FilieresFiliereId, x.ModulesModuleId });
                    table.ForeignKey(
                        name: "FK_FiliereModule_Filieres_FilieresFiliereId",
                        column: x => x.FilieresFiliereId,
                        principalTable: "Filieres",
                        principalColumn: "FiliereId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FiliereModule_Modules_ModulesModuleId",
                        column: x => x.ModulesModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteDs = table.Column<float>(type: "real", nullable: false),
                    NoteCc = table.Column<float>(type: "real", nullable: false),
                    NoteExamenP = table.Column<float>(type: "real", nullable: false),
                    NoteExamenR = table.Column<float>(type: "real", nullable: false),
                    InscriptionId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Notes_Inscriptions_InscriptionId",
                        column: x => x.InscriptionId,
                        principalTable: "Inscriptions",
                        principalColumn: "InscriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    SeanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jour = table.Column<int>(type: "int", nullable: false),
                    HeureDeb = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeureFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    groupeId = table.Column<int>(type: "int", nullable: false),
                    EnsignantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.SeanceId);
                    table.ForeignKey(
                        name: "FK_Seances_Ensignants_EnsignantId",
                        column: x => x.EnsignantId,
                        principalTable: "Ensignants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seances_Groupe_groupeId",
                        column: x => x.groupeId,
                        principalTable: "Groupe",
                        principalColumn: "groupeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seances_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnsignantService",
                columns: table => new
                {
                    EnsignantsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServicesServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnsignantService", x => new { x.EnsignantsId, x.ServicesServiceId });
                    table.ForeignKey(
                        name: "FK_EnsignantService_Ensignants_EnsignantsId",
                        column: x => x.EnsignantsId,
                        principalTable: "Ensignants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnsignantService_Services_ServicesServiceId",
                        column: x => x.ServicesServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EtudiantService",
                columns: table => new
                {
                    EtudiantsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServicesServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtudiantService", x => new { x.EtudiantsId, x.ServicesServiceId });
                    table.ForeignKey(
                        name: "FK_EtudiantService_Etudiants_EtudiantsId",
                        column: x => x.EtudiantsId,
                        principalTable: "Etudiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtudiantService_Services_ServicesServiceId",
                        column: x => x.ServicesServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    AbsenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InscriptionId = table.Column<int>(type: "int", nullable: false),
                    SeanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.AbsenceId);
                    table.ForeignKey(
                        name: "FK_Absences_Inscriptions_InscriptionId",
                        column: x => x.InscriptionId,
                        principalTable: "Inscriptions",
                        principalColumn: "InscriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Absences_Seances_SeanceId",
                        column: x => x.SeanceId,
                        principalTable: "Seances",
                        principalColumn: "SeanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_FiliereId",
                table: "Inscriptions",
                column: "FiliereId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_InscriptionId",
                table: "Absences",
                column: "InscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_SeanceId",
                table: "Absences",
                column: "SeanceId");

            migrationBuilder.CreateIndex(
                name: "IX_EnsignantService_ServicesServiceId",
                table: "EnsignantService",
                column: "ServicesServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_EtudiantService_ServicesServiceId",
                table: "EtudiantService",
                column: "ServicesServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_FiliereModule_ModulesModuleId",
                table: "FiliereModule",
                column: "ModulesModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_InscriptionId",
                table: "Notes",
                column: "InscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ModuleId",
                table: "Notes",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_EnsignantId",
                table: "Seances",
                column: "EnsignantId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_groupeId",
                table: "Seances",
                column: "groupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_ModuleId",
                table: "Seances",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptions_Filieres_FiliereId",
                table: "Inscriptions",
                column: "FiliereId",
                principalTable: "Filieres",
                principalColumn: "FiliereId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_Filieres_FiliereId",
                table: "Inscriptions");

            migrationBuilder.DropTable(
                name: "Absences");

            migrationBuilder.DropTable(
                name: "Administrateurs");

            migrationBuilder.DropTable(
                name: "EnsignantService");

            migrationBuilder.DropTable(
                name: "EtudiantService");

            migrationBuilder.DropTable(
                name: "FiliereModule");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Filieres");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Inscriptions_FiliereId",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "FiliereId",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "Cin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateNaissance",
                table: "AspNetUsers");
        }
    }
}
