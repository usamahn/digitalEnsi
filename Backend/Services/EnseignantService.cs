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
    public class EnseignantService:IEnseignantService
    {
        private readonly ApplicationDbContext _context;

        public EnseignantService(ApplicationDbContext context){
            _context=context;
            
        }

            public async Task<IEnumerable<Enseignant>> GetEnseignantsAsync(){
            /*var etudiants =await  _etudiantManager.Users.ToListAsync();
            return etudiants;*/
            return await _context.Enseignants.ToListAsync();

        }

            public async Task UpdateEnseignantAsync(UserUpdateModel newEnseignant){
            //TODO : ki ybadel l mail w ybadel el tel lezm logique wahdou
            var enseignant = await _context.Enseignants.Where(e=>e.Cin==newEnseignant.Cin).SingleAsync();
            Console.WriteLine(enseignant);
            _context.Entry(enseignant).CurrentValues.SetValues(newEnseignant);
            _context.Entry(enseignant).State= EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}