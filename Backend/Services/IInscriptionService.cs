using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using digitalEnsi.Models;

namespace digitalEnsi.Services
{
    public interface IInscriptionService
    {
        Task<IEnumerable<Inscription>> GetInscriptions();
        Task<ActionResult<Inscription>> GetInscription(int id);
        Task<List<Inscription>> GetInscriptionNoteByModuleGroupe(string année_Universitaire,int groupeId,int moduleId);
        Task<IActionResult> PutInscription(int id, Inscription inscription);
        Task<ActionResult<Inscription>> PostInscription(Inscription inscription);
        Task<ActionResult<Inscription>> DeleteInscription(int id);
    }
}
