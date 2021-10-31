using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PhyndDemo_v2.Model;
using PhyndDemo_v2.Services;

namespace PhyndDemo_v2.Controllers
{

    [Route("authenticate")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserRepository _userRepository;

        public AuthController(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login user)
        {
            if(user !=null && user.Email !=null && user.Password !=null)
            {
                var login = await _userRepository.LoginUser(user.Email, user.Password);
                if(login != null)
                {
                    var role = _userRepository.GetUserRole(login.Id);
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("User",login.FirstName + " " + login.LastName),
                        new Claim("Id", login.Id.ToString()),
                        new Claim("Email",user.Email),
                        new Claim("HospitalId", login.UserHospitalId.ToString()),
                        new Claim("Role",role.ToString())
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
                    var signIn = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires:DateTime.Now.AddMinutes(30),
                        signingCredentials:signIn);
                    
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }

                else if(login == null){
                    return BadRequest ("Invalid");
                }
                
                else{
                    return BadRequest ("Invalid Credentials");
                }

            }
            else{
                return BadRequest("Invalid");
            }
        }
    }
}