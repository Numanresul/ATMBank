

namespace ATMBankEntitiesLayer
{
    public class BalanceAccounts
    {
        public Guid Id { get; set; } = Guid.NewGuid();     
        public decimal CurrentBalance { get; set; }


        public Guid CurrenciesId { get; set; }
        public virtual Currencies Currencies { get; set; }

        public Guid CustomersId { get; set; }
        public virtual Customers Customers { get; set; }

        public bool Deleted { get; set; }
        public string CreatedBy { get; set; } = "Default";
        public string UpdatedBy { get; set; } = "Default";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
