using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using digitalEnsi.Factories;
using digitalEnsi.Models;
using digitalEnsi.Models.DTO;
using digitalEnsi.Services;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace digitalEnsi.Controllers
{



    [ApiController]
    //[Route("api/[controller]")]

    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;
        private readonly IInscriptionService _inscriptionService;
        private readonly IMapper _mapper;


        public ModuleController(IModuleService moduleService,IInscriptionService inscriptionService,IMapper mapper){
            _moduleService= moduleService;
            _inscriptionService=inscriptionService;
            _mapper=mapper;
        }

        [HttpGet("api/Module")]
        [Authorize(AuthenticationSchemes = "JwtBearer")]
        public async Task<ActionResult<IEnumerable<Module>>> GetModule()
        {   
            return
             await _moduleService.GetModule();
        }

        [HttpGet("api/Module/{id}")]
        public async Task<ActionResult<Module>> GetModule(int id)
        {
            var module =await  _moduleService.GetModule(id);

            if (module == null)
            {
                return NotFound();
            }

            return module;
        }

        [HttpGet("api/ModuleNote")]
        public async Task<IEnumerable<NoteModuleParGroupeModel>> GetNoteModuleParGroupe([FromQuery]string année_Universitaire,int groupeId,int moduleId)
        {
            Console.WriteLine(année_Universitaire);
            var inscriptions= await _inscriptionService.GetInscriptionNoteByModuleGroupe(groupeId, moduleId);
            return _mapper.Map<IEnumerable<NoteModuleParGroupeModel>>(inscriptions);
        }

        [HttpGet("api/Module/Niveau/{niveau}")]
        public async Task<ActionResult<IEnumerable<Module>>> GetNotesModuleParGroupe(int niveau)
        {
            return await _moduleService.GetModuleByNiveau(niveau);
        }

        [HttpPost("api/Module")]
        public async Task<ActionResult<Module>> PostModule(Module module)
        {
            await _moduleService.PostModule(module);

            return CreatedAtAction("GetModule", new { id = module.ModuleId }, module);
        }



        [HttpPost("api/Module/{moduleId}/Note")]
        public async Task<ActionResult<Module>> PostNoteModule([FromBody] Note note)
        {
            
            await _moduleService.AjouterNote(note);
            return Ok();
            //return CreatedAtAction("GetModule", new { id = module.ModuleId }, module);
        }


        [HttpPut("api/Module/{moduleId}/Note")]
        public async Task<ActionResult<Module>> PutNoteModule(int moduleId,[FromBody] Note note)
        {
            
            await _moduleService.Modifynote(moduleId,note);
            return Ok(); 
            //return CreatedAtAction("GetModule", new { id = module.ModuleId }, module);
        }




        [HttpPut("api/Module/{id}")]
        public async Task<IActionResult> PutModule(int id, Module module)
        {

            
            if (id != module.ModuleId)
            {
                return BadRequest();
            }

            await _moduleService.ModifyModule( id,  module);
            return Ok();

            
        }

        [HttpDelete("api/Module/{id}")]
        public async Task<IActionResult> DeleteGroupe(int id)
        {
            var module = await _moduleService.DeleteModule(id);
            if (module == null)
            {
                return NotFound();
            }

            

            return NoContent();
        }

    }

}