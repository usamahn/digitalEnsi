
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using digitalEnsi.Models;

namespace digitalEnsi
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Absence> Absences {get;set;}
        public DbSet<Administrateur> Administrateurs {get;set;}

      
        public DbSet<Etudiant> Etudiants {get;set;}
        public DbSet<Ensignant> Ensignants {get;set;}
        public DbSet<Filiere> Filieres {get;set;}
        public DbSet<Groupe> Groupe {get;set;}
        
        public DbSet<Inscription> Inscriptions {get;set;}
        public DbSet<Module> Modules {get;set;}
        public DbSet<Note> Notes {get;set;}
        public DbSet<Seance> Seances {get;set;}
        public DbSet<Service> Services {get;set;}
        
    }
    

}