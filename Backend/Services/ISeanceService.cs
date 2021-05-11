using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using digitalEnsi.Models;

namespace digitalEnsi.Services
{
    public interface ISeanceService
    {
        
        Task<IEnumerable<Seance>> GetSeancesByGroupe(string nomGroupe,string année_Universitaire=null,int semestre=0);
        Task<Seance> AjouterSeance(Seance seance);
        Task<IEnumerable<Seance>> GetSeancesByIdEnseignant(string EnseignantId,string année_Universitaire=null,int semestre=0);
        Task<IList<DateTime>> GetDatesSeanceByIdEnseignant(string EnseignantId,int groupeId, int moduleId,
                                                        string année_Universitaire=null,int semestre=0);
    }
}