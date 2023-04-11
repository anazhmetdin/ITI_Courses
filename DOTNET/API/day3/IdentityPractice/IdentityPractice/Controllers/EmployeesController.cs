using IdentityPractice.DTOs;
using IdentityPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Employee> _userManager;

        public EmployeesController(IConfiguration configuration,
            UserManager<Employee> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var employeeToAdd = new Employee
            {
                UserName = registerDto.username,
                Email = registerDto.email,
                HiringDate = registerDto.hiringdate
            };

            var result = await _userManager.CreateAsync(employeeToAdd, registerDto.password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            string role = "User";

            if (registerDto.adminSecret == _configuration.GetValue<string>("AdminSecret"))
                role = "Admin";

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, employeeToAdd.Id),
                new Claim(ClaimTypes.Role, role)
            };

            await _userManager.AddClaimsAsync(employeeToAdd, claims);

            return Ok(GetToken(claims));
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginDto credentials)
        {
            var user = await _userManager.FindByNameAsync(credentials.username);
            if (user == null)
            {
                return NotFound();
            }

            var isAuthenitcated = await _userManager.CheckPasswordAsync(user, credentials.password);
            if (!isAuthenitcated)
            {
                return Unauthorized();
            }

            var claimsList = await _userManager.GetClaimsAsync(user);

            return Ok(GetToken(claimsList));
        }

        [NonAction]
        private string GetToken(IEnumerable<Claim> claimsList)
        {
            var secretKeyString = _configuration.GetValue<string>("SecretKey") ?? string.Empty;
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
            var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

            //Combination SecretKey, HashingAlgorithm
            var siginingCreedentials = new SigningCredentials(secretKey,
                SecurityAlgorithms.HmacSha256Signature);

            var expiry = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(
                claims: claimsList,
                expires: expiry,
                signingCredentials: siginingCreedentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
