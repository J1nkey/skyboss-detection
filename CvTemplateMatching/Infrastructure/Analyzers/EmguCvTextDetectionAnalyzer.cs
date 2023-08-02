using CvTemplateMatching.Consts;
using CvTemplateMatching.Infrastructure.Helpers;
using Serilog;
using System.Diagnostics;

namespace CvTemplateMatching.Infrastructure.Analyzers
{
    public class EmguCvTextDetectionAnalyzer
    {
        private Stopwatch _stopwatch = new Stopwatch();
        private Serilog.Core.Logger _logger;
        private EmguCvHelper _emguHelper;

        public EmguCvTextDetectionAnalyzer()
        {
             _logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine($"{EnvironmentConsts.ProjectPath}", "Logs", "emgucv-text-detect-log-.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();
            _emguHelper = EmguCvHelper.GetInstance();
        }

        public bool IsTextDetected(string imagePath, string searchText)
        {
            _stopwatch.Start();

            // logic code
            var text = _emguHelper.ExtractTextFromImage(imagePath);

            _stopwatch.Stop();
            _stopwatch.Restart();

            if (text.Contains(searchText))
            {
                _logger.Information($"{searchText}-found-{_stopwatch.Elapsed}");
                return true;
            }
            else
            {
                _logger.Information($"{searchText}-not found-{_stopwatch.Elapsed}");
                return false;
            }
        }

        public void IsTextsDetected(string imagePath, string collectionText)
        {
            _logger.Information($"EmguCvTextDetectionAnalyzer - {nameof(IsTextsDetected)} - Progress");
            _stopwatch.Start();

            // logic code
            var text = _emguHelper.ExtractTextFromImage(imagePath);

            _stopwatch.Stop();
            _stopwatch.Restart();

            var searchTextCollection = collectionText.Split(" ");

            foreach (var searchText in searchTextCollection)
            {
                if (text.Contains(searchText))
                {
                    _logger.Information($"{searchText}-found-{_stopwatch.Elapsed}");
                }
                else
                {
                    _logger.Information($"{searchText}-not found-{_stopwatch.Elapsed}");
                }
            }
        }
    }
}
