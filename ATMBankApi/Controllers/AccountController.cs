using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ATMBankBusinessLayer;
using ATMBankApi.ControllerDtos;
using ATMBankBusinessLayer.Dtos;
using ATMBankDataLayer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ATMBankEntitiesLayer;

namespace ATMBankApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private CustomerOperations _customerOperations;
        private readonly IConfiguration _configuration;
        public AccountController(IConfiguration iConfig)
        {
            _customerOperations = new CustomerOperations();
            _configuration = iConfig; 
        }
        [Route("signIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody]AccountDto data)
        {

            Customers? currentCustomer = _customerOperations.GetByIdentityNumber((long)data.IdentityNumber);
            if (currentCustomer != null)
            {
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var key = Encoding.ASCII.GetBytes
                (_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, currentCustomer.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, currentCustomer.Name.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                    Expires = DateTime.UtcNow.AddMinutes(1),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                return Ok(stringToken);
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
