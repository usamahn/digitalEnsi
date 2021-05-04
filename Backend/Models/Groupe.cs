using System.Collections.Generic;

namespace digitalEnsi.Models
{
    public class Groupe{
        public int groupeId  {get;set;}
        public string Libellé_groupe {get;set;}
        public int Niveau {get;set;}
        public List<Inscription> Inscription {get;set;}
        public List<Seance> Seances {get;set;}
    }


}