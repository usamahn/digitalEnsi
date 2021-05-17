using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using digitalEnsi.Models;
using Microsoft.EntityFrameworkCore;
using digitalEnsi.Models.DTO;

namespace digitalEnsi.Services
{
    public class AbsenceService:IAbsenceService
    {
        private readonly ApplicationDbContext _context;

        public AbsenceService(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task<IList<Inscription>> GetAbsence(DateTime date,int seanceId,string année_Universitaire=null,int groupeId=0){
            return await _context.Inscriptions.Where(i=>i.Année_Universitaire==année_Universitaire&&i.GroupeId==groupeId)
                                .Include(i=>i.Absences.Where(a=>a.Date==date&&a.SeanceId==seanceId))
                                .Include(i=>i.Etudiant).ToListAsync();

        }
        public async Task<ActionResult<Absence>> PostAbsence(Absence absence){
            _context.Absences.Add(absence);
            await _context.SaveChangesAsync();

            return absence;

        }
        public async Task<ActionResult<Absence>> DeleteAbsence(int id){
            var absence = await _context.Absences.FindAsync(id);
            if (absence == null)
            {
                return null;
            }

            _context.Absences.Remove(absence);
            await _context.SaveChangesAsync();

            return absence;
        }
    }

}