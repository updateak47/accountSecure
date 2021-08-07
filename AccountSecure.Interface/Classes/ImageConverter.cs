using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace AccountSecure.Interface
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

            string imagefile = Path.Combine(Application.StartupPath, filename);
            string fl = imagefile;
            if (File.Exists(fl)) File.Delete(imagefile);
            using (FileStream fs = new FileStream(fl, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fs.Write(_imByte, 0, _imByte.Length);
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
        public static Image ToImage(byte[] imgByte)
        {
            int offset = 0;
            int len = imgByte.Length;
            Image newImage;
            using (MemoryStream ms = new MemoryStream(imgByte, offset, len))
            {
                ms.Write(imgByte, offset, len);
                newImage = Image.FromStream((Stream)ms, true);
            }
            return newImage;
        }
        public static void ToFilename (byte[] bios, string filename)
        {
            using (FileStream fs = File.Create(filename))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(bios);
                }
                fs.Close();
            }
        }
        public static byte[] ToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
