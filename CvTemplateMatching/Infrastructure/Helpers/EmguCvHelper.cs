using CvTemplateMatching.Consts;
using CvTemplateMatching.Entities;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvTemplateMatching.Infrastructure.Helpers
{
    public class EmguCvHelper
    {
        private static EmguCvHelper Instance;
        private static int fileIndex = 0;

        private string _saveResultPath => "Results";
        private string _workingProject => Environment.CurrentDirectory;
        private string _currentProjectPath => Directory.GetParent(_workingProject).Parent.Parent.FullName;

        private static List<GameMatrix> GameMatrixCollection = new List<GameMatrix>();

        public static EmguCvHelper GetInstance()
        {
            if (Instance == null)
            {
                LoadAllMatrixOfGameIcons();
                Instance = new EmguCvHelper();
            }

            return Instance;
        }
        

        public Image<Bgr, byte> LoadBgrImage(string path)
        {
            if (!FileResolver.IsFileExist(path))
            {
                return null;
            }

            var image = new Bitmap(System.Drawing.Image.FromFile(path))
                .ToImage<Bgr, byte>();
            return image;
        }

        public Image<Gray, byte> LoadGrayImage(string path)
        {
            if (!FileResolver.IsFileExist(path))
            {
                return null;
            }

            var image = new Bitmap(System.Drawing.Image.FromFile(path))
                .ToImage<Gray, byte>();
            return image;
        }

        public Image<Gray, byte> ConvertImageFromBgrToGrayFormat(Image<Bgr, byte> source)
        {
            Image<Gray, byte> grayImage = new Image<Gray, byte>(source.Width, source.Height);
            CvInvoke.CvtColor(source, grayImage, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

            return grayImage;
        }

        public GameDetectLocationCollection DetectGames(string screenshootPath)
        {
            GameDetectLocationCollection resultCollection = new();
            resultCollection.DetectLocations = new();

            foreach (var gameMat in GameMatrixCollection)
            {
                var detector = DetectGameLocation(screenshootPath, gameMat);
                if (detector.IsDetected == true)
                {
                    resultCollection.DetectLocations.Add(detector);
                }
            };

            return resultCollection;
        }

        public GameDetectLocation DetectSpecificGame(string screenshootPath, string gameName)
        {
            GameDetectLocation result = new();

            var gameDetected = GameMatrixCollection.Where(t => t.GameName.Equals(gameName)).FirstOrDefault();
            if (gameDetected != null)
            {
                result = DetectGameLocation(screenshootPath, gameDetected);

                return result;
            }

            return result;
        }

        //public GameDetectLocation DetectSpecificGame(string screenshootPath, string gameName)
        //{
        //    GameDetectLocation result = new();

        //    var files = Directory.GetFiles(Path.Combine(EnvironmentConsts.ProjectPath, "game_icons", "zen_life");


        //    //var gameDetected = GameMatrixCollection.Where(t => t.GameName.Equals(gameName)).FirstOrDefault();

        //    //if (gameDetected != null)
        //    //{
        //    //    result = DetectGameLocation(screenshootPath, gameDetected);

        //    //    return result;
        //    //}

        //    return result;
        //}

        public string ExtractTextFromImage(string imagePath)
        {
            // logic code
            Tesseract ocr = new Tesseract(
                @"E:\Workspace\CS2022\EmguCv\CvTemplateMatching\CvTemplateMatching\tessdata\",
                "eng",
                OcrEngineMode.TesseractOnly);
            ocr.PageSegMode = PageSegMode.SingleBlock;


            var image = CvInvoke.Imread(imagePath, Emgu.CV.CvEnum.ImreadModes.Grayscale);
            ocr.SetImage(image);

            string text = ocr.GetUTF8Text();

            return text;
        }


        private GameDetectLocation DetectGameLocation(string screenshootPath, GameMatrix game)
        {
            if(!FileResolver.IsFileExist(screenshootPath))
            {
                return new GameDetectLocation
                {
                    GameName = game.GameName,
                    IsDetected = false
                };
            }

            var source = CvInvoke.Imread(screenshootPath, ImreadModes.Unchanged);

            var heightRemain = Math.Abs(source.Height - 2220);
            var widthRemain = Math.Abs(source.Width - 1080);

            CvInvoke.Resize(source, source, new System.Drawing.Size(1080, 2220));
            var destination = game;
            var templateMask = new Mat();
            //CvInvoke.CvtColor(destination.GameMat, templateMask, ColorConversion.Bgr2Gray);

            Mat resultMat = new Mat();

            //Image<Gray, byte> srcGray = new Image<Gray, byte>(screenshootPath);
            //Image<Gray, float> srcSobel = srcGray.Sobel(0, 1, 3).Add(srcGray.Sobel(1, 0, 3)).AbsDiff(new Gray(0.0));

            //Image<Gray, byte> desGray = game.GameMat.ToImage<Gray, byte>();
            //Image<Gray, float> desSobel = desGray.Sobel(0, 1, 3).Add(desGray.Sobel(1, 0, 3)).AbsDiff(new Gray(0.0));


            CvInvoke.MatchTemplate(source, destination.GameMat, resultMat, TemplateMatchingType.CcoeffNormed);

            // get the best match position from the match result
            double minVal = 0.0;
            double maxVal = 0.0;
            System.Drawing.Point minLoc = new System.Drawing.Point();
            System.Drawing.Point maxLoc = new System.Drawing.Point();
            CvInvoke.MinMaxLoc(resultMat, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

            //Console.WriteLine($"Best match top left position {maxLoc}");
            //Console.WriteLine($"Best match confidence {maxVal}");

            double threshold = 0.7; // take threshold from 0.3 -> 0.2 (maybe get negative but a little)

            //minVal = (1 - minVal) * 100;

            if (maxVal > threshold)
            {
                //Console.WriteLine("Found needle");

                //var destinationWidth = destination.Width;
                //var destinationHeight = destination.Height;

                ////Point top_left = maxLoc;
                ////Point bottom_right = new Point(top_left.X + destinationWidth, top_left.Y + destinationHeight);

                System.Drawing.Rectangle r = new System.Drawing.Rectangle(maxLoc, destination.GameMat.Size);

                CvInvoke.Rectangle(source, r, new MCvScalar(255, 0, 0), 3);

                source.Save(Path.Combine(EnvironmentConsts.ProjectPath, _saveResultPath, $"myfile{fileIndex}.jpg"));
                //fileIndex++;

                return new GameDetectLocation()
                {
                    IsDetected = true,
                    GameName = game.GameName,
                    X = maxLoc.X + widthRemain,
                    Y = maxLoc.Y + heightRemain,
                };
            }

            return new GameDetectLocation
            {
                IsDetected = false,
                GameName = game.GameName
            };
        }

        private static void LoadAllMatrixOfGameIcons()
        {
            var games = GameEntityLoader.LoadGame();
            Mat gameMat = null;

            foreach (var game in games)
            {
                gameMat = CvInvoke.Imread(game.IconPath, ImreadModes.Unchanged);
                GameMatrixCollection.Add(new()
                {
                    GameName = game.GameName,
                    GameMat = gameMat
                });
            }
        }
    }
}
