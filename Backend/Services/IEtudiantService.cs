using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using digitalEnsi.Models;
using digitalEnsi.Models.DTO;

namespace digitalEnsi.Services
{
    public interface IEtudiantService
    {
        Task<IEnumerable<Etudiant>> GetEtudiantsAsync(string année_Universitaire=null,int groupeId=0);
        Task<Etudiant> GetEtudiantByCinAsync(string cin,bool includeDetails=true);
        Task UpdateEtudiantAsync(UserUpdateModel newEtudiant);
        Task<string> GetEtudiantIdByCin(string cin);
        
    }
}