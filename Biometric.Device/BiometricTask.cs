using SourceAFIS.Simple;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace Biometric.Tasks
{
    public interface IBiometricTask
    {
        bool VerifyCustomer(BioEventArgs args, byte[] saved_db_image, out string msg);
    }
    public class BiometricTask : IBiometricTask
    {
        private static AfisEngine Afis;
        public bool VerifyCustomer(BioEventArgs arg_new, byte[] saved_db_image, out string out_msg)
        {
            out_msg = "";
            if (Afis == null)
                Afis = new AfisEngine();

            Afis.Threshold = ApplicationConfig.Threshold;   // Look up the probe using Threshold = 10

            List<BankCustomer> bio_database = new List<BankCustomer>();   // AddNewCustomer to a list

            //set the customer gotten from database 
            bio_database = SetGenuineCustomer(arg_new.CustId, arg_new.AcctNo, saved_db_image);

            //Add visitor with unknown identity as a probe
            BankCustomer probe = ProcessNewCustomer(arg_new, "captured_cust.png");
            BankCustomer match = Afis.Identify(probe, bio_database).FirstOrDefault() as BankCustomer;

            // Null result means that there is no candidate with similarity score above threshold
            if (match == null)
            {
                out_msg = string.Format("There is no match to validate the account [{0}] owner", arg_new.AcctNo);
                return false;
            }
            // Compute similarity score
            float score = Afis.Verify(probe, match);
            out_msg = string.Format("You are verified as the account [{0}] owner with a similarity score of = {1:F3}", match.AcctNo, score);
            return true;
        }
        private List<BankCustomer> SetGenuineCustomer(int custId, string acctNo, byte[] fingerprint)
        {
            List<BankCustomer> customers = new List<BankCustomer>();
            customers = new List<BankCustomer>{
                ProcessNewCustomer(new BioEventArgs { CustId = custId, AcctNo = acctNo, fingerImageByte = fingerprint}, "genunie_cust.png")
            };
            return customers;
        }
        /// <summary>
        /// Creates current customer with unique parameters
        /// </summary>
        /// <param name="args">Biometeric arguments - name, fingerimage and PAN</param>
        /// <returns>object of customer</returns>
        private BankCustomer ProcessNewCustomer(BioEventArgs args, string filename)
        {
            Afis = new AfisEngine();
            BankCustomer cust = new BankCustomer();
            try
            {
                cust.AcctNo = args.AcctNo;
                cust.CustId = args.CustId;

                args.FingerFilename = ImageConverter.ToImageFile(args.fingerImageByte, filename);

                //load image from image filename
                BitmapImage finger_image = new BitmapImage(new Uri(args.FingerFilename, UriKind.RelativeOrAbsolute));
                //Initialize finger object
                cust.Fingerprints.Add(
                    new CustomerFinger { Filename = args.FingerFilename, AsBitmapSource = finger_image,  }
                   //new CustomerFinger { AsImageData = args.fingerImageByte }
                 );
                // Execute extraction in order to initialize fp.Template
                Afis.Extract(cust);
                try
                {
                    finger_image = null;
                    //new FileInfo(args.FingerFilename).Delete();
                }
                catch { }
            }
            catch (Exception ex)
            {
                DebugLog.Write(ex);
            }
            return cust;
        }



    }

}
