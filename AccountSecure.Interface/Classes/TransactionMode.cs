using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSecure.Interface
{
    public enum TransactionMode : int
    {
        CREDIT = 0,
        DEBIT = 1,
    }

    public class TransMode
    {
        public TransactionMode Get(string transType)
        {
            if (transType.ToLower() == "withdraw" || transType.ToLower() == "transfer")
                return TransactionMode.DEBIT;
            else return TransactionMode.CREDIT;
        }
        public TransactionMode Reverse(TransactionMode mode)
        {
            if (mode == TransactionMode.CREDIT)
                return TransactionMode.DEBIT;
            else return TransactionMode.CREDIT;
        }
    }

    public enum BiometricTypeMode : int
    {
        Finger = 0,
        Facial = 1
    }
    public class BankAccountNumbers
    {
        public static string CASH_ACOUNT = "0001001000";
        public static string TILL_ACCOUNT = "0001002000";
        public static string VAUL_ACCOUNT = "0001003000";
    }
}
