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

    public class EnseignantController : ControllerBase
    {
        private readonly IEnseignantService _enseignantService;
        private readonly IMapper _mapper;

        public EnseignantController(IEnseignantService enseignantService,IMapper mapper){
            _enseignantService= enseignantService;
            _mapper= mapper;
        }

        [HttpGet("api/Enseignant")]
        public async Task<IEnumerable<EnseignantInfoModel>> GetEtudiants(){
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

    }


}
