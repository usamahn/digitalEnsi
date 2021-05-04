namespace digitalEnsi.Models.DTO
{
    public class NoteModuleParGroupeModel
    {

        public string Nom { get; set; }

        public float NoteDs {get;set;}
        public float NoteCc {get;set;}
        public float NoteExamenP {get;set;}
        public float? NoteExamenR {get;set;}

        public float MoyennePrincipal {get;set;}
        public float? MoyenneRattrapage {get;set;} 
        

    }

}