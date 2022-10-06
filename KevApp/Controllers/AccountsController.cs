using KevApp.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KevApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController: ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly JwtOptions jwtOptions;

        public AccountsController(UserManager<IdentityUser> userManager, IOptions<JwtOptions> jwtOptions)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.jwtOptions = jwtOptions.Value ?? throw new ArgumentNullException(nameof(jwtOptions));
            Console.WriteLine(jwtOptions.Value.SecurityKeyToken);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterRequest register)
        {
            var user = new IdentityUser
            {
                Email = register.Email,
                UserName = register.Email,
                NormalizedUserName = register.Name
            };
            var result = await userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                return Ok(new
                {
                    Code = code,
                    Email = register.Email
                });
            }
            else
            {
                foreach( var error in result.Errors )
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string email, [FromQuery] string code)
        {
            if (code is null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            var user = await userManager.FindByEmailAsync(email);
            var codeEncoded = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            if ( user is null || code is null || user.EmailConfirmed)
            {
                return BadRequest();
            }

            if ((await userManager.ConfirmEmailAsync(user, codeEncoded)).Succeeded)
            {
                return Ok("Your email is confirmed!");
            }

            return BadRequest();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            // check if user exists with that email
            var user = await userManager.FindByEmailAsync(request.Email);
            if ( user is null)
            {
                return NotFound($"User with email {request.Email} not found!");
            }

            if (await userManager.CheckPasswordAsync(user, request.Password))
            {
                if (await userManager.IsEmailConfirmedAsync(user))
                {
                    var token = GenerateToken(user);
                    return Ok($"Bearer {token}");
                }
                
                return BadRequest("Email is not confirmed. Please go to your email account");
            }

            return Ok("Password is not valid");
        }

        private string GenerateToken(IdentityUser user)
        {
            IList<Claim> userClaims = new List<Claim>
            {
                new Claim("UserName", user.UserName),
                new Claim("Email", user.Email),
                new Claim("Name", user.NormalizedUserName)
            };

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: new SigningCredentials(jwtOptions.SecurityKeyToken, SecurityAlgorithms.HmacSha256),
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience
                ));
        }
    }
}
