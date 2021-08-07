using AccountSecure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSecure.Interface
{
    public class BiometricTypeDefault : AccountSecure.Entity.BiometricType
    {
        public bool Add()
        {
            bool added = false;
            using (var context = new AccountSecureContext())
            {
                context.BiometricTypes.Add(new Entity.BiometricType { BioType = "FINGER" });
                context.BiometricTypes.Add(new Entity.BiometricType { BioType = "FACIAL" });
                context.SaveChanges();
                added = true;
            }
            return added;
        }
        public int SelectID(string type)
        {
            using (var context = new AccountSecureContext())
            {
               return context.BiometricTypes.Where(x => x.BioType == type).FirstOrDefault().BiometricTypeId;
            }
        }
        public IEnumerable<AccountSecure.Entity.BiometricType> SelectAll()
        {
            IEnumerable<AccountSecure.Entity.BiometricType> BioType = null;
            using (var context = new AccountSecureContext())
            {
                BioType = (from bType in context.BiometricTypes
                             select bType).ToList();
                return BioType;

                //var data = context.TransactionTypes.Select(p => p);
                //return data.ToList();
            }
            //return transType;
        }
    }
}
