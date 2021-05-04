using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using digitalEnsi.Models;

namespace digitalEnsi.Services
{
    public class SeanceService : ISeanceService
    {
        private readonly ApplicationDbContext _context;

        public SeanceService(ApplicationDbContext context)
        {
            _context = context;
            
        }


        public async Task<IEnumerable<Seance>> GetSeancesByGroupe(string nomGroupe){
            return await _context.Seances.Where(s=>s.Groupe.Libellé_groupe==nomGroupe)
                                        .Include(s=>s.Module)
                                        .Include(s=>s.Enseignant)
                                        .ToListAsync();
        }

        public async Task<Seance> AjouterSeance(Seance seance){
            _context.Seances.Add(seance);
            await _context.SaveChangesAsync();

            return seance;

        }
    }

}