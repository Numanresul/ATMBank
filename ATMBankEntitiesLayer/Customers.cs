

namespace ATMBankEntitiesLayer
{
    public class Customers
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }


        public ICollection<BalanceAccounts> BalanceAccounts { get; set; }
        public ICollection<AccountHistories> AccountHistories { get; set; }


        public long Pin { get; set; }
        public long IdentityNumber { get; set; }

        public bool Deleted { get; set; }
        public string CreatedBy { get; set; } = "Default";
        public string UpdatedBy { get; set; } = "Default";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
