

namespace ATMBankEntitiesLayer
{
    public class Currencies
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CurrencyName { get; set; }

        public ICollection<BalanceAccounts> BalanceAccounts { get; set; } 
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; } = "Default";
        public string UpdatedBy { get; set; } = "Default";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
