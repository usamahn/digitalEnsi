
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
      
        public DbSet<Etudiant> Etudiants {get;set;}
        public DbSet<Ensignant> Ensignants {get;set;}
        public DbSet<Inscription> Inscriptions {get;set;}
        public DbSet<Groupe> Groupe {get;set;}
    }
    

}