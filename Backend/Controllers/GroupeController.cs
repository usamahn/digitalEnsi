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
    public class GroupeController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;

        private IGroupeService _groupeService;
        private readonly IMapper _mapper;


        public GroupeController(ApplicationDbContext context,IGroupeService groupeService,IMapper mapper)
        {
            //_context = context;
            _groupeService=groupeService;
            _mapper=mapper;
        }

        // GET: api/Groupe
        [HttpGet("api/Groupe")]
        public async Task<ActionResult<IEnumerable<Groupe>>> GetGroupe()
        {
            return await _groupeService.GetGroupe();
        }
        [HttpGet("api/Groupe/{nomGroupe}/Seances")]
        public async Task<IEnumerable<SeanceEmploiModel>> GetSeanceByGroupe(string nomGroupe)
        {
            var seances =await _groupeService.GetSeancesByGroupe(nomGroupe);
            return _mapper.Map<IEnumerable<SeanceEmploiModel>>(seances);
            
        }

        // GET: api/Groupe/5
        [HttpGet("api/Groupe/{id}")]
        public async Task<ActionResult<Groupe>> GetGroupe(int id)
        {
            var groupe =await  _groupeService.GetGroupe(id);

            if (groupe == null)
            {
                return NotFound();
            }

            return groupe;
        }

        // PUT: api/Groupe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("api/Groupe/{id}")]
        public async Task<IActionResult> PutGroupe(int id, Groupe groupe)
        {

            
            if (id != groupe.groupeId)
            {
                return BadRequest();
            }

            return await _groupeService.PutGroupe( id,  groupe);

            
        }

        // POST: api/Groupe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("api/Groupe")]
        public async Task<ActionResult<Groupe>> PostGroupe(Groupe groupe)
        {
            await _groupeService.PostGroupe(groupe);

            return CreatedAtAction("GetGroupe", new { id = groupe.groupeId }, groupe);
        }

        // DELETE: api/Groupe/5
        [HttpDelete("api/Groupe/{id}")]
        public async Task<IActionResult> DeleteGroupe(int id)
        {
            var groupe = await _groupeService.DeleteGroupe(id);
            if (groupe == null)
            {
                return NotFound();
            }

            

            return NoContent();
        }

        
    }
}
