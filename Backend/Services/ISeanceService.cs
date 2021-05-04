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
        
        Task<IEnumerable<Seance>> GetSeancesByGroupe(string nomGroupe);
        Task<Seance> AjouterSeance(Seance seance);
    }
}