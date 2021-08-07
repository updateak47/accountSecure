 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;


namespace Biometric.Devices
{
    /// <summary>
    /// Finger Print Devices Factory for Unity Framework 
    /// </summary>
    public class BiometricDeviceFactory
    {
        public static IBioDevice CreateDeviceInstance(BiometricDevices device)
        {
            //instantiate the device based on the one available 
            IUnityContainer FingerPrintContainer = new UnityContainer();
            //UnityConfigurationSection section = new UnityConfigurationSection();
            switch (device)
            {
                case BiometricDevices.CAMERA:
                    FingerPrintContainer.RegisterType(typeof(IBioDevice), typeof(CameraAforge));
                    break;
                case BiometricDevices.FINGERPRINT:
                    FingerPrintContainer.RegisterType(typeof(IBioDevice), typeof(FingerPrintDevice));
                    break;
                case BiometricDevices.IRIS:
                    FingerPrintContainer.RegisterType(typeof(IBioDevice), typeof(FingerPrintDevice));
                    break;
                default:
                    FingerPrintContainer.RegisterType(typeof(IBioDevice), typeof(FingerPrintDevice));
                    break;
            }
            return FingerPrintContainer.Resolve<IBioDevice>();
        }
    }
    /// <summary>
    /// Biometrics Device list
    /// </summary>
    public enum BiometricDevices : int
    {
        CAMERA = 0,
        FINGERPRINT = 1,
        IRIS = 2,
        SPEECH = 3
    }
}
