using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;
using Biometric.Tasks;


namespace Biometric.Devices
{
    /// <summary>
    /// Capturing images using Windows API
    /// </summary>
    public class Camera : IBioDevice, IDisposable
    {
        #region Fields
        public static Bitmap img = null;
        public PictureBox imgVideo;
        public static string imagePath;
        public PictureBox PhotoPictureBox;
        int videoSourceIndex = ApplicationConfig.VideoSourceIndex;
        int hWnd;
        #endregion

        #region API Constants
        const int WM_CAP_START = 0x400;
        const int WS_CHILD = 0x40000000;
        const int WS_VISIBLE = 0x10000000;

        const int WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10;
        const int WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11;
        const int WM_CAP_EDIT_COPY = WM_CAP_START + 30;
        const int WM_CAP_SEQUENCE = WM_CAP_START + 62;
        const int WM_CAP_FILE_SAVEAS = WM_CAP_START + 23;

        const int WM_CAP_SET_SCALE = WM_CAP_START + 53;
        const int WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52;
        const int WM_CAP_SET_PREVIEW = WM_CAP_START + 50;

        const int SWP_NOMOVE = 0x2;
        const int SWP_NOSIZE = 1;
        const int SWP_NOZORDER = 0x4;
        const int HWND_BOTTOM = 1;

        #endregion

        #region API Declarations

        //[DllImport("avicap32.dll", EntryPoint = "capGetDriverDescriptionA")]
        //protected static extern bool capGetDriverDescriptionA(short wDriverIndex, string lpszName, int cbName, string lpszVer, int cbVer);


        [DllImport("avicap32.dll", EntryPoint = "capGetDriverDescriptionA")]
        protected static extern bool capGetDriverDescriptionA(short wDriverIndex, [MarshalAs(UnmanagedType.VBByRefStr)]ref String lpszName, int cbName, [MarshalAs(UnmanagedType.VBByRefStr)] ref String lpszVer, int cbVer);

