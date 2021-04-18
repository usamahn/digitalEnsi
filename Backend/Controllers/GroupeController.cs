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

namespace digitalEnsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private IGroupeService _groupeService;

        public GroupeController(ApplicationDbContext context,IGroupeService groupeService)
        {
            _context = context;
            _groupeService=groupeService;
        }

        // GET: api/Groupe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Groupe>>> GetGroupe()
        {
            return await _groupeService.GetGroupe();
        }

        // GET: api/Groupe/5
        [HttpGet("{id}")]
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
        [HttpPut("{id}")]
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
        [HttpPost]
        public async Task<ActionResult<Groupe>> PostGroupe(Groupe groupe)
        {
            await _groupeService.PostGroupe(groupe);

            return CreatedAtAction("GetGroupe", new { id = groupe.groupeId }, groupe);
        }

        // DELETE: api/Groupe/5
        [HttpDelete("{id}")]
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
