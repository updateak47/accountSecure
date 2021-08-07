using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows.Forms;

public class ApplicationConfig
{
    // Methods
    public static string LogFilename
    {
        get
        {
            string date = string.Format("{0}_{1}_{2}", DateTime.Now.Day.ToString("D2"), DateTime.Now.Month.ToString("D2"), DateTime.Now.Year.ToString());
            return string.Format(@"{0}\DebugLogs\__{1}.log", Application.StartupPath, date);
        }
    }
    public static int VideoSourceIndex
    {
        get
        {
            int cameraSourceIndex = 0;
            try
            {
                string cameraIndex = ConfigurationManager.AppSettings["cameraIndex"];
                int.TryParse(cameraIndex, out cameraSourceIndex);
                return cameraSourceIndex;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
  
    public static string ConnectionString 
    {
        get
        {
            string _connstring = @"";
            try
            {
                _connstring = ConfigurationManager.AppSettings["connString"];
            }
            catch (Exception) { }
            return _connstring;
        }
    }
    public static DebugLevel GetDebugLevel
    {
        get
        {
            string debuglevel = "";
            try
            {
                debuglevel = ConfigurationManager.AppSettings["debuglevel"];
                return debuglevel.Equals("0") ? DebugLevel.Normal : DebugLevel.Verbose;
            }
            catch (Exception) { return DebugLevel.Normal; }
        }
    }
    public static float Threshold
    {
        get
        {
            try
            {
                string thres = ConfigurationManager.AppSettings["threshold"].ToString();
                float threshold = 25;
                float.TryParse(thres, out threshold);
                return threshold;
            }
            catch (Exception)
            {
                return 50.0f;
            }
        }
    }
}
