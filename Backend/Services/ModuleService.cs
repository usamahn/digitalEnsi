using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using digitalEnsi.Models;

namespace digitalEnsi.Services
{
    public class ModuleService : IModuleService
    {
        private readonly ApplicationDbContext _context;

        public ModuleService(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task<ActionResult<IEnumerable<Module>>> GetModule(){
            return await _context.Modules.ToListAsync();
        }
        public async Task<ActionResult<IEnumerable<Module>>> GetModuleByNiveau(int niveau){
            return await _context.Modules.Where(m=>m.Niveau==niveau).ToListAsync();
        }
    }
}