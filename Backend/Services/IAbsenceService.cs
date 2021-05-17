using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using digitalEnsi.Models;
using digitalEnsi.Models.DTO;

namespace digitalEnsi.Services
{
    public interface IAbsenceService{
        Task<IList<Inscription>> GetAbsence(DateTime date,int seanceId,string année_Universitaire=null,int groupeId=0);
        Task<ActionResult<Absence>> PostAbsence(Absence absence);
        Task<ActionResult<Absence>> DeleteAbsence(int id);

    }

}