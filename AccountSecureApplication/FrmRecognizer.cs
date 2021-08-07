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
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Cuda;
using FaceRecognition;
using FaceDetection;

namespace AccountSecure.App
{
    public partial class FrmRecognizer : Form
    {

        VideoCapture camera;
        private bool _captureInProgress;
        private Mat _frame;
        private Mat _grayFrame;
        private Mat _smallGrayFrame;
        private Mat _smoothedGrayFrame;
        private Mat _cannyFrame;

        int _custId;
        string _acctNo;
        Image _savedFace;
        public bool Verified { get; set; }
        public string ErrorMessage { get; set; }
        public FrmRecognizer(int custId, string accountNo, Image savedface)
        {
            InitializeComponent();

            btnDetect.Enabled = false;
            btnVerify.Enabled = false;
            CvInvoke.UseOpenCL = false;

            camera = new VideoCapture();
            camera.ImageGrabbed += Camera_ImageGrabbed;
            _frame = new Mat();
            _grayFrame = new Mat();
            _smallGrayFrame = new Mat();
            _smoothedGrayFrame = new Mat();
            _cannyFrame = new Mat();

            Verified = false;
            _custId = custId;
            _acctNo = accountNo;
            _savedFace = savedface;
        }
        private void Camera_ImageGrabbed(object sender, EventArgs e)
        {
            if (camera != null && camera.Ptr != IntPtr.Zero)
            {
                camera.Retrieve(_frame, 0);
                CvInvoke.CvtColor(_frame, _grayFrame, ColorConversion.Bgr2Gray);
                pictureBox1.Image = _frame.Bitmap.Resize(pictureBox1.Size.Width, pictureBox1.Size.Height);
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (camera != null)
            {
                if (_captureInProgress)
                {  //stop the capture
                    btnStart.Text = "Start";
                    camera.Pause();
                }
                else
                {
                    //start the capture
                    btnStart.Text = "Stop";
                    camera.Start();
                    btnDetect.Enabled = false;
                    btnVerify.Enabled = false;
                }
                _captureInProgress = !_captureInProgress;
            }
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            IImage image;
            //Read the files as an 8-bit Bgr image  
            image = new UMat("test.jpg", ImreadModes.Color); //UMat version
            //image = new Mat("ak1.jpg", ImreadModes.Color); //CPU version

            long detectionTime;
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();

            DetectFace.Detect(
              image, "haarcascade_frontalface_alt_tree.xml", "haarcascade_eye.xml",
              faces, eyes,
              out detectionTime); //haarcascade_frontalface_alt_tree; haarcascade_frontalface_default.xml

            foreach (Rectangle face in faces)
                CvInvoke.Rectangle(image, face, new Bgr(Color.Red).MCvScalar, 2);
            foreach (Rectangle eye in eyes)
                CvInvoke.Rectangle(image, eye, new Bgr(Color.Blue).MCvScalar, 2);

            //display the image 
            using (InputArray iaImage = image.GetInputArray())
            {
                pictureBox1.Image = image.Bitmap.Resize(pictureBox1.Size.Width, pictureBox1.Size.Height);
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            FaceRecognizerEngine recgn = new FaceRecognition.FaceRecognizerEngine("trained.dat");
            bool trained = recgn.TrainRecognizer();
            if (trained)
            {
                int predict = recgn.RecognizeUser(new Image<Gray, byte>(new Bitmap(pictureBox1.Image)));
                if (predict > -1)
                {
                    byte[] imageByte = recgn.GetImages().Find(x => x.BiometricId == predict).BioImage;
                    Image image = BioImage.ToImage(imageByte, 0, imageByte.Length);
                    //pictureBox2.Image = image.Resize(pictureBox2.Size.Width, pictureBox2.Size.Height);
                    Verified = true;
                }
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            camera.Stop();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Save("test.jpg");
                btnDetect.Enabled = true;
                btnVerify.Enabled = true;
            }

        }

        private void btnDone_Click(object sender, EventArgs e)
        {

        }
    }
}
