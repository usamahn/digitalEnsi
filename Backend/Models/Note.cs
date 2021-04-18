using System;

namespace digitalEnsi.Models
{
    public class Note{
        public int NoteId  {get;set;}
        public float NoteDs {get;set;}
        public float NoteCc {get;set;}
        public float NoteExamenP {get;set;}
        public float NoteExamenR {get;set;}

        public int InscriptionId  {get;set;}
        public Inscription Inscription {get;set;}

        public int ModuleId  {get;set;}

        public Module Module {get;set;}

         

    }


}