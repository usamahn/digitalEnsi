using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using digitalEnsi.Factories;
using digitalEnsi.Models;
using digitalEnsi.Models.DTO;
using AutoMapper;
using digitalEnsi.Services;

namespace digitalEnsi.Controllers
{



    [ApiController]
    //[Route("api/[controller]")]

    public class AccountController : ControllerBase
    {
        private readonly IEtudiantService _etudiantService;
        private readonly IEnseignantService _enseignantService;

        private readonly UserManager<Etudiant> _etudiantManager;
        private readonly UserManager<Enseignant> _EnseignantManager;
        private readonly UserManager<Administrateur> _administrateurManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtFactory _jwtFactory;
        private readonly IMapper _mapper;

        public AccountController(UserManager<Etudiant> etudiantManager, UserManager<Enseignant> EnseignantManager,UserManager<Administrateur> administrateurManager,
                                    RoleManager<IdentityRole> roleManager,JwtFactory jwtFactory,IMapper mapper , IEtudiantService etudiantService,
                                    IEnseignantService enseignantService)
        {
            _etudiantManager = etudiantManager;
            _EnseignantManager=EnseignantManager;
            _administrateurManager = administrateurManager;
            _roleManager = roleManager;
            _jwtFactory = jwtFactory;
            _mapper= mapper;
            _etudiantService= etudiantService;
            _enseignantService=enseignantService;
        }

        [HttpPost("api/Etudiants/Register")]
        public async Task<IActionResult> RegisterEtudiant([FromBody]RegistrationModel model) //
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(model.Password==null){
                model.Password=model.Cin;
            }
            var userIdentity = _mapper.Map<Etudiant>(model);
            //Etudiant userIdentity=new Etudiant(){Email=model.Email,UserName=model.UserName,Nom=model.Nom, Prenom=model.Prenom};


            var result = await _etudiantManager.CreateAsync(userIdentity, model.Password);
            

            if (!result.Succeeded) return new BadRequestObjectResult(result);
            var user=await _etudiantManager.FindByNameAsync(model.UserName);
            result = await _etudiantManager.AddToRoleAsync(user, "Etudiant");
            //await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
            //await _appDbContext.SaveChangesAsync();

            if (!result.Succeeded) return new BadRequestObjectResult(result);

            return new OkObjectResult("Account created");
        }

        [HttpPost("Etudiant/login")]
        public async Task<IActionResult> LoginEtudiant([FromBody]AuthenetificationModel credentials){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userToVerify = await _etudiantManager.FindByNameAsync(credentials.UserName);
            if (userToVerify==null)
                userToVerify=await _etudiantManager.FindByEmailAsync(credentials.UserName);

            if (userToVerify == null) return Unauthorized();
            if (await _etudiantManager.CheckPasswordAsync(userToVerify, credentials.Password))
            {
                var jwt =await  _jwtFactory.BuildUserAuthObjectAsync(userToVerify,_etudiantManager);
                return new OkObjectResult(jwt);
            }
            return Unauthorized();
        }




        [HttpDelete("api/Etudiant/{cin}")]
        public async Task<IActionResult> DeleteEtudiant(string cin)
        {
            var etudiant =await _etudiantService.GetEtudiantByCinAsync(cin);
            if(etudiant.Inscriptions==null|| etudiant.Inscriptions.Count==0){
                await _etudiantManager.DeleteAsync(etudiant);
                return Ok();
            }


            return NoContent();
        }




        [HttpPost("api/Enseignants/Register")]
        public async Task<IActionResult> RegisterEnseignant([FromBody]RegistrationModel model) //
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<Enseignant>(model);
            //Enseignant userIdentity=new Enseignant(){Email=model.Email,UserName=model.UserName,Nom=model.Nom, Prenom=model.Prenom};
            if(model.Password==null){
                model.Password=model.Cin;
            }

            var result = await _EnseignantManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(result);
            var user=await _EnseignantManager.FindByNameAsync(model.UserName);
            result = await _EnseignantManager.AddToRoleAsync(user, "Enseignant");
            

            //await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
            //await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }

        [HttpPost("Enseignant/login")]
        public async Task<IActionResult> LoginEnseignant([FromBody]AuthenetificationModel credentials){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userToVerify = await _EnseignantManager.FindByNameAsync(credentials.UserName);
            if (userToVerify==null)
                userToVerify=await _EnseignantManager.FindByEmailAsync(credentials.UserName);

            if (userToVerify == null) return Unauthorized();
            if (await _EnseignantManager.CheckPasswordAsync(userToVerify, credentials.Password))
            {
                var jwt = await _jwtFactory.BuildUserAuthObjectAsync(userToVerify, _EnseignantManager);
                return new OkObjectResult(jwt);
            }
            return Unauthorized();
        }

        [HttpDelete("api/Enseignant/{cin}")]
        public async Task<IActionResult> DeleteEnseignant(string cin)
        {
            
            var enseignant =await _enseignantService.GetEnseignantByCinAsync(cin);
            if(enseignant.Seances==null || enseignant.Seances.Count==0){
                await _EnseignantManager.DeleteAsync(enseignant);
                
                return Ok();
            }


            return NoContent();
        }




        [HttpPost("Admin/login")]
        public async Task<IActionResult> LoginAdmin([FromBody]AuthenetificationModel credentials){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userToVerify = await _administrateurManager.FindByNameAsync(credentials.UserName);
            if (userToVerify==null)
                userToVerify=await _administrateurManager.FindByEmailAsync(credentials.UserName);

            if (userToVerify == null) return Unauthorized();
            if (await _administrateurManager.CheckPasswordAsync(userToVerify, credentials.Password))
            {
                var jwt = await _jwtFactory.BuildUserAuthObjectAsync(userToVerify, _administrateurManager);
                return new OkObjectResult(jwt);
            }
            return Unauthorized();
        }

    }

}

    


