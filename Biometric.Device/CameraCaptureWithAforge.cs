using System;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;
using Biometric.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge;

using SysDraw = System.Drawing;
using System.Threading.Tasks;

namespace Biometric.Devices
{
    /// <summary>
    /// Capturing images using Aforge.Net
    /// </summary>
    public class CameraAforge : IBioDevice, IDisposable
    {
        #region Fields
        private FilterInfoCollection CaptureDevice; // list of webcam
        private VideoCaptureDevice CamFrame;

        public static SysDraw.Bitmap img = null;
        public PictureBox imgVideo;
        public static string imagePath;
        public PictureBox PhotoPictureBox;
        int videoSourceIndex = ApplicationConfig.VideoSourceIndex;
        #endregion

        #region Constructor
        public CameraAforge()
        {
            imgVideo = new PictureBox();
            PhotoPictureBox = new PictureBox();
            this.PhotoPictureBox.Size = new System.Drawing.Size(206, 202);
            imgVideo.Width = PhotoPictureBox.Width = 206;
            imgVideo.Height = PhotoPictureBox.Height = 202;
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            CamFrame = new VideoCaptureDevice();
        }
        #endregion

        public bool Captured { get; set; }
        public bool Validated { get; set; }
        // Flag: Has Dispose already been called?
        bool disposed = false;
        /// <summary>
        /// Describes the validate event
        /// </summary>
        public event OnDetectHandler OnDetected;
        /// <summary>
        /// Event handler for handling error message 
        /// </summary>
        public event OnErrorMessageHandler OnErrorMessage;

        #region Camera Controllers
        #region Capture Event
        public void Start()
        {
            //--check which video source is selected---
            try
            {
                if (CamFrame == null) CamFrame = new VideoCaptureDevice();
                CamFrame = new VideoCaptureDevice(CaptureDevice[videoSourceIndex].MonikerString);  // Specified web cam and its filter moniker string
                CamFrame.NewFrame += new NewFrameEventHandler(CaptureImage);                       // captured event is fired, 
                //CamFrame.SnapshotFrame += CamFrame_SnapshotFrame;
                CamFrame.Start();
            }
            catch (Exception ex)
            {
                OnErrorMessage?.Invoke(this, new MessageEventArgs { exception = ex, message = null });
            }
        }
        public void SnapShot()
        {

        }
        public void Stop()
        {
            try
            {
                if (CamFrame == null) CamFrame = new VideoCaptureDevice();
                CamFrame.SignalToStop();
                Task task = new Task(() =>
                {
                    CamFrame.NewFrame -= new NewFrameEventHandler(CaptureImage); // as//sugested
                    CamFrame.WaitForStop();
                    //if (CamFrame.IsRunning == true)
                    //    CamFrame.Stop();
                });
                task.Start();
                task.Wait(400);
                CamFrame = null;
            }
            catch (Exception ex)
            {
                if (OnErrorMessage != null)
                    OnErrorMessage(this, new MessageEventArgs { exception = ex, message = "Error while stopping the camera." });
            }
        }
        #endregion
        /// <summary>
        /// Disconnects Video source using Windows API
        /// </summary>


        /// <summary>
        /// Captures Images from video source using Aforge
        /// </summary>
        private void CaptureImage(object sender, NewFrameEventArgs eventArgs)
        {
            Captured = false;
            try
            {
                imgVideo.Image = (SysDraw.Bitmap)eventArgs.Frame.Clone();
                if (imgVideo.Image != null)
                {
                    Captured = true;
                    OnDetected?.Invoke(this, new BioEventArgs { CapturedImage = imgVideo.Image, BiometricType = BiometricTypeMode.Facial });
                }
                else
                    Captured = false;
            }
            catch (Exception ex)
            {
                if (OnErrorMessage != null)
                    OnErrorMessage(this, new MessageEventArgs { exception = ex, message = "CaptureImage:: " });
            }
        }

        private void CamFrame_SnapshotFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Captured = false;
            try
            {
                imgVideo.Image = (SysDraw.Bitmap)eventArgs.Frame.Clone();
                if (imgVideo.Image != null)
                {
                    Captured = true;
                    OnDetected?.Invoke(this, new BioEventArgs { CapturedImage = imgVideo.Image, BiometricType = BiometricTypeMode.Facial });
                }
                else
                    Captured = false;
            }
            catch (Exception ex)
            {
                if (OnErrorMessage != null)
                    OnErrorMessage(this, new MessageEventArgs { exception = ex, message = "CaptureImage:: " });
            }
        }
        #endregion

        #region Dispose
        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                // Free any other managed objects here.

                //
            }
            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        ~CameraAforge()
        {
            Dispose(false);
        }
        #endregion
    }
}
