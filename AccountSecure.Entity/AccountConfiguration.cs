using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSecure.Entity
{
    public class AppUserMap : EntityTypeConfiguration<AppUser>
    {
        public AppUserMap()
        {
            HasKey(x => x.UserId);
            Property(x => x.UserId).IsRequired();
          
        }
    }
    public class AccountTypeMap : EntityTypeConfiguration<AccountType>
    {
        public AccountTypeMap()
        {
           

        }

    }
    public class TransactionTypeMap : EntityTypeConfiguration<TransactionType>
    {
        public TransactionTypeMap()
        {

        }
    }
    public class CustomersMap : EntityTypeConfiguration<Customers>
    {
        public CustomersMap()
        {
            //Property(x => x.AcctNo).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("ix_cust_acct") { IsUnique = true }));
        }
    }
    public class BiometricTypeMap : EntityTypeConfiguration<BiometricType>
    {
        public BiometricTypeMap()
        {

        }
    }

    public class BiometricsMap : EntityTypeConfiguration<Biometrics>
    {
        public BiometricsMap()
        {
            HasKey(x => x.BiometricId).Property(x => x.BiometricId).IsRequired();
            HasRequired(x => x.Customers).WithMany(x => x._Biometrics).HasForeignKey(x => x.CustId);
        }
    }
    public class CTransactionMap : EntityTypeConfiguration<CTransaction>
    {
        public CTransactionMap()
        {

        }
    }
    public class GLedgerMap : EntityTypeConfiguration<GLedger>
    {
        public GLedgerMap()
        {

        }
    }

}
