using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionLibrary.Enum;
using VisionLibrary.Interface;
using VisionLibrary.VisionClass;

namespace VisionLibrary.Common
{
    public class VisionClassFactory
    {
        public static IComputerVision CreateVisionClass(VisionAPIType type, AnalyzeOptions opt)
        {
            IComputerVision res = null;
            switch (type)
            {
                case VisionAPIType.AzureVisionAnalyze: res = new AzureVisionAnalyze(opt); break;
                case VisionAPIType.BaiduAnimalAnalyze: res = new BaiduVisionAnalyze(opt); break;
                case VisionAPIType.BaiduEasyDL: res = new BaiduEazyDL(opt); break;
            }

            return res;
        }
    }

    public class AnalyzeOptions
    {
        private string key;
        private string skey;
        private string url;
        private double? threshold;

        public string Key { get => key; set => key = value; }
        public string Skey { get => skey; set => skey = value; }
        public string Url { get => url; set => url = value; }
        public double? Threshold { get => threshold; set => threshold = value; }
    }
}

