using System;
using System.Collections.Generic;

namespace digitalEnsi.DTO
{
    public class InscriptionModel{
        public int InscriptionId  {get;set;}

        public string Cin {get;set;}

        public string Année_Universitaire {get;set;}
        public string Etat {get;set;}
        public string Niveau {get;set;}
        public string EtudiantId {get;set;}
        public int GroupeId {get;set;}
        public int? FiliereId  {get;set;}

    }


}