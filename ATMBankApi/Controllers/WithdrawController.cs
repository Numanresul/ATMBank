using Microsoft.AspNetCore.Mvc;
using ATMBankBusinessLayer;
using ATMBankBusinessLayer.Dtos;
using System.Security.Claims;

namespace ATMBankApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WithdrawController : Controller
    {
        private WithdrawOperation _witdrawOperation;
        public WithdrawController() 
        {
            _witdrawOperation = new WithdrawOperation();
        }
        [Route("withdraw")]
        [HttpPost]
        public async  Task<IActionResult> WithdrawToAccount([FromBody]WithdrawDataDto data)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            data.CustomersId = Guid.Parse(userId);
            ReturnDataDtos result = _witdrawOperation.Withdraw(data);
            return Ok(result);
        }
    }
}
