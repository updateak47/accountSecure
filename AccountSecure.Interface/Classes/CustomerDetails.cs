using AccountSecure.DataAccess;
using AccountSecure.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSecure.Interface
{
    [DataObject(true)]
    public class CustomerDetails : Customers
    {
        public string AccType { get; set; }
        public byte[] FingerPrintBytes { get; set; }
        public byte[] FacialBytes { get; set; }
        public Image FingerPrintImage { get; set; }
        public Image FacialImage { get; set; }
        public new string AcctNo
        {
            get;
            set;
        }
        public CustomerDetails()
        {

        }
        public Customers Search()
        {
            if (!string.IsNullOrEmpty(this.AcctNo))
            {
                return SelectCustomerByAcctNo();
            }
            else if (!string.IsNullOrEmpty(this.PhoneNo))
            {
                return SelectCustomerByPhone();
            }
            else return SelectCustomerByName();

        }
        public bool Add()
        {
            bool added = false;
            int id = 0;
            using (var context = new AccountSecureContext())
            {
                Customers cust = new Customers
                {
                    Fullname = this.Fullname,
                    Dateofbirth = this.Dateofbirth,
                    Email = this.Email,
                    PhoneNo = this.PhoneNo,
                    Sex = this.Sex,
                    HomeAddress = this.HomeAddress,
                    OfficeAddress = this.OfficeAddress,
                    AcctTypeId = this.AcctTypeId + 1
                };
                id = context.CustomerDetails.Add(cust).CustId;
                //convert captured image from fingerprint 
                byte[] imgArray = ImageConverter.ToByteArray(this.FacialImage);
                context.BiometricImages.Add(new Biometrics { BioImage = imgArray, CustId = id, BiometricTypeId = 2 }); //facial
                imgArray = ImageConverter.ToByteArray(this.FingerPrintImage);
                int finger_bio_id = context.BiometricImages.Add(new Biometrics { BioImage = imgArray, CustId = id, BiometricTypeId = 1 }).BiometricId; //finger 
                context.SaveChanges();
                added = true;
            }
            return added;
        }
        public bool Update()
        {
            Customers cust;
            bool updated = false;
            using (var context = new AccountSecureContext())
            {
                cust = context.CustomerDetails.Where(s => s.CustId == this.CustId).AsEnumerable()
                             .FirstOrDefault<Customers>();
            }
            //updating in disconnected mode
            if (cust != null)
            {
                cust = new Customers
                {
                    CustId = this.CustId,
                    Fullname = this.Fullname,
                    Dateofbirth = this.Dateofbirth,
                    Email = this.Email,
                    PhoneNo = this.PhoneNo,
                    Sex = this.Sex,
                    HomeAddress = this.HomeAddress,
                    OfficeAddress = this.OfficeAddress,
                    AcctTypeId = this.AcctTypeId + 1
                };
                using (var context = new AccountSecureContext())
                {
                    context.CustomerDetails.Attach(cust);
                    context.Entry(cust).State = System.Data.Entity.EntityState.Modified;
                    //context.Entry(cust).Property(x => x.AcctTypeId).IsModified = false;   //account type shouldnt be modified
                    context.SaveChanges();
                    updated = true;
                }
            }
            return updated;
        }
        public bool Delete()
        {
            bool deleted = false;
            using (var context = new AccountSecureContext())
            {
                context.CustomerDetails.Remove(this);
                deleted = true;
            }
            return deleted;
        }
        public Customers SelectCustomerByAcctNo(string accountNo = null)
        {
            if (!string.IsNullOrEmpty(accountNo))
                this.AcctNo = accountNo;
            using (var context = new AccountSecureContext())
            {
                Customers user;
                user = (from cust in context.CustomerDetails
                        where cust.AcctNo == this.AcctNo
                        select cust).FirstOrDefault();
                return user;
            }
        }
        public Customers SelectCustomerByCustId(int custId = 0)
        {
            if (custId != 0)
                this.CustId = custId;
            using (var context = new AccountSecureContext())
            {
                Customers user;
                user = (from cust in context.CustomerDetails
                        where cust.CustId == this.CustId
                        select cust).FirstOrDefault();

                return user;
            }
        }
        public Customers SelectCustomerByPhone(string phone = null)
        {
            if (!string.IsNullOrEmpty(phone))
                this.PhoneNo = phone;
            using (var context = new AccountSecureContext())
            {
                Customers user;
                user = (from cust in context.CustomerDetails
                        where cust.PhoneNo == this.PhoneNo
                        select cust).FirstOrDefault();
                return user;

            }
        }
        public Customers SelectCustomerByName(string name = null)
        {
            if (!string.IsNullOrEmpty(name))
                this.Fullname = name;
            using (var context = new AccountSecureContext())
            {
                Customers user;
                user = (from cust in context.CustomerDetails
                        where cust.Fullname.ToLower().Contains(this.Fullname.ToLower())
                        select cust).FirstOrDefault();
                return user;
            }
        }
        public List<CustomerDetails> SelectAll()
        {
            using (var context = new AccountSecureContext())
            {
                var cust_detail = (from cust in context.CustomerDetails
                                   join accType in context.AccountTypes on cust.AcctTypeId equals accType.AcctTypeId
                                   join bio in context.BiometricImages on cust.CustId  equals bio.CustId
                                   where bio.BiometricTypeId == 2 //facial 
                                   select new
                                   {
                                       custId = cust.CustId,
                                       custName = cust.Fullname,
                                       acctNo = cust.AcctNo,
                                       acctType = accType.AcctTypeDesc,
                                       sex = cust.Sex,
                                       dateofBirth = cust.Dateofbirth,
                                       phoneNo = cust.PhoneNo,
                                       homeAddress = cust.HomeAddress,
                                       email = cust.Email,
                                       officeAddress = cust.OfficeAddress, 
                                       image = bio.BioImage 
                                   }
                                 ).AsEnumerable().Select(x => new CustomerDetails
                                 {
                                     CustId = x.custId,
                                     Fullname = x.custName,
                                     AcctNo = x.acctNo,
                                     AccType = x.acctType,
                                     Sex = x.sex,
                                     Dateofbirth = x.dateofBirth,
                                     PhoneNo = x.phoneNo,
                                     HomeAddress = x.homeAddress,
                                     Email = x.email,
                                     OfficeAddress = x.officeAddress,
                                     FacialImage = ImageConverter.ToImage(x.image)
                                 });
                ////set the biometrics
                //cust_detail.FingerPrintBytes = bioFinger;
                //cust_detail.FacialBytes = bioImage;
                return cust_detail.ToList();
            }
        }
        public CustomerDetails SelectFingerAndFacial()
        {
            using (var context = new AccountSecureContext())
            {
                var cust_detail = new CustomerDetails { CustId = this.CustId };

                //get fingerprint 
                var bioFinger = (from bio in context.BiometricImages
                                 join bioType in context.BiometricTypes on bio.BiometricTypeId equals bioType.BiometricTypeId
                                 where bioType.BioType.ToLower() == "finger" && bio.CustId == cust_detail.CustId
                                 select bio.BioImage).FirstOrDefault();

                //get facialImage 
                var bioImage = (from bio in context.BiometricImages
                                join bioType in context.BiometricTypes on bio.BiometricTypeId equals bioType.BiometricTypeId
                                where bioType.BioType.ToLower() == "facial" && bio.CustId == cust_detail.CustId
                                select bio.BioImage).FirstOrDefault();

                //set the biometrics
                cust_detail.FingerPrintBytes = bioFinger;
                cust_detail.FacialBytes = bioImage;
                return cust_detail;
            }
        }

        public IEnumerable<CustomerDetails> SelectByID()
        {
            using (var context = new AccountSecureContext())
            {
                var cust_detail = (from cust in context.CustomerDetails
                                   join accType in context.AccountTypes on cust.AcctTypeId equals accType.AcctTypeId
                                   join bio in context.BiometricImages on cust.CustId equals bio.CustId
                                   where cust.CustId == this.CustId && bio.BiometricTypeId == 2 //facial 
                                   select new
                                   {
                                       custId = cust.CustId,
                                       custName = cust.Fullname,
                                       acctNo = cust.AcctNo,
                                       acctType = accType.AcctTypeDesc,
                                       sex = cust.Sex,
                                       dateofBirth = cust.Dateofbirth,
                                       phoneNo = cust.PhoneNo,
                                       homeAddress = cust.HomeAddress,
                                       email = cust.Email,
                                       officeAddress = cust.OfficeAddress,
                                       image = bio.BioImage
                                   }
                                 ).AsEnumerable().Select(x => new CustomerDetails
                                 {
                                     CustId = x.custId,
                                     Fullname = x.custName,
                                     AcctNo = x.acctNo,
                                     AccType = x.acctType,
                                     Sex = x.sex,
                                     Dateofbirth = x.dateofBirth,
                                     PhoneNo = x.phoneNo,
                                     HomeAddress = x.homeAddress,
                                     Email = x.email,
                                     OfficeAddress = x.officeAddress,
                                     FacialImage = ImageConverter.ToImage(x.image)
                                 });
                ////set the biometrics
                //cust_detail.FingerPrintBytes = bioFinger;
                //cust_detail.FacialBytes = bioImage;
                return cust_detail.ToList();
            }
        }
    }
}
