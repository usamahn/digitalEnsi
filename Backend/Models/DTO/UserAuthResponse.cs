using System;
using System.Collections.Generic;

namespace digitalEnsi.Models.DTO
{
    public class UserAuthResponse {



        public string username {get;set;}
        public IList<string> role {get;set;}
        
        public string BearerToken {get;set;}

        public DateTime expires {get;set;}

        //other claims CanAcessPageProduct or isAdmin


    }
}