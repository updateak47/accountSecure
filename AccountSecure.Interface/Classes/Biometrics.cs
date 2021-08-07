using AccountSecure.DataAccess;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountSecure.Entity;

namespace AccountSecure.Interface
{
    public class CBiometrics : Biometrics
    {
        public bool Add(BiometricTypeMode mode)
        {
            bool added = false;
            using (var context = new AccountSecureContext())
            {
                if (mode == BiometricTypeMode.Facial)
                    context.BiometricImages.Add(new Entity.Biometrics { BioImage = this.BioImage, BiometricTypeId = 1, CustId = this.CustId });
                else
                    context.BiometricImages.Add(new Entity.Biometrics { BioImage = this.BioImage, BiometricTypeId = 0, CustId = this.CustId });
                context.SaveChanges();
                added = true;
            }
            return added;
        }
        public byte[] SelectBytes()
        {
            using (var context = new AccountSecureContext())
            {
                byte[] bios;
                bios = context.BiometricImages.Where(x => x.CustId == this.CustId && x.BiometricTypeId == this.BiometricTypeId).FirstOrDefault().BioImage;
                return bios;
            }
        }
        public Image SelectImageByCustId()
        {
            using (var context = new AccountSecureContext())
            {
                byte[] bios;
                bios = context.BiometricImages.Where(x => x.CustId == this.CustId && x.BiometricTypeId == this.BiometricTypeId).FirstOrDefault().BioImage;
                return ImageConverter.ToImage(bios, 0, bios.Length);
            }
        }
        public List<Biometrics> SelectAll()
        {
            using (var context = new AccountSecureContext())
            {
                List<Biometrics> bios;
                bios = context.BiometricImages.Where(x => x.BiometricTypeId == this.BiometricTypeId).ToList(); 
                return bios;
            }
        }
        public List<Biometrics> SelectSingle()
        {
            using (var context = new AccountSecureContext())
            {
                List<Biometrics> bios;
                bios = context.BiometricImages.Where(x => x.CustId == this.CustId && x.BiometricTypeId == this.BiometricTypeId).ToList();
                return bios;
            }
        }
        public string SelectBioAsFileString(BiometricTypeMode mode)
        {
            using (var context = new AccountSecureContext())
            {
                string filename = "_cust_bio_finger.png";
                int typeId = 0; //finger
                if (mode == BiometricTypeMode.Facial)
                {
                    filename = "_cust_bio_facial.png";
                    typeId = 1; //facial
                }
                byte[] bios;
                bios = context.BiometricImages.Where(x => x.CustId == this.CustId && x.BiometricTypeId == typeId).FirstOrDefault().BioImage;
                
                //convert to a filepath
               return  ImageConverter.ToImageFile(bios, filename);

            }
        }
    }
}
