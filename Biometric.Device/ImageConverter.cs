using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Biometric.Tasks
{
    public class ImageConverter
    {
        public static byte[] ToImageByte(string imagefile)
        {
            byte[] fileBytes = null;
            string fl = imagefile;
            using (FileStream fs = new FileStream(fl, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fileBytes = new byte[fs.Length];
                fs.Read(fileBytes, 0, fileBytes.Length);
                //fs.Flush();
                fs.Close();
            }
            GC.Collect();
            return fileBytes;
        }
        public static string ToImageFile(object imagebyte, string filename)
        {
            byte[] _imByte = (byte[])imagebyte;

            string imagefile = Path.Combine(Application.StartupPath, "BioImages" , string.Format(@"{0}", filename));
            if (!Directory.Exists(new FileInfo(imagefile).DirectoryName))
                Directory.CreateDirectory(new FileInfo(imagefile).DirectoryName);
            string fl = imagefile;
            if (File.Exists(fl)) File.Delete(imagefile);
            using (FileStream fs = new FileStream(fl, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fs.Write(_imByte, 0, _imByte.Length);
                fs.Flush();
                fs.Close();
            }
            return imagefile;
        }
        public static Image ToImage(byte[] imgByte, int offset, int len)
        {
            Image newImage;
            using (MemoryStream ms = new MemoryStream(imgByte, offset, len))
            {
                ms.Write(imgByte, offset, len);
                newImage = Image.FromStream((Stream)ms, true);
            }
            return newImage;
        }
    }
}
