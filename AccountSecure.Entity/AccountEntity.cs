using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSecure.Entity
{
    public class AppUser
    {
        public AppUser()
        {
            this._CTransaction = new HashSet<CTransaction>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }
        public string Department { get; set; }
        public virtual ICollection<CTransaction> _CTransaction { get; set; }
    }
    public class AccountType
    {
        public AccountType()
        {
            this._Customers = new HashSet<Customers>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("acctTypeId")]
        public int AcctTypeId { get; set; }
        [DisplayName("acctTypeDesc")]
        public string AcctTypeDesc { get; set; }
        public virtual ICollection<Customers> _Customers { get; set; }
    }
    public class TransactionType
    {
        public TransactionType()
        {
            this._Ctransaction = new HashSet<CTransaction>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransTypeId { get; set; }
        public string TransDesc { get; set; }
        public virtual ICollection<CTransaction> _Ctransaction { get; set; }
    }
    public class Customers
    {
        public Customers()
        {
            this._Biometrics = new HashSet<Biometrics>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustId { get; set; }
        [ForeignKey("AccountType")]
        public int AcctTypeId { get; set; }
        //[Index("ix_acct_customers", 1, IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string AcctNo { get; private set; }
        [StringLength(200)]
        public string Fullname { get; set; }
        [DataType(DataType.Date)]
        public DateTime Dateofbirth { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Index("ix_uniqphone_cust", 1, IsUnique = true)]
        public string PhoneNo { get; set; }
        public string Sex { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        [Index("ix_uniqemail_cust", 1, IsUnique = true)]
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string OfficeAddress { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<Biometrics> _Biometrics { get; set; }
    }
    public class BiometricType
    {
        public BiometricType()
        {
            this._Biometrics = new HashSet<Biometrics>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BiometricTypeId { get; set; }
        [StringLength(30)]
        public string BioType { get; set; }
        public virtual ICollection<Biometrics> _Biometrics { get; set; }

    }
    public class Biometrics
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BiometricId { get; set; }
        [ForeignKey("BiometricType")]
        public int BiometricTypeId { get; set; }
        [ForeignKey("Customers")]
        public int CustId { get; set; }
        public byte[] BioImage { get; set; }
        public virtual Customers Customers { get; set; }
        public virtual BiometricType BiometricType { get; set; }
    }
    public class CTransaction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransId { get; set; }
        public string AcctNo { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("TransactionType")]
        public int TransTypeId { get; set; }
        public string TransRefNo { get; set; }
        public string Narration { get; set; }
        [DataType(DataType.Date)]
        public DateTime TransDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ValueDate { get; set; }
        [ForeignKey("AppUser")]
        public int UserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
    public class GLedger
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LedgerId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string AcctNo { get; set; }
        public string PostRef { get; set; }
        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime TransDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ValueDate { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[Column(TypeName = "decimal")]
        public decimal Balance { get; set; }
    }

}
