using ATMBankBusinessLayer;
using ATMBankBusinessLayer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ATMBankApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DepositController : Controller
    {
        private DepositOperation _depositOperation;
        public DepositController()
        {
            _depositOperation = new DepositOperation();
        }
        [Route("deposit")]
        [HttpPost]
        public IActionResult DepositToAccount([FromBody]DepositDataDto data)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            data.CustomersId = Guid.Parse(userId);
            ReturnDataDtos result = _depositOperation.Deposit(data);
            return Ok(result);
        }
    }
}
