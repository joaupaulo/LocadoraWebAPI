using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LocadoraWebAPI.Areas.Identity.Data;
using LocadoraWebAPI.Data;
using LocadoraWebAPI.Domain;
using LocadoraWebAPI.Service.AuthenticationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace LocadoraWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationcs : ControllerBase
    {
        private LocadoraWebAPIContext _dbContext;
        private readonly UserManager<LocadoraWebAPIUser> _userManager;
        private readonly SignInManager<LocadoraWebAPIUser> _signInManager;
        private readonly ILogger<UserAuthenticationcs> _logger;

        public UserAuthenticationcs(LocadoraWebAPIContext dbContext, UserManager<LocadoraWebAPIUser> userManager, SignInManager<LocadoraWebAPIUser> signInManager, ILogger<UserAuthenticationcs> logger)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<string> GetToken([FromBody] UserStore user)
        {
            try
            {
                var Resultuser = _dbContext.Users.FirstOrDefault(x => x.Email == user.Email);

                if (user != null)
                {
                    var signInResult = await _signInManager.CheckPasswordSignInAsync(Resultuser, user.Password, false);

                    if (signInResult.Succeeded)
                    {
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(Settings.Secret);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                            }),
                            Expires = DateTime.UtcNow.AddHours(2),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        return tokenHandler.WriteToken(token);
                    }
                }

                return "Invalid Code";
            }
            catch (Exception ex)
            {
                return ($"Error in aplication" + $"{ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserStore user)
        {
            try
            {
                LocadoraWebAPIUser locadoraWebApiUser = new LocadoraWebAPIUser()
                {
                    Email = user.Email,
                    UserName = user.Username,
                    EmailConfirmed = false
                };

                var result = await _userManager.CreateAsync(locadoraWebApiUser, user.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }

                return StatusCode(404);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"Error in aplication" + $"{ex.Message}");

                return StatusCode(500);
            }
        }
    }
}