using AccountSecure.Interface;
using Biometric.Devices;
using Biometric.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using AccountSecure.FaceLib;

namespace AccountSecure.App
{
    public partial class FrmRecognize : Form
    {
        IBioDevice device;
        int _custId;
        string _acctNo;
        byte[] capturedFace;
        Image _savedFace;
        public FrmRecognize(int custId, string accountNo, Image savedface)
        {
            InitializeComponent();
            Verified = false;
            _custId = custId;
            _acctNo = accountNo;
            _savedFace = savedface;
            picSavedFace.Image = _savedFace.Resize(picSavedFace.Size.Width, picSavedFace.Size.Height); 
            //(Image)new System.Drawing.ImageConverter().ConvertTo(_savedFace, typeof(Image));
        }
        public bool Verified { get; set; }
        public string ErrorMessage { get; set; }
        private void btnStart_fin_Click(object sender, EventArgs e)
        {
            new Task(() =>
            {
                device = BiometricDeviceFactory.CreateDeviceInstance(BiometricDevices.CAMERA);
                device.OnDetected += device_OnDetected;
                device.OnErrorMessage += device_OnErrorMessage;
                device.Start();
            }
            ).Start();
        }
        void device_OnErrorMessage(object sender, Biometric.Tasks.MessageEventArgs e)
        {
            string msg = e.exception == null ? e.message : e.exception.Message;
            MessageBox.Show(msg);
        }
        void device_OnDetected(object sender, Biometric.Tasks.BioEventArgs e)
        {
            try
            {
                capturedFace = null;
                Image image = e.CapturedImage.Resize(picCapturedFace.Size.Width, picCapturedFace.Size.Height);
                if (image != null)
                {
                    picCapturedFace.Image = image;
                    //System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                    //byte[] img = (byte[])converter.ConvertTo(image, typeof(byte[]));
                }
            }
            catch (Exception) { }
            {
               
            }
        }
        private void btnStop_fin_Click(object sender, EventArgs e)
        {
            device.Stop();
            capturedFace = AccountSecure.Interface.ImageConverter.ToByteArray(picCapturedFace.Image);
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            BioFacial facial = new BioFacial();
            bool trained = facial.TrainData();
            if (trained)
            {
                string message = "";
                Verified = facial.Verify(picCapturedFace.Image, out message);
                ErrorMessage = message;
            }
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
        private void FrmRecognize_Load(object sender, EventArgs e)
        {

        }
    }
}
