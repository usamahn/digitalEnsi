using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using digitalEnsi.Models;

namespace digitalEnsi.Services
{
    public interface IModuleService
    {
        Task<ActionResult<IEnumerable<Module>>> GetModule();
        Task<Module> GetModule(int id);
        Task<IEnumerable<Module>> GetEnseignantModule(string EnseignantId,int semestre=0,string année_Universitaire=null);

        Task<ActionResult<IEnumerable<Module>>> GetModuleByNiveau(int niveau);
        Task<Module> PostModule(Module module);
        Task ModifyModule(int id, Module module);
        Task<Module> DeleteModule(int id);

        Task AjouterNote(Note note);
         Task Modifynote(int id, Note note);
    }

}