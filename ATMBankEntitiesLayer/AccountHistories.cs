

namespace ATMBankEntitiesLayer
{
    public class AccountHistories
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string TransactionType { get; set; }

        public Guid CustomersId { get; set; }

        public virtual Customers Customers { get; set; }

        public bool Deleted { get; set; }
        public string CreatedBy { get; set; } = "Default";
        public string UpdatedBy { get; set; } = "Default";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
