using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using digitalEnsi.Models;

namespace digitalEnsi.Services
{
    public interface IGroupeService
    {
        Task<ActionResult<IEnumerable<Groupe>>> GetGroupe();
        Task<List<Seance>> GetSeancesByGroupe(string nomGroupe);
        Task<ActionResult<Groupe>> GetGroupe(int id);
        Task<IActionResult> PutGroupe(int id, Groupe groupe);
        Task<ActionResult<Groupe>> PostGroupe(Groupe groupe);
        Task<ActionResult<Groupe>> DeleteGroupe(int id);
    }
}
