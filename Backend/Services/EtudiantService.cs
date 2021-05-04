using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using digitalEnsi.Models;
using Microsoft.AspNetCore.Identity;
using digitalEnsi.Models.DTO;

namespace digitalEnsi.Services
{
    public class EtudiantService : IEtudiantService
    {

        private readonly UserManager<Etudiant> _etudiantManager;
        private readonly ApplicationDbContext _context;

        public EtudiantService(UserManager <Etudiant> etudiantManager,ApplicationDbContext context){
            _etudiantManager=etudiantManager;
            _context=context;
            
        }

        public async Task<IEnumerable<Etudiant>> GetEtudiantsAsync(){
            /*var etudiants =await  _etudiantManager.Users.ToListAsync();
            return etudiants;*/
            return await _context.Etudiants
                                 .Include(e=>e.Inscriptions)
                                 .ThenInclude(i=>i.Groupe)
                                 .ToListAsync();

        }

        public async Task UpdateEtudiantAsync(UserUpdateModel newEtudiant){
            //TODO : ki ybadel l mail w ybadel el tel lezm logique wahdou
            var etudiant = await _context.Etudiants.Where(e=>e.Cin==newEtudiant.Cin).SingleAsync();
            Console.WriteLine(etudiant);
            _context.Entry(etudiant).CurrentValues.SetValues(newEtudiant);
            _context.Entry(etudiant).State= EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Etudiant> GetEtudiantByCinAsync(string cin,bool includeDetails=true){
            if (includeDetails)
            return await _context.Etudiants.Where(e=>e.Cin==cin)
                                           .Include(e=>e.Inscriptions)
                                           .ThenInclude(i=>i.Groupe)
                                           .SingleAsync();
            else return await _context.Etudiants.Where(e=>e.Cin==cin).SingleAsync();
            

        }

    }
}