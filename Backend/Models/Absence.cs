using System;

namespace digitalEnsi.Models
{
    public class Absence{
        public int AbsenceId  {get;set;}
        public DateTime Date {get;set;}
        public int InscriptionId  {get;set;}

        public Inscription Inscription {get;set;}

        public int SeanceId  {get;set;}
        public Seance Seance {get;set;}


         

    }


}