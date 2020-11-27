using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screenshot_Maker
{
    public class TickingTimer : System.Timers.Timer
    {
        private static string _path;

        public TickingTimer(double interval, string path)
            : base(interval)
        {
            _path = path;

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }

        public static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                {
                    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                     Screen.PrimaryScreen.Bounds.Y,
                                     0, 0,
                                     bmpScreenCapture.Size,
                                     CopyPixelOperation.SourceCopy);
                }
                var m = new MemoryStream();
                bmpScreenCapture.Save(m, ImageFormat.Jpeg);
                var img = Image.FromStream(m);
                img.Save(_path + "\\" + DateTime.Now.Month.ToString() + "." + DateTime.Now.Day.ToString() 
                    + " " + DateTime.Now.Hour.ToString() + ";" + DateTime.Now.Minute.ToString() + ".jpg");
                Form1.ticks++;
            }
        }
    }
}
