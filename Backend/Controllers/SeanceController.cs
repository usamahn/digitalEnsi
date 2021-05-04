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

    public class SeanceController : ControllerBase
    {
        private readonly ISeanceService _seanceService;
        private readonly IMapper _mapper;


        public SeanceController(ISeanceService seanceService,IMapper mapper){
            _seanceService= seanceService;
            _mapper=mapper;
        }


        [HttpGet("api/Seances/{nomGroupe}")]
        public async Task<IEnumerable<SeanceEmploiModel>> GetSeances(string nomGroupe){
            var seances= await _seanceService.GetSeancesByGroupe(nomGroupe) ;
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