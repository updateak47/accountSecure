namespace AccountSecure.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        AcctTypeId = c.Int(nullable: false, identity: true),
                        AcctTypeDesc = c.String(),
                    })
                .PrimaryKey(t => t.AcctTypeId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustId = c.Int(nullable: false, identity: true),
                        AcctTypeId = c.Int(nullable: false),
                        //AcctNo = c.String(maxLength: 50, unicode: false),
                        Fullname = c.String(maxLength: 200),
                        Dateofbirth = c.DateTime(nullable: false),
                        PhoneNo = c.String(maxLength: 50, unicode: false),
                        Sex = c.String(),
                        Email = c.String(maxLength: 200, unicode: false),
                        HomeAddress = c.String(),
                        OfficeAddress = c.String(),
                    })
                .PrimaryKey(t => t.CustId)
                .ForeignKey("dbo.AccountTypes", t => t.AcctTypeId, cascadeDelete: true)
                .Index(t => t.AcctTypeId)
                .Index(t => t.PhoneNo, unique: true, name: "ix_uniqphone_cust")
                .Index(t => t.Email, unique: true, name: "ix_uniqemail_cust");
            Sql("ALTER TABLE dbo.Customers ADD AcctNo AS RIGHT('000'+CAST(custId AS VARCHAR),4) + RIGHT('000'+CAST(acctTypeId AS VARCHAR),4) + '5001'");
            CreateTable(
                "dbo.Biometrics",
                c => new
                    {
                        BiometricId = c.Int(nullable: false, identity: true),
                        BiometricTypeId = c.Int(nullable: false),
                        CustId = c.Int(nullable: false),
                        BioImage = c.Binary(),
                    })
                .PrimaryKey(t => t.BiometricId)
                .ForeignKey("dbo.BiometricTypes", t => t.BiometricTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustId, cascadeDelete: true)
                .Index(t => t.BiometricTypeId)
                .Index(t => t.CustId);
            
            CreateTable(
                "dbo.BiometricTypes",
                c => new
                    {
                        BiometricTypeId = c.Int(nullable: false, identity: true),
                        BioType = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.BiometricTypeId);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Surname = c.String(),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Sex = c.String(),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.CTransactions",
                c => new
                    {
                        TransId = c.Int(nullable: false, identity: true),
                        AcctNo = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransTypeId = c.Int(nullable: false),
                        TransRefNo = c.String(),
                        Narration = c.String(),
                        TransDate = c.DateTime(nullable: false),
                        ValueDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransId)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.TransactionTypes", t => t.TransTypeId, cascadeDelete: true)
                .Index(t => t.TransTypeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        TransTypeId = c.Int(nullable: false, identity: true),
                        TransDesc = c.String(),
                    })
                .PrimaryKey(t => t.TransTypeId);
            
            CreateTable(
                "dbo.GLedgers",
                c => new
                    {
                        LedgerId = c.Int(nullable: false, identity: true),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AcctNo = c.String(),
                        PostRef = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        TransDate = c.DateTime(nullable: false),
                        ValueDate = c.DateTime(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LedgerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CTransactions", "TransTypeId", "dbo.TransactionTypes");
            DropForeignKey("dbo.CTransactions", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.Customers", "AcctTypeId", "dbo.AccountTypes");
            DropForeignKey("dbo.Biometrics", "CustId", "dbo.Customers");
            DropForeignKey("dbo.Biometrics", "BiometricTypeId", "dbo.BiometricTypes");
            DropIndex("dbo.CTransactions", new[] { "UserId" });
            DropIndex("dbo.CTransactions", new[] { "TransTypeId" });
            DropIndex("dbo.Biometrics", new[] { "CustId" });
            DropIndex("dbo.Biometrics", new[] { "BiometricTypeId" });
            DropIndex("dbo.Customers", "ix_uniqemail_cust");
            DropIndex("dbo.Customers", "ix_uniqphone_cust");
            DropIndex("dbo.Customers", new[] { "AcctTypeId" });
            DropTable("dbo.GLedgers");
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.CTransactions");
            DropTable("dbo.AppUsers");
            DropTable("dbo.BiometricTypes");
            DropTable("dbo.Biometrics");
            DropTable("dbo.Customers");
            DropTable("dbo.AccountTypes");
        }
    }
}
