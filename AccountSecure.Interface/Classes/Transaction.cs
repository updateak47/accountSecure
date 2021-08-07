using AccountSecure.DataAccess;
using AccountSecure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSecure.Interface
{
    public class Transaction : CTransaction
    {
        public Transaction()
        {

        }
        public static decimal GetGLBalance(string accountNo)
        {
            decimal _balance = 0;
            using (var context = new AccountSecureContext())
            {
                int count = context.GLedgers.Count(x => x.AcctNo == accountNo);
                if (count > 0)
                {
                    context.GLedgers.Where(x => x.AcctNo == accountNo).GroupBy(x => x.AcctNo).Select(n => new
                    {
                        balance = n.Sum(x => x.Credit) - n.Sum(x => x.Debit)
                    }).AsEnumerable().Select(n => _balance = n.balance);
                }
                return _balance;
            }
        }
        public static decimal GetGLBal(string acctNo)
        {
            decimal _balance = 0;
            using (var context = new AccountSecureContext())
            {
                int count = context.GLedgers.Count(x => x.AcctNo == acctNo);
                if (count > 0)
                {
                    _balance = context.GLedgers.Where(x => x.AcctNo == acctNo).ToList().LastOrDefault().Balance;
                }
                return _balance;
            }
        }
        public bool AddTransaction()
        {
            bool added = false;
            using (var context = new AccountSecureContext())
            {
                CTransaction trans = new CTransaction
                {
                    AcctNo = this.AcctNo,
                    Amount = this.Amount,
                    Narration = this.Narration,
                    TransTypeId = this.TransTypeId,
                    TransRefNo = this.TransRefNo,
                    TransDate = this.TransDate,
                    ValueDate = this.ValueDate,
                    UserId = this.UserId
                };
                context.CTransactions.Add(trans);
                context.SaveChanges();
                added = true;
            }
            return added;
        }
        public IEnumerable<GLedger> SelectGLedgerByAcctNo()
        {
            using (var context = new AccountSecureContext())
            {
                return context.GLedgers.Where(x => x.AcctNo == this.AcctNo).AsEnumerable().ToList();
            }
        }
        public IEnumerable<GLedger> SelectAllGLedger()
        {
            using (var context = new AccountSecureContext())
            {
                return context.GLedgers.AsEnumerable().ToList();
            }
        }
        public IEnumerable<GLedger> SelectGLedgerByRef()
        {
            using (var context = new AccountSecureContext())
            {
                return context.GLedgers.Where(x => x.PostRef == this.TransRefNo).AsEnumerable().ToList();
            }
        }
        public bool PostTransactionToGL(TransactionMode transMode)
        {
            bool posted = false;
            GLedger gLedger = new GLedger
                    {
                        AcctNo = this.AcctNo,
                        PostRef = this.TransRefNo,
                        TransDate = this.TransDate,
                        PostDate = DateTime.Today,
                        ValueDate = DateTime.Today
                    };
            if (transMode == TransactionMode.CREDIT)
            {
                gLedger.Credit = this.Amount;
                gLedger.Debit = 0;
            }
            else
            {
                gLedger.Debit = this.Amount;
                gLedger.Credit = 0;
            }
            using (var context = new AccountSecureContext())
            {
                decimal bal = 0;
                int count = context.GLedgers.Count(x => x.AcctNo == this.AcctNo);
                if (count > 0)
                    bal = context.GLedgers.Where(x => x.AcctNo == this.AcctNo).AsEnumerable().LastOrDefault().Balance;
                gLedger.Balance = gLedger.Credit - gLedger.Debit + bal;
                context.GLedgers.Add(
                    gLedger
                    );
                context.SaveChanges();
                posted = true;
            }
            return posted;
        }
        public IEnumerable<TransactionDetail> SelectTransactionByRefNum()
        {
            //TransactionDetail trx_detail = null;
            using (var context = new AccountSecureContext())
            {

                var trans_detail = (from trans in context.CTransactions
                                    join transType in context.TransactionTypes on trans.TransTypeId equals transType.TransTypeId
                                    join cust in context.CustomerDetails on trans.AcctNo equals cust.AcctNo
                                    join accType in context.AccountTypes on cust.AcctTypeId equals accType.AcctTypeId
                                    where trans.TransRefNo == this.TransRefNo
                                    //select cust).Take(1);
                                    select new
                                    {
                                        transId = trans.TransId,
                                        custName = cust.Fullname,
                                        acctNo = trans.AcctNo,
                                        acctype = accType.AcctTypeDesc,
                                        transType = transType.TransDesc,
                                        amount = trans.Amount,
                                        transRefNo = trans.TransRefNo,
                                        narration = trans.Narration,
                                        transDate = trans.TransDate,
                                        valueDate = trans.ValueDate
                                    })
                                   .AsEnumerable().Select(x => new TransactionDetail
                                   {
                                       TransId = x.transId,
                                       CustFullname = x.custName,
                                       AcctNo = x.acctNo,
                                       AcctTypeDesc = x.acctype,
                                       TransDesc = x.transType,
                                       Amount = x.amount,
                                       TransRefNo = x.transRefNo,
                                       Narration = x.narration,
                                       TransDate = x.transDate,
                                       ValueDate = x.valueDate
                                   }).ToList();
                return trans_detail;
            }
        }
        public IEnumerable<TransactionDetail> SelectTransactionsByAcctNo()
        {
            using (var context = new AccountSecureContext())
            {
                var count = context.CTransactions.Where(c => c.AcctNo == this.AcctNo).Count();
                if (count > 0)
                {
                    IEnumerable<TransactionDetail> trans_detail;

                    trans_detail = (from trans in context.CTransactions
                                    join transType in context.TransactionTypes on trans.TransTypeId equals transType.TransTypeId
                                    join cust in context.CustomerDetails on trans.AcctNo equals cust.AcctNo
                                    join accType in context.AccountTypes on cust.AcctTypeId equals accType.AcctTypeId
                                    where trans.AcctNo == this.AcctNo
                                    select new
                                    {
                                        transId = trans.TransId,
                                        custName = cust.Fullname,
                                        acctNo = trans.AcctNo,
                                        acctype = accType.AcctTypeDesc,
                                        transType = transType.TransDesc,
                                        amount = trans.Amount,
                                        transRefNo = trans.TransRefNo,
                                        narration = trans.Narration,
                                        transDate = trans.TransDate,
                                        valueDate = trans.ValueDate
                                    }).AsEnumerable().Select(x => new TransactionDetail
                                    {
                                        TransId = x.transId,
                                        CustFullname = x.custName,
                                        AcctNo = x.acctNo,
                                        AcctTypeDesc = x.acctype,
                                        TransDesc = x.transType,
                                        Amount = x.amount,
                                        TransRefNo = x.transRefNo,
                                        Narration = x.narration,
                                        TransDate = x.transDate,
                                        ValueDate = x.valueDate
                                    }).ToList();
                    return trans_detail;
                }
                else return null;
            }
        }
        public IEnumerable<TransactionDetail> SelectLastTen()
        {

            using (var context = new AccountSecureContext())
            {
                var count = context.CTransactions.Where(c => c.AcctNo == this.AcctNo).Count();
                if (count > 0)
                {
                    int skip = 0, n = 10;
                    if (count > n) skip = count - n;
                    IEnumerable<TransactionDetail> trans_detail;
                    trans_detail = (from trans in context.CTransactions
                                    join transType in context.TransactionTypes on trans.TransTypeId equals transType.TransTypeId
                                    join cust in context.CustomerDetails on trans.AcctNo equals cust.AcctNo
                                    join accType in context.AccountTypes on cust.AcctTypeId equals accType.AcctTypeId
                                    where trans.AcctNo == this.AcctNo
                                    select new
                                    {
                                        transId = trans.TransId,
                                        custName = cust.Fullname,
                                        acctNo = trans.AcctNo,
                                        acctype = accType.AcctTypeDesc,
                                        transType = transType.TransDesc,
                                        amount = trans.Amount,
                                        transRefNo = trans.TransRefNo,
                                        narration = trans.Narration,
                                        transDate = trans.TransDate,
                                        valueDate = trans.ValueDate
                                    }).AsEnumerable().Skip(skip).Select(x => new TransactionDetail
                                    {
                                        TransId = x.transId,
                                        CustFullname = x.custName,
                                        AcctNo = x.acctNo,
                                        AcctTypeDesc = x.acctype,
                                        TransDesc = x.transType,
                                        Amount = x.amount,
                                        TransRefNo = x.transRefNo,
                                        Narration = x.narration,
                                        TransDate = x.transDate,
                                        ValueDate = x.valueDate
                                    }).ToList();
                    return trans_detail;
                }
                else return null;
            }
        }
        public IEnumerable<TransactionDetail> SelectAllTransactions()
        {
            using (var context = new AccountSecureContext())
            {
                IEnumerable<TransactionDetail> trans_detail;

                trans_detail = (from trans in context.CTransactions
                                join transType in context.TransactionTypes on trans.TransTypeId equals transType.TransTypeId
                                join cust in context.CustomerDetails on trans.AcctNo equals cust.AcctNo
                                join accType in context.AccountTypes on cust.AcctTypeId equals accType.AcctTypeId
                                //where trans.AcctNo == this.AcctNo
                                select new
                                {
                                    transId = trans.TransId,
                                    custName = cust.Fullname,
                                    acctNo = trans.AcctNo,
                                    acctype = accType.AcctTypeDesc,
                                    transType = transType.TransDesc,
                                    amount = trans.Amount,
                                    transRefNo = trans.TransRefNo,
                                    narration = trans.Narration,
                                    transDate = trans.TransDate,
                                    valueDate = trans.ValueDate
                                }).AsEnumerable().Select(x => new TransactionDetail
                                {
                                    TransId = x.transId,
                                    CustFullname = x.custName,
                                    AcctNo = x.acctNo,
                                    AcctTypeDesc = x.acctype,
                                    TransDesc = x.transType,
                                    Amount = x.amount,
                                    TransRefNo = x.transRefNo,
                                    Narration = x.narration,
                                    TransDate = x.transDate,
                                    ValueDate = x.valueDate
                                }).ToList();
                return trans_detail;
            }
        }
    }
}
