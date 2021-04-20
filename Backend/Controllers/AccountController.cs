using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using digitalEnsi.Factories;
using digitalEnsi.Models;
using digitalEnsi.Models.DTO;

namespace digitalEnsi.Controllers
{



    [ApiController]
    //[Route("api/[controller]")]

    public class AccountController : ControllerBase
    {
        private readonly UserManager<Etudiant> _etudiantManager;
        private readonly UserManager<Ensignant> _ensignantManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtFactory _jwtFactory;

        public AccountController(UserManager<Etudiant> etudiantManager, UserManager<Ensignant> ensignantManager,RoleManager<IdentityRole> roleManager,JwtFactory jwtFactory)
        {
            _etudiantManager = etudiantManager;
            _ensignantManager=ensignantManager;
            _roleManager = roleManager;
            _jwtFactory = jwtFactory;
        }

        [HttpPost("Etudiant/Register")]
        public async Task<IActionResult> RegisterEtudiant([FromBody]RegistrationModel model) //
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var userIdentity = _mapper.Map<AppUser>(model);
            Etudiant userIdentity=new Etudiant(){Email=model.Email,UserName=model.UserName,Nom=model.Nom, Prenom=model.Prenom};


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

            //var userIdentity = _mapper.Map<AppUser>(model);
            Ensignant userIdentity=new Ensignant(){Email=model.Email,UserName=model.UserName,Nom=model.Nom, Prenom=model.Prenom};


            var result = await _ensignantManager.CreateAsync(userIdentity, model.Cin);

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
            var userToVerify = await _ensignantManager.FindByNameAsync(credentials.UserName);
            if (userToVerify==null)
                userToVerify=await _ensignantManager.FindByEmailAsync(credentials.UserName);

            if (userToVerify == null) return Unauthorized();
            if (await _ensignantManager.CheckPasswordAsync(userToVerify, credentials.Password))
            {
                var jwt = await _jwtFactory.BuildUserAuthObjectAsync(userToVerify, _ensignantManager);
                return new OkObjectResult(jwt);
            }
            return Unauthorized();
        }

    }

}

    


