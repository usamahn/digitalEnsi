using System;

namespace digitalEnsi.Models.DTO
{
    public class RegistrationModel{
        public string Cin {get;set;}
        public  string Email { get; set; }
        public string UserName { get; set; }
        public  string Password { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public string DateNaissance {get;set;}
        public string PhoneNumber { get; set; }

        

    } 
}