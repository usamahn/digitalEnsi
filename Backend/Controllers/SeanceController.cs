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
using System.IdentityModel.Tokens.Jwt;

namespace digitalEnsi.Controllers
{



    [ApiController]
    //[Route("api/[controller]")]

    public class SeanceController : ControllerBase
    {
        private readonly ISeanceService _seanceService;
        private readonly IMapper _mapper;


        public SeanceController(ISeanceService seanceService,IMapper mapper){
            _seanceService= seanceService;
            _mapper=mapper;
        }

        
        [HttpGet("api/Seances")]
        [Authorize(AuthenticationSchemes = "JwtBearer")]
        public async Task<ActionResult<IEnumerable<SeanceEmploiModel>>> GetSeances(){
            Console.WriteLine(User.IsInRole("Admin"));
            Console.WriteLine(User.IsInRole("Enseignant"));
            
            if(User.IsInRole("Enseignant")){
                var seances= await _seanceService.GetSeancesByIdEnseignant(User.FindFirstValue("id"));
                return _mapper.Map<IEnumerable<SeanceEmploiModel>>(seances).ToList();
                
            }
            if(User.IsInRole("Etudiant")){
                var seances= await _seanceService.GetSeancesByIdEtudiant(User.FindFirstValue("id"));
                return _mapper.Map<IEnumerable<SeanceEmploiModel>>(seances).ToList();
                
            }
            else return Ok();
            
            //var seances= await _seanceService.GetSeancesByGroupe(nomGroupe) ;
            //return  _mapper.Map<IEnumerable<SeanceEmploiModel>>(seances);
            //return etudiants.Select(_mapper.Map<EtudiantInfoModel>);
           
        }

        [HttpGet("api/Seances/Dates")]
        [Authorize(AuthenticationSchemes = "JwtBearer")]
        public async Task<ActionResult<IEnumerable<DateTime>>> GetDatesSeance([FromQuery]int groupeId, int moduleId){
            var res= await _seanceService.GetDatesSeanceByIdEnseignant(User.FindFirstValue("id"),groupeId,moduleId);
            return res;
        }
        [HttpGet("api/SeanceId")]
        [Authorize(AuthenticationSchemes = "JwtBearer")]
        public async Task<ActionResult<int>> GetDatesID([FromQuery]int groupeId, int moduleId){
            var res= await _seanceService.GetSeanceByIdEnseignant(User.FindFirstValue("id"),groupeId,moduleId);
            return res.SeanceId;
        }

        [HttpGet("api/Seances/{nomGroupe}")]
        public async Task<IEnumerable<SeanceEmploiModel>> GetSeancesByGroupe(string nomGroupe,[FromQuery] string année_Universitaire=null,[FromQuery]int semestre=0){
            var seances= await _seanceService.GetSeancesByGroupe(nomGroupe,année_Universitaire,semestre) ;
            return  _mapper.Map<IEnumerable<SeanceEmploiModel>>(seances);
            //return etudiants.Select(_mapper.Map<EtudiantInfoModel>);
        }

        [HttpPost("api/Seance")]
        public async Task<ActionResult<Seance>> PostSeance(Seance seance)
        {
            await _seanceService.AjouterSeance(seance);


            //a corriger :: remplacer par created at comme gropeController
            return Ok();
        }


    }

}