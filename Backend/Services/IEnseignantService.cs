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
        Task<IEnumerable<Enseignant>> GetEnseignantsAsync();
        Task UpdateEnseignantAsync(UserUpdateModel newEnseignant);
    }
}