using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace digitalEnsi.Models
{
    [Table("Ensignants")]
    public class Ensignant:ApplicationUser{
        
        public List<Seance> Seances {get;set;}
        public List<Service> Services {get;set;}
        
    }


}