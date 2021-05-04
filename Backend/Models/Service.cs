using System;
using System.Collections.Generic;

namespace digitalEnsi.Models
{
    public class Service{
        public int ServiceId  {get;set;}
        public string LibelleService {get;set;}

        public List<Etudiant> Etudiants {get;set;}
        public List<Enseignant> Enseignants {get;set;}
        
         

    }


}