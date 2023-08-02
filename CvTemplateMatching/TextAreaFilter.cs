using System;
using System.Drawing;

namespace TextDetection
{
    public class TextAreaFilter
    {
        public void Filter(System.Drawing.Rectangle rectangle, Action<System.Drawing.Rectangle> onFilterPassed)
        {
            if (rectangle.Width > rectangle.Height && 
                (float)(rectangle.Width/rectangle.Height)> 0.5f &&
                rectangle.Height>20)
                onFilterPassed(rectangle);
        }
    }
}
