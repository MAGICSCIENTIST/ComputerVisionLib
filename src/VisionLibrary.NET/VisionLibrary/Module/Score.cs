using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionLibrary.Module
{
    public class Score
    {        
        public Location location { get; set; }
        public double score { get; set; }
        public string name { get; set; }
    }

    public class Location
    {
        public double height;        
        public int left { get; set; }
        public string top { get; set; }
        public string width { get; set; }
    }
}
