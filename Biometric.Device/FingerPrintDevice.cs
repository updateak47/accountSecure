using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
//using System.Threading.Tasks;

using Neurotec.Biometrics;
using System.Threading;


namespace Biometric.Devices
{
    public class FingerPrintDevice : IBioDevice, IDisposable
    {
        Nffv engine = null;
        CancellationTokenSource ts = new CancellationTokenSource();
        string file;
        string file1;
        //Task<bool> _task;
        public FingerPrintDevice()
        {
            InitializeDevice();
            //CancellationToken ct = ts.Token;
            //Task.Factory.StartNew(() => InitializeDevice(), ct);

            //_task = new Task<bool>(() => InitializeDevice());
            //_task.Start();
            //_task.Wait();
        }

        private void InitializeDevice()
        {
            //bool done = false;
            try
            {
                //file = ManageDatFile();
                file = "FingerprintDB.dat";
                engine = new Nffv(file, "", "UareU");
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
                //done = true;
            }
            catch (Exception ex)
            {
                if (OnErrorMessage != null)
                    OnErrorMessage(this, new Tasks.MessageEventArgs { exception = ex, message = null });
                //done = false;
            }
            //return done;
        }

        void swap(ref string f, ref string f1)
        {
            string temp = f1;
            f1 = f;
            f = temp;
        }
        string ManageDatFile()
        {
            InitializeDatFile();
            if (File.Exists(file))
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception) { swap(ref file, ref file1); }
            }
            return file;
        }
        void InitializeDatFile()
        {
            file = "FingerprintDB.dat";
            file1 = "FingerprintDB1.dat";
        }
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
        public void Start()
        {
            Capture();
        }
        public void Stop()
        {
            try
            {
                if (engine != null)
                {
                    engine.Cancel();
                    engine.Dispose();
                    engine = null;
                }
            }
            catch (Exception ex)
            {
                if (OnErrorMessage != null)
                    OnErrorMessage(this, new Tasks.MessageEventArgs { exception = ex, message = null });
            }
        }
        internal class CapturedResult
        {
            public NffvStatus engineStatus;
            public NffvUser engineUser;
            public Exception exception;
        };
        private CapturedResult DoCapture()
        {
            CapturedResult captureResults = new CapturedResult();
            try
            {
                if (engine != null)
                    captureResults.engineUser = engine.Enroll(20000, out captureResults.engineStatus);
            }
            catch (Exception ex)
            {
                captureResults.exception = ex;
            }
            return captureResults;
        }
        private void Capture()
        {
            try
            {
                Task<CapturedResult> task = new Task<CapturedResult>(() => DoCapture());
                task.Start();
                task.Wait();

                CapturedResult captureResult = task.Result;
                if (captureResult.engineStatus == NffvStatus.TemplateCreated && captureResult.exception == null)
                {
                    NffvUser engineUser = captureResult.engineUser;
                    if (OnDetected != null)
                    {
                        OnDetected(this, new Tasks.BioEventArgs { CapturedImage = engineUser.GetBitmap(), BiometricType = Tasks.BiometricTypeMode.Finger });
                    }
                }
                else
                {
                    NffvStatus engineStatus = captureResult.engineStatus;
                    string msg = string.Format("Enrollment was not finished. Reason: {0}", engineStatus);
                    if (OnErrorMessage != null)
                        OnErrorMessage(this, new Tasks.MessageEventArgs { exception = captureResult.exception, message = msg });
                }
            }
            catch (Exception ex)
            {
                if (OnErrorMessage != null)
                    OnErrorMessage(this, new Tasks.MessageEventArgs { exception = ex, message = null });
            }
        }
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
        ~FingerPrintDevice()
        {
            Dispose(false);
            engine = null;
        }
        #endregion
    }
}
