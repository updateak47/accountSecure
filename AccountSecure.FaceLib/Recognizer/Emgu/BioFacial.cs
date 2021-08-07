using Emgu.CV;
using Emgu.CV.Structure;
using FaceRecognition;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AccountSecure.FaceLib
{
    public class BioFacial
    {
        private CascadeClassifier _cascadeClassifier = null;
        //private bool _hasRecognizedFace;
        private FaceRecognizerEngine _recognizerEngine;
        private readonly string _trainerDataPath = Application.StartupPath + "/traineddata/data.dat";

        public BioFacial()
        {
            //Train the recognizer here
            _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_default.xml");
            _recognizerEngine = new FaceRecognizerEngine( _trainerDataPath);
           
            //Application.Idle += new EventHandler(ProcessFrame);
        }
        public bool TrainData()
        {
            return new FaceRecognizerEngine(_trainerDataPath).TrainRecognizer();
        }
        public bool Verify(Image capturedface, out string message, Image savedface = null)
        {
            bool verified = false;
            try
            {
                message = "";
                var predictedUserId = _recognizerEngine.RecognizeUser(new Image<Gray, byte>(new Bitmap(capturedface)));
                if (predictedUserId == -1)
                    message = "This person is not recognized, Kindly register this face";
                else
                {
                    message = "Successfully matched";
                    verified = true;
                }
            }
            catch (Exception ex)
            {
                message = "Error: " + ex.Message;
            }
            return verified;
        }
    }
}
