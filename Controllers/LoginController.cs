using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PhyndDemo_v2.Helpers;
using PhyndDemo_v2.Model;
using PhyndDemo_v2.Services;

namespace PhyndDemo_v2.Controllers
{

    [Route("authenticate")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly Jwt _jwt;

        public LoginController(IConfiguration config, IUserRepository userRepository,IOptions<Jwt> jwt)
        {
            _config = config;
            _userRepository = userRepository;
            _jwt = jwt.Value;
        }

        [HttpPost]
        public IActionResult Login([FromBody] Login model)
        {
            var user = _userRepository.LoginUser(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwt.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.Id,
                Email = user.Email,
                Hospital = user.UserHospitalId,
                Token = tokenString
            });
        }
        
    }
}