using System;

namespace digitalEnsi.Models
{
    public class Note{
        public int NoteId  {get;set;}
        public float NoteDs {get;set;}
        public float NoteCc {get;set;}
        public float NoteExamenP {get;set;}
        public float? NoteExamenR {get;set;}

        public int InscriptionId  {get;set;}
        public Inscription Inscription {get;set;}

        public int ModuleId  {get;set;}

        public Module Module {get;set;}

        public float getMoyennePrincipale(){
                    if(Module.Type==1){
                        return (float)(0.1 *NoteCc+0.2*NoteDs + 0.7*NoteExamenP);
                    }
                    else{
                        return (float)(0.4 *NoteCc + 0.6*NoteExamenP);
                    }
        }
        public float? getMoyenneRattrapage(){
            if(NoteExamenR!=null)
                   { if(Module.Type==1){
                        return (float)(0.1 *NoteCc+0.2*NoteDs + 0.7*NoteExamenR);
                    }
                    else{
                        return (float)(0.4 *NoteCc + 0.6*NoteExamenR);
                    }}
            else return null;
        }
        

         

    }


}