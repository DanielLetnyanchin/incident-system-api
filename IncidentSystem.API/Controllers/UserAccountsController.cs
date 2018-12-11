using IncidentSystem.Interfaces;
using IncidentSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IncidentSystem.API.Controllers
{
    [Route("api/useraccounts")]
    public class UserAccountsController : Controller
    {
        private IUserAccountService _userAccountService;
        private readonly IConfiguration _configuration;

        public UserAccountsController(IUserAccountService userAccountService,
                                        IConfiguration configuration)
        {
            _userAccountService = userAccountService;
            _configuration = configuration;
        }

        [HttpPost("CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userAccountService.GetByUserNameAsync(model.UserName);
                if (user != null && user.Password == model.Password)
                {
                    // Token creation
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        _configuration["Tokens:Issuer"],
                        _configuration["Tokens:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddHours(1),
                        signingCredentials: credentials
                        );

                    return Created("", new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
            }

            //return BadRequest();
            return Ok();
        }
    }
}
