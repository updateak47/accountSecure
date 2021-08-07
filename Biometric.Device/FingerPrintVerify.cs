using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SourceAFIS.Simple;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Biometric.Tasks
{
    public class FingerPrintTask
    {
        public static bool Verify(BioEventArgs bioArgs, byte[] savedImage, out string message)
        {
            message = "";
            IBiometricTask customer = new BiometricTask();
            return customer.VerifyCustomer(bioArgs, savedImage, out message);
        }
    }
    public class BioEventArgs : EventArgs
    {
        public string FingerFilename { get; set; }
        public int CustId { get; set; }
        public string AcctNo { get; set; }
        public Image CapturedImage { get; set; }
        public BiometricTypeMode BiometricType { get; set; }
        public byte[] fingerImageByte { get; set; }
    }
    public class MessageEventArgs : EventArgs
    {
        public Exception exception { get; set; }
        public string message { get; set; }
    }
    [Serializable]
    public class CustomerFinger : Fingerprint
    {
        public string Filename;
        public Image CapturedImage { get; set; }
    }
    [Serializable]
    public class BankCustomer : Person
    {
        public string AcctNo;
        public int CustId;
    }
    public enum BiometricTypeMode : int
    {
        Finger = 0,
        Facial = 1
    }
}
