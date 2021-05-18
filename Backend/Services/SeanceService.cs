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

         public async Task<IEnumerable<Seance>> GetSeancesByIdEnseignant(string EnseignantId,
                                                                        string année_Universitaire=null,int semestre=0){
            if(année_Universitaire==null)
                année_Universitaire=Utils.Utils.getAnnéeUniversitaireActuelle();
            if(semestre==0){
                semestre=Utils.Utils.getSemestreActuelle();
            }
            return await _context.Seances.Where(s=>s.EnseignantId==EnseignantId&&s.Semestre==semestre&&s.Année_Universitaire==année_Universitaire)
                                        .Include(s=>s.Module)
                                        .Include(s=>s.Groupe)
                                        .Include(s=>s.Enseignant)
                                        .ToListAsync();
        }

         public async Task<IEnumerable<Seance>> GetSeancesByIdEtudiant(string EtudiantId,
                                                                        string année_Universitaire=null,int semestre=0){
            if(année_Universitaire==null)
                année_Universitaire=Utils.Utils.getAnnéeUniversitaireActuelle();
            if(semestre==0){
                semestre=Utils.Utils.getSemestreActuelle();
            }
            var inscription =await  _context.Inscriptions.SingleAsync(i=>i.EtudiantId==EtudiantId&&i.Année_Universitaire==année_Universitaire);
            var groupeId = inscription.GroupeId;
            return await _context.Seances.Where(s=>s.groupeId==groupeId&&s.Semestre==semestre&&s.Année_Universitaire==année_Universitaire)
                                        .Include(s=>s.Module)
                                        .Include(s=>s.Groupe)
                                        .Include(s=>s.Enseignant)
                                        .ToListAsync();
        }
        public async Task<List<DateTime>> GetDatesSeanceByIdEnseignant(string EnseignantId,int groupeId, int moduleId,
                                                        string année_Universitaire=null,int semestre=0){
                if(année_Universitaire==null)
                    année_Universitaire=Utils.Utils.getAnnéeUniversitaireActuelle();
                if(semestre==0)
                    semestre=Utils.Utils.getSemestreActuelle();
                var seances = await GetSeancesByIdEnseignant(EnseignantId,année_Universitaire,semestre);
                Console.WriteLine(seances.Count());
                var seance =seances.Where(s=>s.groupeId==groupeId&&s.ModuleId==moduleId).FirstOrDefault();
                var test =seances.Where(s=>s.groupeId==groupeId&&s.ModuleId==moduleId);
                Console.WriteLine(groupeId);
                Console.WriteLine(moduleId);
                int annee =Utils.Utils.getYear(année_Universitaire,semestre);
                int startMonth;
                int endMonth;
                if(semestre==1){
                     startMonth=9;
                     endMonth=12;
                }else{
                     startMonth=1;
                     endMonth=5;
                }
                List<DateTime> dates = new List<DateTime>();
                for(var date = new DateTime(annee,startMonth,1);date.Month<=endMonth;date=date.AddDays(1)){
                    if(date.DayOfWeek==seance.Jour){
                        dates.Add(date);
                    }
                }
                return dates;   
        
        }


                public async Task<Seance> GetSeanceByIdEnseignant(string EnseignantId,int groupeId, int moduleId,
                                                        string année_Universitaire=null,int semestre=0){
                if(année_Universitaire==null)
                    année_Universitaire=Utils.Utils.getAnnéeUniversitaireActuelle();
                if(semestre==0)
                    semestre=Utils.Utils.getSemestreActuelle();
                var seances = await GetSeancesByIdEnseignant(EnseignantId,année_Universitaire,semestre);
                var seance =seances.Where(s=>s.groupeId==groupeId&&s.ModuleId==moduleId).FirstOrDefault();
                //Console.WriteLine(seance.SeanceId);
                return seance;
        
                }

        

        public async Task<IEnumerable<Seance>> GetSeancesByGroupe(string nomGroupe,string année_Universitaire=null,int semestre=0){
            if(année_Universitaire==null)
                année_Universitaire=Utils.Utils.getAnnéeUniversitaireActuelle();
            if(semestre==0){
                semestre=Utils.Utils.getSemestreActuelle();
            }
            return await _context.Seances.Where(s=>s.Groupe.Libellé_groupe==nomGroupe&&s.Semestre==semestre&&s.Année_Universitaire==année_Universitaire)
                                        .Include(s=>s.Module)
                                        .Include(s=>s.Enseignant)
                                        .ToListAsync();
        }

        public async Task<Seance> AjouterSeance(Seance seance){
            if(seance.Année_Universitaire==null){
                seance.Année_Universitaire=Utils.Utils.getAnnéeUniversitaireActuelle();
            }
             if(seance.Semestre==0){
                seance.Semestre=Utils.Utils.getSemestreActuelle();
            }
            _context.Seances.Add(seance);
            await _context.SaveChangesAsync();

            return seance;

        }
    }

}