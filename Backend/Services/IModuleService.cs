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
        Task<ActionResult<IEnumerable<Module>>> GetModuleByNiveau(int niveau);
    }

}