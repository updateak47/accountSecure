using AccountSecure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSecure.Interface
{
    public class Database
    {
        public static bool Set()
        {
            bool set = false;
            try
            {
                using (var context = new AccountSecureContext())
                {
                    //context.Database.CreateIfNotExists();
                    if (context.Database.Exists() != true)
                    {
                        context.Database.Create();
                        //add default values for BiometricType
                        List<Entity.BiometricType> bio_s = new List<Entity.BiometricType>();
                        bio_s.Add(new Entity.BiometricType { BioType = "FINGER" });
                        bio_s.Add(new Entity.BiometricType { BioType = "FACIAL" });
                        context.BiometricTypes.AddRange(bio_s);


                        context.TransactionTypes.AddRange(new[] {
                      new Entity.TransactionType { TransDesc = "WITHDRAW" },
                      new Entity.TransactionType { TransDesc = "DEPOSIT" },
                      new Entity.TransactionType { TransDesc = "TRANSFER" }}
                        );


                        context.AccountTypes.AddRange(new[] {
                      new Entity.AccountType { AcctTypeDesc= "Current" },
                      new Entity.AccountType { AcctTypeDesc = "Savings" },
                      new Entity.AccountType { AcctTypeDesc = "Fixed" }}
                        );

                        context.ApplicationUsers.Add(
                      new Entity.AppUser { Username = "Admin", Department = "Control", Password = "admin", Surname = "Administrator", Firstname = "Admin", Lastname = "Admin" }
                      );

                        context.SaveChanges();
                    }
                    set = true;
                }
            }
            catch (Exception ex)
            {
                set = false;
                string message = string.Format("Database creation and Initialization Error: ", ex.Message);
                throw new Exception(message);
            }
            return set;
        }
    }
}
