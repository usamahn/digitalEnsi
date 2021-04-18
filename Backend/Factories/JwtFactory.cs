

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using digitalEnsi.Models;
using digitalEnsi.Models.Configuration;
using digitalEnsi.Models.DTO;

namespace digitalEnsi.Factories
{

    public class JwtFactory{
    readonly JwtSettings _settings ;
    

    public JwtFactory(JwtSettings jwtSettings){
        _settings = jwtSettings;
    }
    public async Task<string> BuildJwtTokenAsync<T>(IdentityUser applicationUser,UserManager<T> userManager)where T:ApplicationUser{
        SymmetricSecurityKey key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_settings.Key)
        );
        
        var roles = await userManager.GetRolesAsync((T)applicationUser);

        List<Claim> jwtClaims = new List<Claim>();
        jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Sub,applicationUser.UserName));
        jwtClaims.Add(new Claim("id",applicationUser.Id));
        jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()));
        foreach (var role in roles)
        {
            jwtClaims.Add(new Claim(ClaimTypes.Role,role));
            
        }
        
       

        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: jwtClaims,
            notBefore:DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(_settings.MinutesToExpiration),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
    public async Task<UserAuthResponse> BuildUserAuthObjectAsync<T>(IdentityUser user , UserManager<T> userManager)where T:ApplicationUser{
        UserAuthResponse userAuthResponse = new UserAuthResponse();
        userAuthResponse.username=user.UserName;
        userAuthResponse.role=await userManager.GetRolesAsync((T)user);
        userAuthResponse.expires=DateTime.UtcNow.AddMinutes(_settings.MinutesToExpiration);
        userAuthResponse.BearerToken = await BuildJwtTokenAsync(user,userManager);
        return userAuthResponse;
        
    }
 }

}