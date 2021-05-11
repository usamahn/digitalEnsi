using System;
using System.Collections.Generic;

namespace digitalEnsi.Models
{
    public class Seance{
        public int SeanceId  {get;set;}
        public DayOfWeek Jour {get;set;}
        public TimeSpan HeureDeb {get;set;}
        public TimeSpan HeureFin {get;set;}
        public string Année_Universitaire {get;set;}
        public int Semestre {get;set;}


        public int groupeId  {get;set;}

        public Groupe Groupe {get;set;}

        public string EnseignantId {get;set;}

        public Enseignant Enseignant {get;set;}

        public int ModuleId  {get;set;}
        public Module Module {get;set;}

        public List<Absence> Absences {get;set;}
        

    }


}