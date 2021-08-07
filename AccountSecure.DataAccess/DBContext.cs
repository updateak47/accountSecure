using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountSecure.Entity;

namespace AccountSecure.DataAccess
{
    public class AccountSecureContext : DbContext, IDisposable
    {
        public string Connstring { get; set; }
        public DbSet<AppUser> ApplicationUsers {get; set;}
        public DbSet<Biometrics> BiometricImages { get; set; }
        public DbSet<Customers> CustomerDetails { get; set; }
        public DbSet<CTransaction> CTransactions { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<BiometricType> BiometricTypes { get; set; }
        public DbSet<GLedger> GLedgers { get; set; }


        public AccountSecureContext()
            : base("Name=ConnString")
        {
            Connstring = base.Database.Connection.ConnectionString;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AccountSecureContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new BiometricsMap());
            modelBuilder.Configurations.Add(new CustomersMap());
            modelBuilder.Configurations.Add(new AccountTypeMap());
            modelBuilder.Configurations.Add(new CTransactionMap());
            modelBuilder.Configurations.Add(new TransactionTypeMap());
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new BiometricTypeMap());
            modelBuilder.Configurations.Add(new GLedgerMap());
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

}
