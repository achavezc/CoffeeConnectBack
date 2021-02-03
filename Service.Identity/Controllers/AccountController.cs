using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Auth;
using Core.Common.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Identity.Domain.Model;

namespace Service.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _configuration;
        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateUser command)
        {
            IActionResult response = Unauthorized();

            var user = await AuthenticateUser(command.Code, command.Password);

            if (user != null)
            {
                var tokenStr = await GenerateJSONWebToken(user);
                response = Ok(new { Token = tokenStr });
            }

            return response;
        }

        private async Task<User> AuthenticateUser(string code, string password)
        {
            if (code == "tdepotuser@tss.com.pe" && password == "NRaDRuNaPNcL8smUrmqh9aQD8AswQgY3QEHdLGW83pgLFQwFzufR")
                return new User (code, code);

            return null;
        }

        private async Task<string> GenerateJSONWebToken(User userinfo)
        {
            var jwtOptions = new JwtOptions();
            var section = _configuration.GetSection("jwt");
            section.Bind(jwtOptions);
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userinfo.Code),
                //new Claim(JwtRegisteredClaimNames.Email, userinfo.EmailAddress),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var token = new JwtSecurityToken(
                issuer: jwtOptions.Issuer, //"smesk.in",//_config["Jwt:Issuer"],
                audience: null,//"readers",//_config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(jwtOptions.ExpiryMinutes),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Identity Service. version: 1.19.12.15");
        }
    }
}