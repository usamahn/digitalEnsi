﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using digitalEnsi;

namespace digitalEnsi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EnsignantService", b =>
                {
                    b.Property<string>("EnsignantsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ServicesServiceId")
                        .HasColumnType("int");

                    b.HasKey("EnsignantsId", "ServicesServiceId");

                    b.HasIndex("ServicesServiceId");

                    b.ToTable("EnsignantService");
                });

            modelBuilder.Entity("EtudiantService", b =>
                {
                    b.Property<string>("EtudiantsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ServicesServiceId")
                        .HasColumnType("int");

                    b.HasKey("EtudiantsId", "ServicesServiceId");

                    b.HasIndex("ServicesServiceId");

                    b.ToTable("EtudiantService");
                });

            modelBuilder.Entity("FiliereModule", b =>
                {
                    b.Property<int>("FilieresFiliereId")
                        .HasColumnType("int");

                    b.Property<int>("ModulesModuleId")
                        .HasColumnType("int");

                    b.HasKey("FilieresFiliereId", "ModulesModuleId");

                    b.HasIndex("ModulesModuleId");

                    b.ToTable("FiliereModule");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("digitalEnsi.Models.Absence", b =>
                {
                    b.Property<int>("AbsenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("InscriptionId")
                        .HasColumnType("int");

                    b.Property<int>("SeanceId")
                        .HasColumnType("int");

                    b.HasKey("AbsenceId");

                    b.HasIndex("InscriptionId");

                    b.HasIndex("SeanceId");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("digitalEnsi.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Cin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("digitalEnsi.Models.Filiere", b =>
                {
                    b.Property<int>("FiliereId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacité")
                        .HasColumnType("int");

                    b.Property<string>("libelleFiliere")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FiliereId");

                    b.ToTable("Filieres");
                });

            modelBuilder.Entity("digitalEnsi.Models.Groupe", b =>
                {
                    b.Property<int>("groupeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Libellé_groupe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("groupeId");

                    b.ToTable("Groupe");
                });

            modelBuilder.Entity("digitalEnsi.Models.Inscription", b =>
                {
                    b.Property<int>("InscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Année_Universitaire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Etat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EtudiantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FiliereId")
                        .HasColumnType("int");

                    b.Property<int>("GroupeId")
                        .HasColumnType("int");

                    b.Property<string>("Niveau")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InscriptionId");

                    b.HasIndex("EtudiantId");

                    b.HasIndex("FiliereId");

                    b.HasIndex("GroupeId");

                    b.ToTable("Inscriptions");
                });

            modelBuilder.Entity("digitalEnsi.Models.Module", b =>
                {
                    b.Property<int>("ModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LibelleModule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semestre")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<float>("VolumeHoraire")
                        .HasColumnType("real");

                    b.HasKey("ModuleId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("digitalEnsi.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InscriptionId")
                        .HasColumnType("int");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<float>("NoteCc")
                        .HasColumnType("real");

                    b.Property<float>("NoteDs")
                        .HasColumnType("real");

                    b.Property<float>("NoteExamenP")
                        .HasColumnType("real");

                    b.Property<float>("NoteExamenR")
                        .HasColumnType("real");

                    b.HasKey("NoteId");

                    b.HasIndex("InscriptionId");

                    b.HasIndex("ModuleId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("digitalEnsi.Models.Seance", b =>
                {
                    b.Property<int>("SeanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnsignantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("HeureDeb")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HeureFin")
                        .HasColumnType("time");

                    b.Property<int>("Jour")
                        .HasColumnType("int");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<int>("groupeId")
                        .HasColumnType("int");

                    b.HasKey("SeanceId");

                    b.HasIndex("EnsignantId");

                    b.HasIndex("ModuleId");

                    b.HasIndex("groupeId");

                    b.ToTable("Seances");
                });

            modelBuilder.Entity("digitalEnsi.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LibelleService")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("digitalEnsi.Models.Administrateur", b =>
                {
                    b.HasBaseType("digitalEnsi.Models.ApplicationUser");

                    b.ToTable("Administrateurs");
                });

            modelBuilder.Entity("digitalEnsi.Models.Ensignant", b =>
                {
                    b.HasBaseType("digitalEnsi.Models.ApplicationUser");

                    b.ToTable("Ensignants");
                });

            modelBuilder.Entity("digitalEnsi.Models.Etudiant", b =>
                {
                    b.HasBaseType("digitalEnsi.Models.ApplicationUser");

                    b.ToTable("Etudiants");
                });

            modelBuilder.Entity("EnsignantService", b =>
                {
                    b.HasOne("digitalEnsi.Models.Ensignant", null)
                        .WithMany()
                        .HasForeignKey("EnsignantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("digitalEnsi.Models.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EtudiantService", b =>
                {
                    b.HasOne("digitalEnsi.Models.Etudiant", null)
                        .WithMany()
                        .HasForeignKey("EtudiantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("digitalEnsi.Models.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FiliereModule", b =>
                {
                    b.HasOne("digitalEnsi.Models.Filiere", null)
                        .WithMany()
                        .HasForeignKey("FilieresFiliereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("digitalEnsi.Models.Module", null)
                        .WithMany()
                        .HasForeignKey("ModulesModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("digitalEnsi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("digitalEnsi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("digitalEnsi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("digitalEnsi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("digitalEnsi.Models.Absence", b =>
                {
                    b.HasOne("digitalEnsi.Models.Inscription", "Inscription")
                        .WithMany("Absences")
                        .HasForeignKey("InscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("digitalEnsi.Models.Seance", "Seance")
                        .WithMany("Absences")
                        .HasForeignKey("SeanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inscription");

                    b.Navigation("Seance");
                });

            modelBuilder.Entity("digitalEnsi.Models.Inscription", b =>
                {
                    b.HasOne("digitalEnsi.Models.Etudiant", "Etudiant")
                        .WithMany("Inscriptions")
                        .HasForeignKey("EtudiantId");

                    b.HasOne("digitalEnsi.Models.Filiere", "Filiere")
                        .WithMany("Inscriptions")
                        .HasForeignKey("FiliereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("digitalEnsi.Models.Groupe", "Groupe")
                        .WithMany("Inscription")
                        .HasForeignKey("GroupeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etudiant");

                    b.Navigation("Filiere");

                    b.Navigation("Groupe");
                });

            modelBuilder.Entity("digitalEnsi.Models.Note", b =>
                {
                    b.HasOne("digitalEnsi.Models.Inscription", "Inscription")
                        .WithMany("Notes")
                        .HasForeignKey("InscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("digitalEnsi.Models.Module", "Module")
                        .WithMany("Notes")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inscription");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("digitalEnsi.Models.Seance", b =>
                {
                    b.HasOne("digitalEnsi.Models.Ensignant", "Ensignant")
                        .WithMany("Seances")
                        .HasForeignKey("EnsignantId");

                    b.HasOne("digitalEnsi.Models.Module", "Module")
                        .WithMany("Seances")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("digitalEnsi.Models.Groupe", "Groupe")
                        .WithMany("Seances")
                        .HasForeignKey("groupeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ensignant");

                    b.Navigation("Groupe");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("digitalEnsi.Models.Administrateur", b =>
                {
                    b.HasOne("digitalEnsi.Models.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("digitalEnsi.Models.Administrateur", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("digitalEnsi.Models.Ensignant", b =>
                {
                    b.HasOne("digitalEnsi.Models.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("digitalEnsi.Models.Ensignant", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("digitalEnsi.Models.Etudiant", b =>
                {
                    b.HasOne("digitalEnsi.Models.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("digitalEnsi.Models.Etudiant", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("digitalEnsi.Models.Filiere", b =>
                {
                    b.Navigation("Inscriptions");
                });

            modelBuilder.Entity("digitalEnsi.Models.Groupe", b =>
                {
                    b.Navigation("Inscription");

                    b.Navigation("Seances");
                });

            modelBuilder.Entity("digitalEnsi.Models.Inscription", b =>
                {
                    b.Navigation("Absences");

                    b.Navigation("Notes");
                });

            modelBuilder.Entity("digitalEnsi.Models.Module", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("Seances");
                });

            modelBuilder.Entity("digitalEnsi.Models.Seance", b =>
                {
                    b.Navigation("Absences");
                });

            modelBuilder.Entity("digitalEnsi.Models.Ensignant", b =>
                {
                    b.Navigation("Seances");
                });

            modelBuilder.Entity("digitalEnsi.Models.Etudiant", b =>
                {
                    b.Navigation("Inscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
