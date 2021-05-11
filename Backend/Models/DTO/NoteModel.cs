namespace digitalEnsi.Models.DTO
{
    public class NoteModel
    {

        public string Nom {get;set;}

        public int NoteId  {get;set;}
        public float NoteDs {get;set;}
        public float NoteCc {get;set;}
        public float NoteExamenP {get;set;}
        public float? NoteExamenR {get;set;}

        public int InscriptionId  {get;set;}
    }
    
    
}