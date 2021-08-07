using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSecure.Interface
{
    public class TransactionDetail : AccountSecure.Entity.CTransaction
    {
        public string TransDesc { get; set; }
        public string AcctTypeDesc { get; set; }
        public string CustFullname { get; set; }
        public decimal Balance { get; set; }
    }
}
