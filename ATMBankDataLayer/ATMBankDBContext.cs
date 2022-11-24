using Microsoft.EntityFrameworkCore;
using ATMBankEntitiesLayer;


namespace ATMBankDataLayer
{
    public class ATMBankDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Port=5433;Database=ATMBankDB;UserName=postgres;Password=123456");
        }
        public DbSet<AccountHistories> AccountHistories { get; set; }
        public DbSet<BalanceAccounts> BalanceAccounts { get; set; }
        public DbSet<Currencies> Currencies { get; set; }
        public DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().HasData(
                 new Customers
                 {
                         Id = Guid.Parse("120276a7-bcb7-4f5d-965a-88df78d06d3b"),
                         Name = "Numan",
                         Surname = "Kul",
                         Pin = 1234,
                         IdentityNumber = 111222333444,
                         CreatedBy = "Default" ,
                         UpdatedBy = "Default" ,
                         Deleted = false
                 }
           );

            modelBuilder.Entity<Currencies>().HasData(
                 new Currencies
                 {
                     Id = Guid.Parse("d65f4d92-a79b-4a52-a05a-a4b96f72e7e1"),
                     CurrencyName = "USD",
                     AccountType = 3,
                     CreatedBy = "Default",
                     UpdatedBy = "Default",
                     Deleted = false
                 }
           );
            modelBuilder.Entity<Currencies>().HasData(
                 new Currencies
                 {
                     Id = Guid.Parse("71196b7a-a648-4e9f-bc51-c4235fb44696"),
                     CurrencyName = "EUR",
                     AccountType = 2,
                     CreatedBy = "Default",
                     UpdatedBy = "Default",
                     Deleted = false
                 }
           );
            modelBuilder.Entity<Currencies>().HasData(
                 new Currencies
                 {
                     Id = Guid.Parse("2627f7e3-b14c-4fa2-a342-2dc4b765f32f"),
                     CurrencyName = "TRY",
                     AccountType = 1,
                     CreatedBy = "Default",
                     UpdatedBy = "Default",
                     Deleted = false
                 }
           );


            modelBuilder.Entity<BalanceAccounts>().HasData(
                 new BalanceAccounts
                 {
                     Id = Guid.Parse("6f53285b-002f-4411-ad9c-b26d0a6b0ca5"),
                     CurrentBalance = 1500,
                     CurrenciesId = Guid.Parse("2627f7e3-b14c-4fa2-a342-2dc4b765f32f"),
                     CustomersId = Guid.Parse("120276a7-bcb7-4f5d-965a-88df78d06d3b"),
                     CreatedBy = "Default",
                     UpdatedBy = "Default",
                     Deleted = false
                 }
           );


            modelBuilder.Entity<BalanceAccounts>().HasData(
                 new BalanceAccounts
                 {
                     Id = Guid.Parse("7b6e9787-7218-4c41-8e46-468f316db478"),
                     CurrentBalance = 100,
                     CurrenciesId = Guid.Parse("d65f4d92-a79b-4a52-a05a-a4b96f72e7e1"),
                     CustomersId = Guid.Parse("120276a7-bcb7-4f5d-965a-88df78d06d3b"),
                     CreatedBy = "Default",
                     UpdatedBy = "Default",
                     Deleted = false
                 }
           );

        }

    }
}