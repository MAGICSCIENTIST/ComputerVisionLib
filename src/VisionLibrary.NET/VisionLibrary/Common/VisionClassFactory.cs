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
        public static IComputerVision CreateVisionClass(VisionAPIType type)
        {
            IComputerVision res = null;
            switch (type)
            {
                case VisionAPIType.AzureVisionAnalyze: res = new AzureVisionAnalyze();break;
                case VisionAPIType.BaiduAnimalAnalyze: res = new BaiduVisionAnalyze();break;
            }

            return res;
        }
    }
}
