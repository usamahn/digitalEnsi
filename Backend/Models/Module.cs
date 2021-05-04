using System;
using System.Collections.Generic;

namespace digitalEnsi.Models
{
    public class Module{
        public int ModuleId  {get;set;}
        public string LibelleModule {get;set;}
        public int Type {get;set;}

        public float VolumeHoraire {get;set;}
        public int Semestre {get;set;}
        public int Niveau {get;set;}

        public List<Filiere> Filieres {get;set;}
        public List<Note> Notes {get;set;}
         public List<Seance> Seances {get;set;}
         

    }


}