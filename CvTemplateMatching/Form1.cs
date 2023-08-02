using CvTemplateMatching.Infrastructure.Helpers;
using CvTemplateMatching.Entities;
using CvTemplateMatching.Consts;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CvTemplateMatching
{
    public partial class Form1 : Form
    {
        EmguCvHelper emguHelper;
        string currentScreenshootPath;

        public Form1()
        {
            InitializeComponent();
            emguHelper = EmguCvHelper.GetInstance();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var gameNames = GameEntityLoader.LoadGame()
                .Select(t => t.GameName)
                .ToList();

            foreach (var gameName in gameNames)
            {
                this.cbGames.Items.Add(gameName);
            }
        }

        private void btnMatching_Click(object sender, EventArgs e)
        {

            //var soulKnight = Game.Where(x => x.GameName == "soul_knight").FirstOrDefault();
            //var animalMatching = Game.Where(x => x.GameName == "asphalt8").FirstOrDefault();

            if (string.IsNullOrEmpty(currentScreenshootPath))
            {
                this.lblResult.Text = "Please select the screenshoot before matching";
                return;
            }

            if (this.cbGames.SelectedItem == null)
            {
                this.lblResult.Text = "Please select the game for detecting";
                return;
            }

            //var screenshoot = Path.Combine(EnvironmentConsts.ProjectPath, "screenshoots", "6461e7d185e656b80ff75.jpg");

            GameDetectLocation detectResult = new();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            detectResult = emguHelper.DetectSpecificGame(currentScreenshootPath, this.cbGames.SelectedItem.ToString());

            stopwatch.Stop();
            this.lbTimeOccupancy.Text = stopwatch.Elapsed.ToString();
            stopwatch.Restart();

            if (detectResult.IsDetected == true)
            {
                this.lblResult.Text = $"Detected {detectResult.GameName}, X: {detectResult.X}, Y: {detectResult.Y}";
            }
            else
            {
                this.lblResult.Text = $"Could not detect {detectResult.GameName}";
            }

            this.lbTimeOccupancy.Text = stopwatch.Elapsed.ToString();
        }

        private void btnScreenshoot_Click(object sender, EventArgs e)
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
                this.lblScreenshootName.Text = fileDialog.SafeFileName;
            }

        }

        private void btnMatchingAll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentScreenshootPath))
            {
                this.lblResult.Text = "Please select the screenshoot before matching";
                return;
            }

            var emguHelper = EmguCvHelper.GetInstance();

            Stopwatch stopwatch = new();
            stopwatch.Start();

            var detecting = emguHelper.DetectGames(currentScreenshootPath);

            stopwatch.Stop();
            var elapseTiming = stopwatch.Elapsed;
            string resultAsJson = JsonConvert.SerializeObject(detecting);

            Form resultForm = new Form();
            TextBox tbResult = new TextBox();
            tbResult.Multiline = true;
            tbResult.WordWrap = true;
            tbResult.Text = resultAsJson;

            resultForm.Controls.Add(tbResult);

            resultForm.Show(this);

            this.lbTimeOccupancy.Text = elapseTiming.ToString();
        }
    }
}