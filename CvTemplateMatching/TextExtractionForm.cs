using CvTemplateMatching.Consts;
using CvTemplateMatching.Infrastructure.Helpers;
using IronOcr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.OCR;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using IronSoftware.Drawing;


namespace CvTemplateMatching
{
    public partial class TextExtractionForm : Form
    {
        string currentScreenshootPath;
        Stopwatch stopwatch;
        public TextExtractionForm()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            stopwatch = new Stopwatch();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".jpeg";
            fileDialog.Filter = FileExtensionHelper
                .ConcatFilterExtension(
                    FileExtensionConsts.JPG,
                    FileExtensionConsts.JPEG,
                    FileExtensionConsts.PNG);

            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                currentScreenshootPath = fileDialog.FileName;

                var source = CvInvoke.Imread(currentScreenshootPath);
                Mat sourceResize = new Mat();

                //var source = Bitmap.FromFile(currentScreenshootPath)

                CvInvoke.Resize(source, sourceResize, pcbImage.Size);

                pcbImage.Image = sourceResize.ToBitmap();
                pcbImage.SizeMode = PictureBoxSizeMode.CenterImage;
            }

            //this.lblScreenshootName.Text = fileDialog.SafeFileName;
        }

        private void btnExtractText_Click(object sender, EventArgs e)
        {
            var ocr = new IronTesseract();

            using (var ocrInput = new OcrInput())
            {
                stopwatch.Start();
                ocrInput.AddImage(currentScreenshootPath);
                //ocrInput.AddPdf("document.pdf");

                // Optionally Apply Filters if needed:
                //ocrInput.Deskew();  // use only if image not straight
                // ocrInput.DeNoise(); // use only if image contains digital noise

                var ocrResult = ocr.Read(ocrInput);

                stopwatch.Stop();
                //Console.WriteLine(ocrResult.Text);
                this.tbResult.Text = ocrResult.Text;

                this.lblTimeOccupy.Text = stopwatch.Elapsed.ToString();
                stopwatch.Restart();
            }
        }

        private void btnEmguExtract_Click(object sender, EventArgs e)
        {
            Tesseract ocr = new Tesseract(
                @"E:\Workspace\CS2022\EmguCv\CvTemplateMatching\CvTemplateMatching\tessdata\",
                "eng",
                OcrEngineMode.TesseractOnly);
            ocr.PageSegMode = PageSegMode.SingleBlock;

            stopwatch.Start();

            var image = CvInvoke.Imread(currentScreenshootPath, Emgu.CV.CvEnum.ImreadModes.Grayscale);
            ocr.SetImage(image);

            string text = ocr.GetUTF8Text();
            stopwatch.Stop();

            this.tbResult.Text = text;
            this.lblTimeOccupy.Text = stopwatch.Elapsed.ToString();
            stopwatch.Restart();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            //String subfolderName = "tessdata";
            //String folderName = System.IO.Path.Combine(folder, subfolderName);
            String folderName = "E:\\Workspace\\CS2022\\EmguCv\\CvTemplateMatching\\CvTemplateMatching\\tessdata\\";
            var lang = "eng";
            if (!System.IO.Directory.Exists(folderName))
            {
                System.IO.Directory.CreateDirectory(folderName);
            }
            String dest = System.IO.Path.Combine(folderName, String.Format("{0}.traineddata", lang));
            if (!System.IO.File.Exists(dest))
                using (System.Net.WebClient webclient = new System.Net.WebClient())
                {
                    String source = Emgu.CV.OCR.Tesseract.GetLangFileUrl(lang);

                    Console.WriteLine(String.Format("Downloading file from '{0}' to '{1}'", source, dest));
                    webclient.DownloadFile(source, dest);
                    Console.WriteLine(String.Format("Download completed"));
                }
        }

        private void btnCheckGameState_Click(object sender, EventArgs e)
        {
            var ocr = new IronTesseract();

            using (var ocrInput = new OcrInput())
            {
                stopwatch.Start();
                //ocrInput.AddPdf("document.pdf");

                // Optionally Apply Filters if needed:
                //ocrInput.Deskew();  // use only if image not straight
                // ocrInput.DeNoise(); // use only if image contains digital noise

                // A 41% improvement on speed by specifiying a pixel region
                //var contentArea = new CropRectangle(x: 1671, y: 73, width: 751, height: 104);
                var contentArea = new System.Drawing.Rectangle(73, 1671, 104, 751);
                var img = System.Drawing.Image.FromFile(currentScreenshootPath);
                //var size = img.Size;
                //Bitmap tempBitmap = new Bitmap(img);
                //var tempImg = tempBitmap.Clone(contentArea, tempBitmap.PixelFormat);

                //this.pcbImage.Image = tempImg;
                ocrInput.AddImage(currentScreenshootPath);


                var ocrResult = ocr.Read(ocrInput);

                stopwatch.Stop();
                //Console.WriteLine(ocrResult.Text);
                this.tbResult.Text = ocrResult.Text;

                this.lblTimeOccupy.Text = stopwatch.Elapsed.ToString();
                stopwatch.Restart();
            }
        }
    }
}
