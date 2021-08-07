using AccountSecure.Interface;
using Biometric.Devices;
using Biometric.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountSecure.App
{
    public partial class FrmVerify : Form
    {
        IBioDevice device;
        int _custId;
        string _acctNo;
        byte[] capturedFingerBytes;
        byte[] _savedfinger;
        public FrmVerify(int custId, string accountNo, byte[] savedfinger)
        {
            InitializeComponent();
            Verified = false;
            _custId = custId;
            _acctNo = accountNo;
            _savedfinger = savedfinger;
           
        }
        public bool Verified { get; set; }
        public string ErrorMessage { get; set; }
        private void btnStart_fin_Click(object sender, EventArgs e)
        {
            device = BiometricDeviceFactory.CreateDeviceInstance(BiometricDevices.FINGERPRINT);
            device.OnDetected += device_OnDetected;
            device.OnErrorMessage += device_OnErrorMessage;
            lblStarted.Text = "Scanner Started";
            device.Start();
           
        }

        void device_OnErrorMessage(object sender, Biometric.Tasks.MessageEventArgs e)
        {
            string msg = e.exception == null ? e.message : e.exception.Message;
            MessageBox.Show(msg);
        }

        void device_OnDetected(object sender, Biometric.Tasks.BioEventArgs e)
        {
            capturedFingerBytes = null;
            if (e.CapturedImage != null)
            {
                pixFinger.Image = e.CapturedImage.Resize(pixFinger.Size.Width, pixFinger.Size.Height);
                //System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                //byte[] img = (byte[])converter.ConvertTo(image, typeof(byte[]));
                capturedFingerBytes = AccountSecure.Interface.ImageConverter.ToByteArray(pixFinger.Image);
            }
        }

        private void btnStop_fin_Click(object sender, EventArgs e)
        {
            lblStarted.Text = "Scanner Stopped";
            device.Stop();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            //spool data
            CBiometrics biometric = new CBiometrics
            {
                CustId = _custId, BiometricTypeId = 1
            };
            byte[] __savedfinger = biometric.SelectBytes();

            //verify the image 
            BioEventArgs args = new BioEventArgs { CustId = this._custId, AcctNo = _acctNo, fingerImageByte = capturedFingerBytes };
            string msg = "";

            Verified = Biometric.Tasks.FingerPrintTask.Verify(args, _savedfinger, out msg);
            ErrorMessage = msg;
            device.Stop();
         
        }

        private void FrmVerify_FormClosing(object sender, FormClosingEventArgs e)
        {
            TreeView treeView1;
            try
            {
                device.Stop();
                if (this.ParentForm != null)
                {
                    treeView1 = (TreeView)this.ParentForm.Controls["treeView1"];
                }
                else
                {
                    treeView1 = (TreeView)MasterForm.masterfrm.Controls["treeView1"];
                }
                treeView1.Nodes[0].Nodes.RemoveByKey("verify");
            }
            catch (Exception)
            {

            }
        }

        private void FrmVerify_Load(object sender, EventArgs e)
        {
            lblStarted.Text = "Scanner Stopped";
            if (File.Exists("FingerprintDB.dat"))
            {
                try
                {
                    File.Delete("FingerprintDB.dat");
                }
                catch (Exception) { }
            }
        }
    }
}
