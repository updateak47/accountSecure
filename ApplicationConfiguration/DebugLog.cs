using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class DebugLog
{
    static object log = new object();
    static Exception _ex;
    static string _mssg;
    public DebugLog()
    {
    }
    public DebugLog(Exception ex, string extra_message)
    {
        _ex = ex;
        _mssg = extra_message;
    }
    public static bool Write()
    {
        return Write(_ex, _mssg);
    }
    public static bool Write(Exception ex, string extra_message = null)
    {
        string msg = DebugLog.Exception(ex, ApplicationConfig.GetDebugLevel, extra_message);
        return DebugLog.Save(ApplicationConfig.LogFilename, DebugLog.Format(msg));
    }
    public static bool Save(string filename, string strObject, bool overwrite = false)
    {
        try
        {
            if (!Directory.Exists(new FileInfo(filename).DirectoryName)) Directory.CreateDirectory(new FileInfo(filename).DirectoryName);
            lock (log)
            {
                if (overwrite)
                    File.WriteAllText(filename, strObject);
                else File.AppendAllText(filename, strObject);
                return true;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
    public static string Read(string filename)
    {
        return File.ReadAllText(filename);
    }
    public static string Format(string msg)
    {
        return string.Format("[{0}]: {1}\r\n", DateTime.Now, msg.Trim(new[] { '\r', '\n' }));
    }

    /// <summary>
    /// It manages the exception 
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <param name="level">DebugLevel=Normal,Verbose</param>
    /// <returns></returns>
    public static string Exception(Exception ex, DebugLevel level, string extra_msg = null)
    {
        string _msg = "";
        if (ex != null)
        {
            if (level == DebugLevel.Normal)
                _msg = ex.Message;
            else _msg = ex.ToString();
            if (!string.IsNullOrEmpty(extra_msg))
                return string.Format("{0}::{1}", extra_msg, _msg);
            else return _msg;
        }
        else return extra_msg;

    }
}
public enum DebugLevel : int
{
    Normal = 0,
    Verbose = 1
}