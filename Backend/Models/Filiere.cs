using System;
using System.Collections.Generic;

namespace digitalEnsi.Models
{
    public class Filiere{
        public int FiliereId  {get;set;}
        public string libelleFiliere {get;set;}
        public int Capacité {get;set;}
        public List<Inscription> Inscriptions {get;set;}
        public List<Module> Modules {get;set;}
        

         

    }


}