using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvTemplateMatching.Entities
{
    public class GameDetectLocationCollection
    {
        public List<GameDetectLocation> DetectLocations { get; set; }
        public GameDetectLocationCollection() { }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(DetectLocations, Formatting.Indented);    
        }
    }
}
