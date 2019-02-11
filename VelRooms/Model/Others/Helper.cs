using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HMS.Model.Others
{
    class Helper
    {
        public string Encoded_code { get; set; }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr handle);
        public static System.Windows.Media.Imaging.BitmapSource bs;
        public static IntPtr ip;
        public static BitmapSource LoadBitmap(System.Drawing.Bitmap source)
        {
            ip = source.GetHbitmap();
            bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip, IntPtr.Zero, System.Windows.Int32Rect.Empty,
            System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(ip);
            return bs;
        }
        public static void SaveImageCapture(BitmapSource bitmap,string File_path)
        {
            // Saving image to specified directory
            //string BasePath = "C:\\Users\\Swamy\\Documents\\Visual Studio 2012\\Projects\\CameraCapture\\CameraCapture\\Pictures\\";
            //string Filename = File_Name;
            string FilePath = File_path;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));
            encoder.QualityLevel = 100;
            FileStream fstream = new FileStream(FilePath, FileMode.Create);
            encoder.Save(fstream);
            fstream.Close();
        }
    }
}
