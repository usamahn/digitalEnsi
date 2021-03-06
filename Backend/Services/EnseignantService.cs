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

        public async Task<Enseignant> GetEnseignantAsync(string id){
            return await _context.Enseignants.FindAsync(id);
        }

            public async Task<IEnumerable<Enseignant>> GetEnseignantsAsync(){
            /*var etudiants =await  _etudiantManager.Users.ToListAsync();
            return etudiants;*/
            return await _context.Enseignants.ToListAsync();

        }
            public async Task<Enseignant> GetEnseignantByCinAsync(string cin,bool includeDetails=true){
            if (includeDetails)
            return await _context.Enseignants.Where(e=>e.Cin==cin)
                                           .Include(e=>e.Seances)
                                           .FirstAsync();
            else return await _context.Enseignants.Where(e=>e.Cin==cin).SingleAsync();
            

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