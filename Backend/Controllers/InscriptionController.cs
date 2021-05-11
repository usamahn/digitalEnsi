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
using digitalEnsi.Models.Resources;
using digitalEnsi.DTO;
using AutoMapper;

namespace digitalEnsi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "JwtBearer",Roles = "Admin")]
    public class InscriptionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        private IInscriptionService _inscriptionService;
        private readonly IEtudiantService _etudiantService;

        public InscriptionController(ApplicationDbContext context,IInscriptionService inscriptionService,IMapper mapper,IEtudiantService etudiantService)
        {
            _context = context;
            _inscriptionService=inscriptionService;
            _mapper=mapper;
            _etudiantService=etudiantService;
        }

        // GET: api/Inscription
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Inscription>>> GetInscription([FromQuery] InscriptionsFilterParameters inscriptionsFilterParameters)
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
        public async Task<IActionResult> PutInscription(int id, InscriptionModel inscription)
        {
            
            
            if (id != inscription.InscriptionId)
            {
                return BadRequest();
            }
            var newInscription =_mapper.Map<Inscription>(inscription);
            newInscription.EtudiantId=await _etudiantService.GetEtudiantIdByCin(inscription.Cin);

            return await _inscriptionService.PutInscription( id,  newInscription);

            
        }

        // POST: api/Inscription
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        
        public async Task<ActionResult<Inscription>> PostInscription(InscriptionModel inscriptionModel)
        {
            var inscription =_mapper.Map<Inscription>(inscriptionModel);
            inscription.EtudiantId=await _etudiantService.GetEtudiantIdByCin(inscriptionModel.Cin);
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
