using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionLibrary.Interface;

namespace VisionLibrary.Module
{
    public class BaiduAnalyzeResult: IAnalyzeResult
    {
        public long log_id { get; set; }
        public List<Score> result { get; set; }

    }
}
