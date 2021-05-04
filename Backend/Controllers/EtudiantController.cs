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

    public class EtudiantController : ControllerBase
    {

        private readonly IEtudiantService _etudiantService;
        private readonly IMapper _mapper;

        public EtudiantController(IEtudiantService etudiantService,IMapper mapper){
            _etudiantService= etudiantService;
            _mapper= mapper;
        }

        [HttpGet("api/Etudiants")]
        public async Task<IEnumerable<EtudiantInfoModel>> GetEtudiants(){
            var etudiants= await _etudiantService.GetEtudiantsAsync() ;
            return _mapper.Map<IEnumerable<EtudiantInfoModel>>(etudiants);
            //return etudiants.Select(_mapper.Map<EtudiantInfoModel>);
        }

        [HttpGet("api/Etudiant")]
        public async Task<EtudiantInfoModel> GetEtudiants([FromQuery]string cin){
            var etudiant= await _etudiantService.GetEtudiantByCinAsync(cin) ;
            return _mapper.Map<EtudiantInfoModel>(etudiant);
            
        }

        [HttpPut("api/Etudiants")]
        public async Task<IActionResult> PutEtudiant([FromBody]EtudiantInfoModel etudiant)
        {

            var _etudiant =_mapper.Map<UserUpdateModel>(etudiant);
           await _etudiantService.UpdateEtudiantAsync(_etudiant);
           return Ok();

            
        }
    }

}