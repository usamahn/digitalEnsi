using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using digitalEnsi;
using digitalEnsi.Models;
using digitalEnsi.Services;
using AutoMapper;
using digitalEnsi.Models.DTO;

namespace digitalEnsi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;

        private IAbsenceService _absenceService;
        private readonly IMapper _mapper;


        public AbsenceController(IAbsenceService absenceService,IMapper mapper)
        {
            //_context = context;
            _absenceService=absenceService;
            _mapper=mapper;
        }


        [HttpGet("api/Absence")]
        public async Task<IEnumerable<AbsenceInfoModel>> GetAbsences([FromQuery] string année_Universitaire,[FromQuery]int seanceId,[FromQuery]int groupeId,string date){
            if(groupeId!=0){
                if(String.IsNullOrWhiteSpace(année_Universitaire))
                    année_Universitaire=Utils.Utils.getAnnéeUniversitaireActuelle();
                
            }

                var absences = await _absenceService.GetAbsence(DateTime.Parse(date) , seanceId,année_Universitaire,groupeId) ;
                return _mapper.Map<IEnumerable<AbsenceInfoModel>>(absences);
        }


        [HttpPost("api/Absence")]
        public async Task<ActionResult<Absence>> PostAbsence(Absence absence)
        {
            await _absenceService.PostAbsence(absence);

            //return CreatedAtAction("GetGroupe", new { id = groupe.groupeId }, groupe);
            return Ok();
        }



        [HttpDelete("api/Absence/{id}")]
        public async Task<IActionResult> DeleteAbsence(int id)
        {
            var groupe = await _absenceService.DeleteAbsence(id);
            if (groupe == null)
            {
                return NotFound();
            }

            return NoContent();
        }

            



    }
    
}