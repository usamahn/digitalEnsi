using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize(AuthenticationSchemes = "JwtBearer",Roles =  "Admin")]
    public class InscriptionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private IInscriptionService _inscriptionService;

        public InscriptionController(ApplicationDbContext context,IInscriptionService inscriptionService)
        {
            _context = context;
            _inscriptionService=inscriptionService;
        }

        // GET: api/Inscription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inscription>>> GetInscription()
        {
            var i =await _inscriptionService.GetInscriptions();
          
            
            return  i.ToList();
        }

        // GET: api/Inscription/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inscription>> GetInscription(int id)
        {
            var inscription =await  _inscriptionService.GetInscription(id);

            if (inscription == null)
            {
                return NotFound();
            }

            return inscription;
        }

        // PUT: api/Inscription/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscription(int id, Inscription inscription)
        {

            
            if (id != inscription.InscriptionId)
            {
                return BadRequest();
            }

            return await _inscriptionService.PutInscription( id,  inscription);

            
        }

        // POST: api/Inscription
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        
        public async Task<ActionResult<Inscription>> PostInscription(Inscription inscription)
        {
            await _inscriptionService.PostInscription(inscription);

            return CreatedAtAction("GetInscription", new { id = inscription.InscriptionId }, inscription);
        }

        // DELETE: api/Inscription/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscription(int id)
        {
            var inscription = await _inscriptionService.DeleteInscription(id);
            if (inscription == null)
            {
                return NotFound();
            }

            

            return NoContent();
        }

        
    }
}
