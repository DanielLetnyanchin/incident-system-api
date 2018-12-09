using IncidentSystem.API.TestModels;
using IncidentSystem.Interfaces;
using IncidentSystem.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IncidentSystem.API.Controllers
{
    [Route("Test")]
    public class TestController : Controller
    {
        private readonly IUserAccountService _userAccountService;

        public TestController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            return View();
        }
       
        
        [HttpGet("About")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View("About");
        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userAccountService.FindByUserNameAsync(model.UserName);

                if (user == null)
                {
                    user = new UserAccount
                    {
                        UserName = model.UserName
                    };

                    await _userAccountService.CreateAsync(user);
                }

                return View("Success");
            }

            return View();
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userAccountService.FindByUserNameAsync(model.UserName);

                if (user != null && await _userAccountService.GetPasswordAsync(user) == model.Password)
                {
                    var identity = new ClaimsIdentity("cookies");
                    identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                    await HttpContext.SignInAsync("cookies", new ClaimsPrincipal(identity));

                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Invalid UserName or Password");
            }

            return View();
        }

        [HttpPost("CreateToken")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateToken([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userAccountService.FindByUserNameAsync(model.UserName);
                if (user != null && await _userAccountService.GetPasswordAsync(user) == model.Password)
                {
                    // Token creation
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ValueFromConfigFile"));
                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        "IssuerFromConfigFile",
                        "AudienceFromConfigFile",
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

            return BadRequest();
        }
    }
}
