namespace digitalEnsi.Models.DTO
{
    public class AbsenceInfoModel
    {
        public int InscriptionId  {get;set;}
        public int SeanceId  {get;set;}
        public int AbsenceId  {get;set;}
        public string UserName { get; set; }
        public string Nom { get; set; }

        public int? Niveau {get;set;}
        public string Groupe {get;set;}

        public bool Present {get;set;}


    }
}