using CvTemplateMatching.Entities.Abstracts;

namespace CvTemplateMatching.Entities
{
    public class GameDetectLocation : IPosition
    {
        public bool IsDetected { get; set; } = false;
        public string GameName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
