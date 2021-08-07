using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biometric.Devices
{
    public delegate void OnDetectHandler(object sender, Biometric.Tasks.BioEventArgs e);
    public delegate void OnErrorMessageHandler(object sender, Biometric.Tasks.MessageEventArgs e);
    public interface IBioDevice
    {
        bool Captured { get; set; }
        bool Validated { get; set; }
        void Start();
        void Stop();
        event OnDetectHandler OnDetected;
        event OnErrorMessageHandler OnErrorMessage;
    }
}
