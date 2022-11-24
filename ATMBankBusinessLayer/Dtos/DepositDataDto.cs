using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMBankBusinessLayer.Dtos
{
    public class DepositDataDto
    {
        public decimal AmountToBeDeposit { get; set; }
        public string CurrencyName { get; set; }
        public Guid CustomersId { get; set; }
    }
}
