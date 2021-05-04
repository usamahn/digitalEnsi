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
        public async Task<ActionResult<IEnumerable<Module>>> GetModule()
        {
            return await _moduleService.GetModule();
        }

        [HttpGet("api/ModuleNote")]
        public async Task<IEnumerable<NoteModuleParGroupeModel>> GetNoteModuleParGroupe([FromQuery]string année_Universitaire,int groupeId,int moduleId)
        {
            Console.WriteLine(année_Universitaire);
            var inscriptions= await _inscriptionService.GetInscriptionNoteByModuleGroupe(année_Universitaire, groupeId, moduleId);
            return _mapper.Map<IEnumerable<NoteModuleParGroupeModel>>(inscriptions);
        }

        [HttpGet("api/Module/Niveau/{niveau}")]
        public async Task<ActionResult<IEnumerable<Module>>> GetNotesModuleParGroupe(int niveau)
        {
            return await _moduleService.GetModuleByNiveau(niveau);
        }

    }

}