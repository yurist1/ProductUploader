using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResizeImage
{
    public partial class Form1 : Form
    {
        private delegate void SafeCallDelegate(string text);
        private FolderBrowserDialog fbd1;
        private FolderBrowserDialog fbd2;
        private List<string> files;
        public Form1()
        {
            InitializeComponent();
            fbd1 = new FolderBrowserDialog();
            fbd2 = new FolderBrowserDialog();
        }
        /// <summary>
        ///  사이즈 변경할 이미지가 있는 폴더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBringPath_Click(object sender, EventArgs e)
        {
            DialogResult result = fbd1.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd1.SelectedPath))
            {
                tbBringPath.Text = fbd1.SelectedPath;
                files = new List<string>();
                files.AddRange(Directory.GetFiles(fbd1.SelectedPath));

                //MessageBox.Show("Files found: " + files.Count().ToString(), "Message");
                SetLbProgress("0");
            }

        }
        /// <summary>
        /// 저장할 폴더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSavePath_Click(object sender, EventArgs e)
        {
            DialogResult result = fbd2.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd2.SelectedPath))
            {
                tbSavePath.Text = fbd2.SelectedPath;
            }





        }

        private Stream GetStream(Image image, ImageFormat format)
        {
            var stream = new System.IO.MemoryStream();
            image.Save(stream, format);
            stream.Position = 0;
            return stream;
        }

        private void ResizeImage(double scaleFactor, Stream sourcePath, string targetPath)
        {


            using (var image = Image.FromStream(sourcePath))
            {
                //scaleFactor = (image.Width * image.Height *image.c);
                var newWidth = (int)(image.Width * scaleFactor);
                var newHeight = (int)(image.Height * scaleFactor);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);

            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            Thread thread = new Thread(new ThreadStart(delegate () // thread 생성
            {

                //업로드
                StartResizing();
            }));
            thread.Start();

        }

        private void StartResizing()
        {
            for (int i = 0; i < files.Count(); i++)
            {
                var filePath = Image.FromFile(files[i]);
                //비율
                var info = new FileInfo(files[i]);
                var targetFile = files[i].Replace(tbBringPath.Text, tbSavePath.Text);
                if (info.Length > 5e+6)
                {
                    double ratio = 5e+6 / (double)info.Length;
                    ratio = Math.Sqrt(ratio) * 1.5;

                    var imagestream = GetStream(filePath, ImageFormat.Jpeg);

                    //Based on scalefactor image size will vary
                    ResizeImage(ratio, imagestream, targetFile);
                }
                else
                {
                    filePath.Save(targetFile);
                }


                SetLbProgress((i + 1).ToString());
            }
        }

        private void SetLbProgress(string progress)
        {
            if (lbProgress.InvokeRequired)
            {
                var d = new SafeCallDelegate(SetLbProgress);
                Invoke(d, new object[] { progress });
            }
            else
            {
                lbProgress.Text = $"{progress} / {files.Count()}";
            }

        }
    }
}
