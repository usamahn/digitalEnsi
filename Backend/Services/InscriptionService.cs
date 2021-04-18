using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using digitalEnsi.Models;

namespace digitalEnsi.Services
{
    public class InscriptionService: IInscriptionService
    {
        private readonly ApplicationDbContext _context;

        public InscriptionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Inscription>> GetInscriptions(){
            return await _context.Inscriptions
            .Include(i=> i.Groupe)
            .Include(i=> i.Etudiant)
            .ToListAsync();
        }
        public async Task<ActionResult<Inscription>> GetInscription(int id){
            var inscription = await _context.Inscriptions.FindAsync(id);

            

            return inscription;
        }
        public async Task<IActionResult> PutInscription(int id, Inscription inscription){
            if (id != inscription.InscriptionId)
            {
                return null;
            }

            _context.Entry(inscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscriptionsExists(id))
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

        private bool InscriptionsExists(int id)
        {
            return _context.Inscriptions.Any(e => e.InscriptionId == id);
        }

        public async Task<ActionResult<Inscription>> PostInscription(Inscription inscription){
            _context.Inscriptions.Add(inscription);
            await _context.SaveChangesAsync();

            return inscription;

        }
        public async Task<ActionResult<Inscription>> DeleteInscription(int id){
            var inscription = await _context.Inscriptions.FindAsync(id);
            if (inscription == null)
            {
                return null;
            }

            _context.Inscriptions.Remove(inscription);
            await _context.SaveChangesAsync();

            return inscription;
        }
    }
}