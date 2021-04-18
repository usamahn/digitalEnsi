using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace digitalEnsi.Models
{
    [Table("Etudiants")]
    public class Etudiant:ApplicationUser{
        
        
        public List<Inscription> Inscriptions {get;set;}
        public List<Service> Services {get;set;}
        
    }


}