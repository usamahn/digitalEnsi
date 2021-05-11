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

        public async Task AjouterNote(Note note){
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
        }

        public async Task Modifynote(int id, Note note){
            _context.Entry(note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
                {
                    //return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<IEnumerable<Module>> GetEnseignantModule(string EnseignantId,int semestre=0,string année_Universitaire=null){
            if (semestre==0)
                semestre=Utils.Utils.getSemestreActuelle();
            if(année_Universitaire==null)
                année_Universitaire=Utils.Utils.getAnnéeUniversitaireActuelle();
            return await  _context.Modules.Where(m=>m.Seances.Any(s=>s.EnseignantId==EnseignantId&&s.Semestre==semestre&&s.Année_Universitaire==année_Universitaire)).ToListAsync();
            
                                        
        }
        public async Task<Module> GetModule(int id){
            var module =await _context.Modules.FindAsync(id);
            return module;
        }
        public async Task<ActionResult<IEnumerable<Module>>> GetModuleByNiveau(int niveau){
            return await _context.Modules.Where(m=>m.Niveau==niveau).ToListAsync();
        }
        public async Task<Module> PostModule(Module module){
            _context.Modules.Add(module);
            await _context.SaveChangesAsync();

            return module;

        }

        public async Task ModifyModule(int id, Module module){
            

            _context.Entry(module).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
                {
                    //return null;
                }
                else
                {
                    throw;
                }
            }

            //return null;
        }

        public async Task<Module> DeleteModule(int id){
            var module = await _context.Modules.FindAsync(id);
            if (module == null)
            {
                return null;
            }

            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();

            return module;
        }

        private bool ModuleExists(int id)
        {
            return _context.Modules.Any(e => e.ModuleId== id);
        }

    }
}