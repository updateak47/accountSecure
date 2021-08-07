using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class LDateTime
{
    public static DateTime ToValidDateTime(string date)
    {
        try
        {
            DateTime myDate;
            myDate = ToValidateDateTime(date.Trim());
           //myDate = DateTime.ParseExact(_date.Trim(), new[] { "dd/MM/yyyy", "dd/MM/yyyy HH:mm", "dd/MM/yyyy HH:mm:ss", "MM/dd/yyyy HH:mm", "MM/dd/yyyy HH:mm:ss" }, CultureInfo.InvariantCulture);
                //DateTimeStyles.AssumeLocal|DateTimeStyles.AdjustToUniversal);
            return myDate;
        }
        catch (Exception)
        {
            return DateTime.Now;
        }
    }
    static readonly string[] formats =
    {
        "yyyyMMddHHmmsstt" , "yyyyMMddHHmmss" , "dd/MM/yyyy HH:mm", "dd/MM/yyyy HH:mm:ss", "MM/dd/yyyy HH:mm", "MM/dd/yyyy HH:mm:ss",
        "yyyyMMddHHmmtt"   , "yyyyMMddHHmm"   ,  "MM/dd/yyyy HH:mm:ss tt", "dd/MM/yyyy HH:mm:ss tt",
        "yyyyMMddHHK"     , "yyyyMMddHH"     ,   "M/dd/yyyy HH:mm:ss tt", "dd/M/yyyy HH:mm:ss tt",
        "yyyyMMddK"       , "yyyyMMdd"       , "M/dd/yyyy HH:mm:ss", "dd/M/yyyy HH:mm:ss",
        "yyyyMMK"         , "yyyyMM"         ,
        "yyyyK"           , "yyyy"           , "dd/MM/yyyy HH:mm"
    };
    public static DateTime ToValidateDateTime(string date)
    {
        try
        {
            //DateTime.ParseExact(input, _formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            DateTimeStyles options = DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal;
            DateTime value = DateTime.ParseExact(date, formats, CultureInfo.CurrentCulture, options);
            return value;
        }
        catch { return DateTime.Now; }
    }
    private static string FormatDate(string date)
    {
        if (!string.IsNullOrEmpty(date))
        {
            string[] dates = date.Split(new[] { '/', '-' });
            if (dates[2].Length < 4)
            {
                dates[2] = "20" + dates[2];
            }
            return string.Format("{0}/{1}/{2}", dates[0], dates[1], dates[2]);
        }
        else
        {
            Regex reg = new Regex(@"((?<Date>\d+[-|/|\\]\d+[-|/|\\]\d+)[ ]*(?<Time>\d+:\d+))");
            // Regex reg = new Regex(@"((?<Date>\d+[/|\\]\d+[/|\\]\d+)[ ]*)");
            Match match = reg.Match(date);
            while (match.Success)
            {
                if (match.Groups["Date"].Success)
                {
                    date = match.Groups["Date"].Captures[0].Value;
                    FormatDate(date);
                    break;
                }
                match.NextMatch();
            }
            return date;
        }
    }
    private string ReFormatDate(string date)
    {
        string[] dates = date.Split(new[] { '/', '-', '\\' });
        if (dates[2].Length < 4)
        {
            dates[2] = "20" + dates[2];
        }
        return string.Format("{0}/{1}/{2}", dates[1], dates[0], dates[2]);
    }
}
