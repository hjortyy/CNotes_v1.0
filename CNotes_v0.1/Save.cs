using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using LiteDB;

namespace CNotes_v0._1
{
    public partial class Save : Form
    {
        Bitmap bmp;
        public Save(Int32 x, Int32 y, Int32 w, Int32 h, Size s)
        {
            InitializeComponent();
            Rectangle rect = new Rectangle(x, y, w, h);
            bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, s, CopyPixelOperation.SourceCopy);
            bmp.Save(@".\temp.jpeg", ImageFormat.Jpeg);
            pbCapture.Image = bmp;
        }

        public class Screenshots
        {
            public int Id { get; set; }
            public string Hash { get; set; }
            public string Name { get; set; }
        }

        private MD5 md5 = MD5.Create();

        public static string BytesToString(byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes) result += b.ToString("x2");
            return result;
        }

        private byte[] GetHashMd5(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return md5.ComputeHash(stream);
            }
        }

        public static string screenNametopass = "";
        public static string screenDesttopass = "";
        public static int wassaved = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            wassaved = 1;
            int newname = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            screenNametopass = newname.ToString();
            string caseID = Cnotes.caseIDtopass;
            var destinationPath = @".\Screenshots\" + caseID;
            Directory.CreateDirectory(destinationPath);
            string destinationFile = Path.Combine(destinationPath, newname.ToString() + ".png");
            screenDesttopass = destinationFile;
            File.Copy(@".\temp.jpeg", destinationFile, true);
            string screenhash = BytesToString(GetHashMd5(Save.screenDesttopass));
            string screenname = Save.screenNametopass;
            using (var db = new LiteDatabase(@"password=CNotes2021;filename=.\database\Lite.db"))
            {
                var collection = db.GetCollection<Screenshots>("screenshots");
                var screenshot = new Screenshots
                {
                    Hash = screenhash,
                    Name = screenname
                };
                collection.Insert(screenshot);
                var query = collection
                    .Find(Query.EQ("Name", screenname))
                    .Select(x => x.Id).FirstOrDefault();
                Cnotes.screenID = query;
            }
            
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}