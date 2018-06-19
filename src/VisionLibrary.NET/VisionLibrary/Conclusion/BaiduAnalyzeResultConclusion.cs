using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision.Contract;
using VisionLibrary.Module;

namespace VisionLibrary.Conclusion
{
    public static class BaiduAnalyzeResultConclusion
    {        
        public static bool IsAnimal(this BaiduAnalyzeResult data,double minConfidence=0.4)
        {
            var res=false;
            if (data.result!=null)
            {
                res = data.result.Any(x => x.score >= minConfidence);
            }            
            return res;
        }

        //public static bool IsHuman(this BaiduAnalyzeResult data, List<string> tagIsHumanList = null)
        //{
        //    if (tagIsHumanList == null)
        //    {
        //        tagIsHumanList = new List<string>()
        //        {
        //            "human","person"
        //        };
        //    }
        //    bool res = false;
        //    if (data.Tags != null)
        //    {
        //        res = data.Tags.AsEnumerable().Any(x => tagIsHumanList.Any(l => l == x.Name));
        //    }
        //    if (!res&&data.Description != null)
        //    {
        //        var caption = data.Description.Captions.Where(x => x.Confidence > 0.75).ToList();
        //        //如果结果里边有置信度比较高的结论,以他为准
        //        if (caption.Count() != 0)
        //        {
        //            //res = caption.Any(x =>
        //            //    x.Text.Contains("animal") || x.Text.Contains("bird") || x.Text.Contains("sheep") ||
        //            //    x.Text.Contains("bear") || x.Text.Contains("giraffe"));
        //            res = caption.Any(x => tagIsHumanList.Any(l => x.Text.Contains(l)));
        //        }
        //        else//否则就tags里边查
        //        {
        //            res = data.Description.Tags.AsEnumerable().Any(x => tagIsHumanList.Any(l => l == x));
        //        }
        //    }
        //    return res;
        //}

        public static Score IsWhich(this BaiduAnalyzeResult data)
        {
            Score res = new Score();
            if (data.result != null)
            {
                res = data.result.OrderByDescending(x => x.score).FirstOrDefault();
            }
            return res;
        }
    }
}
