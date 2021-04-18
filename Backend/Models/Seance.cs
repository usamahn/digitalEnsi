using System;
using System.Collections.Generic;

namespace digitalEnsi.Models
{
    public class Seance{
        public int SeanceId  {get;set;}
        public DayOfWeek Jour {get;set;}
        public TimeSpan HeureDeb {get;set;}
        public TimeSpan HeureFin {get;set;}

        public int groupeId  {get;set;}

        public Groupe Groupe {get;set;}

        public string EnsignantId {get;set;}

        public Ensignant Ensignant {get;set;}

        public int ModuleId  {get;set;}
        public Module Module {get;set;}

        public List<Absence> Absences {get;set;}
        

    }


}