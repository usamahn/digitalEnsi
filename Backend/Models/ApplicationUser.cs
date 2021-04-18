using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace digitalEnsi.Models
{
    public class ApplicationUser:IdentityUser{
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Cin {get;set;}
        public string Nom {get;set;}
        public string Prenom {get;set;}
        
        public DateTime DateNaissance {get;set;}
    }


}