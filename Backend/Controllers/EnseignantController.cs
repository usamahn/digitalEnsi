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

    public class EnseignantController : ControllerBase
    {
        private readonly IEnseignantService _enseignantService;
        private readonly IModuleService _moduleService;
        private readonly IGroupeService _groupeService;
        private readonly IMapper _mapper;

        public EnseignantController(IEnseignantService enseignantService,IMapper mapper,IModuleService moduleService,IGroupeService groupeService){
            _enseignantService= enseignantService;
            _mapper= mapper;
            _moduleService=moduleService;
            _groupeService=groupeService;
        }

        [HttpGet("api/Enseignant")]
        public async Task<IEnumerable<EnseignantInfoModel>> GetEnseignants(){
            var enseignants= await _enseignantService.GetEnseignantsAsync() ;
            return _mapper.Map<IEnumerable<EnseignantInfoModel>>(enseignants);
            //return etudiants.Select(_mapper.Map<EtudiantInfoModel>);
        }

        [HttpPut("api/Enseignant")]
        public async Task<IActionResult> PutEtudiant([FromBody]EnseignantInfoModel enseignant)
        {

            var _enseignant =_mapper.Map<UserUpdateModel>(enseignant);
           await _enseignantService.UpdateEnseignantAsync(_enseignant);
           return Ok();

            
        }


        [HttpGet("api/Enseignant/Module")]
        [Authorize(AuthenticationSchemes = "JwtBearer")]
        public async Task<IEnumerable<Module>> GetModule([FromQuery] string année_Universitaire,[FromQuery] int semestre)
        {   
            return await _moduleService.GetEnseignantModule(User.FindFirstValue("id"),semestre,année_Universitaire);
        }

        [HttpGet("api/Enseignant/Groupe")]
        [Authorize(AuthenticationSchemes = "JwtBearer")]
        public async Task<IEnumerable<Groupe>> GetGroupe([FromQuery] string année_Universitaire,[FromQuery] int semestre)
        {   
            return await _groupeService.GetEnseignantGroupe(User.FindFirstValue("id"),semestre,année_Universitaire);
        }

    }


}
