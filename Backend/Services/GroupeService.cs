using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using digitalEnsi.Models;

namespace digitalEnsi.Services
{
    public class GroupeService : IGroupeService
    {
        private readonly ApplicationDbContext _context;

        public GroupeService(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<ActionResult<IEnumerable<Groupe>>> GetGroupe(){
            var groupes= await _context.Groupe.ToListAsync();
            //groupes.Sort();
            return groupes;
        }

        public async Task<List<Seance>> GetSeancesByGroupe(string nomGroupe){
            var query=  _context.Groupe
                                .Include(g=>g.Seances)
                                .ThenInclude(s=>s.Enseignant)
                                .Include(g=>g.Seances)
                                .ThenInclude(s=>s.Module);
                                
            var result =await  query.Where(g=>g.Libellé_groupe==nomGroupe).Select(g=>g.Seances).FirstOrDefaultAsync();
            return result;
                                
        }

        public async Task<IEnumerable<Groupe>> GetEnseignantGroupe(string EnseignantId,int semestre=0,string année_Universitaire=null){
            if (semestre==0)
                semestre=Utils.Utils.getSemestreActuelle();
            if(année_Universitaire==null)
                année_Universitaire=Utils.Utils.getAnnéeUniversitaireActuelle();
            return await  _context.Groupe.Where(g=>g.Seances.Any(s=>s.EnseignantId==EnseignantId&&s.Semestre==semestre&&s.Année_Universitaire==année_Universitaire)).ToListAsync();
            
                                        
        }

        

        public async Task<ActionResult<Groupe>> GetGroupe(int id){
            var groupe = await _context.Groupe.FindAsync(id);

            

            return groupe;
        }
        public async Task<IActionResult> PutGroupe(int id, Groupe groupe){
            

            _context.Entry(groupe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupeExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return null;
        }

        private bool GroupeExists(int id)
        {
            return _context.Groupe.Any(e => e.groupeId == id);
        }

        public async Task<ActionResult<Groupe>> PostGroupe(Groupe groupe){
            _context.Groupe.Add(groupe);
            await _context.SaveChangesAsync();

            return groupe;

        }
        public async Task<ActionResult<Groupe>> DeleteGroupe(int id){
            var groupe = await _context.Groupe.FindAsync(id);
            if (groupe == null)
            {
                return null;
            }

            _context.Groupe.Remove(groupe);
            await _context.SaveChangesAsync();

            return groupe;
        }
    }
}