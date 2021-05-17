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

    public class EtudiantController : ControllerBase
    {

        private readonly IEtudiantService _etudiantService;
        private readonly IMapper _mapper;

        public EtudiantController(IEtudiantService etudiantService,IMapper mapper){
            _etudiantService= etudiantService;
            _mapper= mapper;
        }


        [HttpGet("api/Etudiants/info")]
        [Authorize(AuthenticationSchemes = "JwtBearer",Roles = "Etudiant")]
        public async Task<EtudiantInfoModel> GetEtudiantInfo(){
            var etudiant = await _etudiantService.GetEtudiantAsync(User.FindFirstValue("id"));
            return _mapper.Map<EtudiantInfoModel>(etudiant);
        }

        

        [HttpGet("api/Etudiants")]
        public async Task<IEnumerable<EtudiantInfoModel>> GetEtudiants([FromQuery] string année_Universitaire,[FromQuery]int groupeId){
            IEnumerable<Etudiant> etudiants;
            if(groupeId!=0){
                if(String.IsNullOrWhiteSpace(année_Universitaire))
                    année_Universitaire=Utils.Utils.getAnnéeUniversitaireActuelle();
                etudiants= await _etudiantService.GetEtudiantsAsync(année_Universitaire,groupeId) ;
                return _mapper.Map<IEnumerable<EtudiantInfoModel>>(etudiants);
            }
            
            
            etudiants= await _etudiantService.GetEtudiantsAsync() ;
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