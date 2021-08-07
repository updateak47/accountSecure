using System;
using System.Drawing;
using System.IO;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using AccountSecure.Interface;
using System.Collections.Generic;
using System.Windows.Forms;
using AccountSecure.Entity;

namespace FaceRecognition
{
    public class Faces
    {
        public int faceLabel { get; set; }
        public string name { get; set; }
        public Image image { get; set; }
    }
    public class FaceRecognizerEngine
    {
        private FaceRecognizer _faceRecognizer;
        private string _recognizerFilePath;
        public List<Biometrics> GetImages()
        {
            //get all the facial images
            CBiometrics biometric = new CBiometrics
            {
                BiometricTypeId = 2 //facial images
            };
            return biometric.SelectAll();
        }
        public FaceRecognizerEngine(string recognizerFilePath)
        {
            _recognizerFilePath = recognizerFilePath;
            _faceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
        }

        public bool TrainRecognizer()
        {
            var faces = GetImages();
            if (faces != null)
            {
                try
                {
                    var faceImages = new Image<Gray, byte>[faces.Count];
                    var faceLabels = new int[faces.Count];
                    for (int i = 0; i < faces.Count; i++)
                    {
                        Stream stream = new MemoryStream();
                        stream.Write(faces[i].BioImage, 0, faces[i].BioImage.Length);
                        var faceImage = new Image<Gray, byte>(new Bitmap(stream));
                        faceImages[i] = faceImage.Resize(100, 100, Inter.Cubic);
                        faceLabels[i] = faces[i].BiometricId;
                    }
                    _faceRecognizer.Train(faceImages, faceLabels);
                    _faceRecognizer.Save(_recognizerFilePath);
                    return true;
                }
                catch (Exception) { return false; }
            }
            return false;
        }
        public bool TrainSingleCust(int custId)
        {
            //get all the facial images
            CBiometrics biometric = new CBiometrics
            {
                BiometricTypeId = 2, //facial images
                CustId = custId
            };
            var faces = biometric.SelectSingle();
            if (faces != null)
            {
                var faceImages = new Image<Gray, byte>[faces.Count];
                var faceLabels = new int[faces.Count];
                for (int i = 0; i < faces.Count; i++)
                {
                    Stream stream = new MemoryStream();
                    stream.Write(faces[i].BioImage, 0, faces[i].BioImage.Length);
                    var faceImage = new Image<Gray, byte>(new Bitmap(stream));
                    faceImages[i] = faceImage.Resize(100, 100, Inter.Cubic);
                    faceLabels[i] = faces[i].CustId;
                }
                _faceRecognizer.Train(faceImages, faceLabels);
                _faceRecognizer.Save(_recognizerFilePath);
            }
            return true;
        }

        public void LoadRecognizerData()
        {
            _faceRecognizer.Load(_recognizerFilePath);
        }
        public int RecognizeUser(Image<Gray, byte> userImage)
        {
          /*  Stream stream = new MemoryStream();
            stream.Write(userImage, 0, userImage.Length);
            var faceImage = new Image<Gray, byte>(new Bitmap(stream));*/
            _faceRecognizer.Load(_recognizerFilePath);
            var result = _faceRecognizer.Predict(userImage.Resize(100, 100, Inter.Cubic));
            return result.Label;
        }
    }
}
