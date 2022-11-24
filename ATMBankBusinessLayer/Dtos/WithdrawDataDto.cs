using ATMBankEntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMBankBusinessLayer.Dtos
{
    public class WithdrawDataDto
    {
        public decimal AmountToBeWithdrawn { get; set; }
        public string CurrencyName { get; set; }
        public Guid CustomersId { get; set; }
    }
}
