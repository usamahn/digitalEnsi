using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using digitalEnsi.Models;
using digitalEnsi.Models.DTO;

namespace digitalEnsi.Services
{
    public interface IEnseignantService
    {

        Task<Enseignant> GetEnseignantAsync(string id);
        Task<IEnumerable<Enseignant>> GetEnseignantsAsync();
        Task<Enseignant> GetEnseignantByCinAsync(string cin,bool includeDetails=true);
        Task UpdateEnseignantAsync(UserUpdateModel newEnseignant);
    }
}