using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using digitalEnsi.Factories;
using digitalEnsi.Models;
using digitalEnsi.Models.DTO;
using AutoMapper;

namespace digitalEnsi.Controllers
{



    [ApiController]
    //[Route("api/[controller]")]

    public class AccountController : ControllerBase
    {
        private readonly UserManager<Etudiant> _etudiantManager;
        private readonly UserManager<Enseignant> _EnseignantManager;
        private readonly UserManager<Administrateur> _administrateurManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtFactory _jwtFactory;
        private readonly IMapper _mapper;

        public AccountController(UserManager<Etudiant> etudiantManager, UserManager<Enseignant> EnseignantManager,UserManager<Administrateur> administrateurManager,RoleManager<IdentityRole> roleManager,JwtFactory jwtFactory,IMapper mapper)
        {
            _etudiantManager = etudiantManager;
            _EnseignantManager=EnseignantManager;
            _administrateurManager = administrateurManager;
            _roleManager = roleManager;
            _jwtFactory = jwtFactory;
            _mapper= mapper;
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


            var result = await _etudiantManager.CreateAsync(userIdentity, model.Cin);
            

            if (!result.Succeeded) return new BadRequestObjectResult(result);

            //await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
            //await _appDbContext.SaveChangesAsync();

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


        [HttpPost("Enseignant/Register")]
        public async Task<IActionResult> RegisterEnseignant([FromBody]RegistrationModel model) //
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<Enseignant>(model);
            //Enseignant userIdentity=new Enseignant(){Email=model.Email,UserName=model.UserName,Nom=model.Nom, Prenom=model.Prenom};


            var result = await _EnseignantManager.CreateAsync(userIdentity, model.Cin);

            if (!result.Succeeded) return new BadRequestObjectResult(result);

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

    