        //[DllImport("user32", EntryPoint = "SendMessage")]
        //public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        //This function enables send the specified message to a window or windows
        [DllImport("user32", EntryPoint = "SendMessageA")]
        protected static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)] object lParam);

        ////This function enables create a  window child with so that you can display it in a picturebox for example
        //[DllImport("avicap32.dll")]
        //protected static extern int capCreateCaptureWindowA([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int nID);

        [DllImport("avicap32.dll", EntryPoint = "capCreateCaptureWindowA")]
        public static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int X, int Y, int nWidth, int nHeight, int hwndParent, int nID);

        [DllImport("user32", EntryPoint = "OpenClipboard")]
        public static extern int OpenClipboard(int hWnd);

        [DllImport("user32", EntryPoint = "EmptyClipboard")]
        public static extern int EmptyClipboard();

        [DllImport("user32", EntryPoint = "CloseClipboard")]
        public static extern int CloseClipboard();

        //This function enables set changes to the size, position, and Z order of a child window
        [DllImport("user32")]
        protected static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        //This function enable destroy the window child 
        [DllImport("user32")]
        protected static extern bool DestroyWindow(int hwnd);


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
        /// <summary>
        /// Disconnects Video source using Windows API
        /// </summary>
        public void Stop()
        {
            try
            {
                SendMessage(hWnd, WM_CAP_DRIVER_DISCONNECT, videoSourceIndex, 0);
                DestroyWindow(hWnd);
                imgVideo.Image = null;
            }
            catch (Exception ex)
            {
                if (OnErrorMessage != null)
                    OnErrorMessage(this, new MessageEventArgs { exception = ex, message = "Error while stopping the camera." });
            }
        }
        /// <summary>
        /// Captures Images from video source using Windows API
        /// </summary>
        private bool CaptureImage()
        {
            Captured = false;
            IDataObject data;
            Image bmap;
            try
            {
                //copy the image to the clipboard---
                SendMessage(hWnd, WM_CAP_EDIT_COPY, 0, 0);
                //SendMessage(hWnd, WM_CAP_SET_PREVIEW, 0, 0);
                //retrieve the image from clipboard and convert it to the bitmap format
                imgVideo.Image = Clipboard.GetImage();
                if (imgVideo.Image != null)
                {
                    data = Clipboard.GetDataObject();
                    if (data != null && data.GetDataPresent(typeof(System.Drawing.Bitmap)))
                    {
                        bmap = (Image)(data.GetData(typeof(System.Drawing.Bitmap)));
                        imgVideo.Image = bmap;
                        Captured = true;
                        
                        if (OnDetected != null)
                        {
                            if (imgVideo.Image != null)
                            {
                                //SaveImage(imgVideo.Image, filename);
                                OnDetected(this, new BioEventArgs { CapturedImage = imgVideo.Image, BiometricType = BiometricTypeMode.Facial });
                            }

                        }
                    }
                    Captured = false;
                }
                else
                    Captured = true;
                //StopCamera(camera_index);
            }
            catch (Exception ex)
            {
                if (OnErrorMessage != null)
                    OnErrorMessage(this, new MessageEventArgs { exception = ex, message = "CaptureImage:: " });
            }
            return Captured;
        }
        /// <summary>
        /// Starts and Previews video using Windows API 
        /// </summary>
        /// <param name="pbCtrl">PictureBox Control</param>
        private void StartCamera(PictureBox pbCtrl, out bool status, int camera_index = 0)
        {
            status = false;
            videoSourceIndex = camera_index;
            bool set = Thread.CurrentThread.TrySetApartmentState(ApartmentState.STA);
            if (set)
            {
                try
                {
                    Clipboard.Clear();
                }
                catch (Exception) { }
            }
            try
            {
                hWnd = capCreateCaptureWindowA("WebCam", WS_VISIBLE | WS_CHILD, 0, 0, 0, 0, pbCtrl.Handle.ToInt32(), 0);
                if (SendMessage(hWnd, WM_CAP_DRIVER_CONNECT, videoSourceIndex, 0) > 0)
                {
                    //-set the preview scale---
                    SendMessage(hWnd, WM_CAP_SET_SCALE, 1, 0);
                    //set the preview rate (ms)---
                    SendMessage(hWnd, WM_CAP_SET_PREVIEWRATE, 30, 0);
                    //start previewing the image---
                    SendMessage(hWnd, WM_CAP_SET_PREVIEW, 1, 0);
                    //resize window to fit in PictureBox control---
                    SetWindowPos(hWnd, HWND_BOTTOM, 0, 0, pbCtrl.Width, pbCtrl.Height, SWP_NOMOVE | SWP_NOZORDER);

                    status = true;
                    CaptureImage();
                }
                else
                {
                    //error connecting to video source---
                    DestroyWindow(hWnd);

                    status = false;
                    throw new Exception("StarCameraAvicap::Error connecting camera device using Windows API.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception (string.Format("StarCameraAvicap::Error connecting camera device::{0}.", ex.Message));
            }
        }

        #endregion

        #region Constructor
        public Camera()
        {
            imgVideo = new PictureBox();
            PhotoPictureBox = new PictureBox();
            this.PhotoPictureBox.Size = new System.Drawing.Size(206, 202);
            imgVideo.Width = PhotoPictureBox.Width = 206;
            imgVideo.Height = PhotoPictureBox.Height = 202;
        }
        #endregion

        #region Capture Event
        public void Start()
        {
            //--check which video source is selected---
            try
            {
                bool cam_status = false;
                StartCamera(imgVideo, out cam_status, videoSourceIndex);
                bool captured = CaptureImage();
                if (OnDetected != null)
                {
                    if (cam_status && imgVideo.Image != null && captured)
                    {
                        //SaveImage(imgVideo.Image, filename);
                        OnDetected(this, new BioEventArgs { CapturedImage = imgVideo.Image, BiometricType = BiometricTypeMode.Facial });
                    }
                    
                }
                Stop();
            }
            catch (Exception ex)
            {
                if (OnErrorMessage != null)
                    OnErrorMessage(this, new MessageEventArgs { exception = ex, message = null });
            }
        }
        #endregion

        #region SaveImage
        public void SaveImage(Image image, string filename)
        {
            try
            {
                if (image != null)
                    image.Save(filename, ImageFormat.Jpeg);
                image = null;
            }
            catch (Exception) { }
        }
        public void Save(Image image, string watermarkText, string filename)
        {
            Graphics gr = null;
            gr = Graphics.FromImage(image);

            Font font = new Font("Verdana", (float)8.5);
            Color color = Color.FromArgb(255, 255, 0);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Near;

            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //string file = filename.Substring(0, filename.Length - 4) + "_origal.jpg";
            //image.Save(file, ImageFormat.Jpeg);
            gr.DrawString(watermarkText, font, new SolidBrush(color), new Point(3, 3), stringFormat);
            image.Save(filename, ImageFormat.Jpeg);
            image = null;
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
        ~Camera()
        {
            Dispose(false);
        }
        #endregion
    }
}
