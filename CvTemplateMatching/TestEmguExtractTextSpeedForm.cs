using CvTemplateMatching.Consts;
using CvTemplateMatching.Infrastructure.Analyzers;
using CvTemplateMatching.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CvTemplateMatching
{
    public partial class TestEmguExtractTextSpeedForm : Form
    {
        private string _currentScreenshootPath { get; set; }
        public TestEmguExtractTextSpeedForm()
        {
            InitializeComponent();
        }

        private void btnImageSelected_Click(object sender, EventArgs e)
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
                _currentScreenshootPath = fileDialog.FileName;
                this.lblImageSelected.Text = fileDialog.SafeFileName;
            }
        }

        private void btnExtractText_Click(object sender, EventArgs e)
        {
            var analyzer = new EmguCvTextDetectionAnalyzer();

            var searchTexts = this.tbSearchText.Text;

            Thread extractTextThread = new Thread(() =>
            {
                analyzer.IsTextsDetected(_currentScreenshootPath, searchTexts);
            });
        }
    }
}
