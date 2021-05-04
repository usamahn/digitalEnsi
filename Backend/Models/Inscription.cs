using System;
using System.Collections.Generic;

namespace digitalEnsi.Models
{
    public class Inscription{
        public int InscriptionId  {get;set;}
        public string Année_Universitaire {get;set;}
        public string Etat {get;set;}
        public string Niveau {get;set;}
        public string EtudiantId {get;set;}
        public Etudiant Etudiant {get;set;}
        public int GroupeId {get;set;}
        public Groupe Groupe {get;set;}
        public int? FiliereId  {get;set;}
        public Filiere Filiere {get;set;}

        public List<Absence> Absences {get;set;}
        public List<Note> Notes {get;set;}
    }


}