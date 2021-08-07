using AccountSecure.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSecure.Interface
{
    [DataObject(true)]
    public class TransactionTypeDefault : AccountSecure.Entity.TransactionType
    {
        public bool Add()
        {
            bool added = false;
            using (var context = new AccountSecureContext())
            {
                List<Entity.TransactionType> trans_type = new List<Entity.TransactionType>();
                trans_type.Add(new Entity.TransactionType { TransDesc = "WITHDRAW" });
                trans_type.Add(new Entity.TransactionType { TransDesc = "DESPOSIT" });
                trans_type.Add(new Entity.TransactionType { TransDesc = "TRANSFER" });
                context.TransactionTypes.AddRange(trans_type);
                added = true;
            }
            return added;
        }
        public int SelectID(string type)
        {
            using (var context = new AccountSecureContext())
            {
                return context.TransactionTypes.Where(x => x.TransDesc == type).FirstOrDefault().TransTypeId;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<AccountSecure.Entity.TransactionType> SelectAll()
        {
            IEnumerable<AccountSecure.Entity.TransactionType> transType = null;
            using (var context = new AccountSecureContext())
            {
                transType = (from tType in context.TransactionTypes
                             select tType).ToList();
                return transType;

                //var data = context.TransactionTypes.Select(p => p);
                //return data.ToList();
            }
            //return transType;
        }
    }
}
