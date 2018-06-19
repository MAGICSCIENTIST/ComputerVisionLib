using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision.Contract;

namespace VisionLibrary.Conclusion
{
    public static class AzureAnalyzeResultConclusion
    {        
        public static bool IsAnimal(this AnalysisResult data,List<string> tagIsAnimalList = null)
        {
            if (tagIsAnimalList == null)
            {
                tagIsAnimalList = new List<string>()
                {
                    "animal","bird","giraffe","sheep","bear","zebra","horse","elephant","monkey","cat","cow"
                };
            }

            bool res = false;
            //human is not animal
            if (IsHuman(data))
            {
                return false;
            }
            if (data.Tags != null)
            {
                //res = data.Tags.AsEnumerable().Any(x => x.Name == "animal" || x.Name == "bird" || x.Hint == "animal");
                res = data.Tags.AsEnumerable().Any(x => tagIsAnimalList.Any(l=>l == x.Name||l==x.Hint));

            }
            if (!res && data.Description != null)
            {
                var caption = data.Description.Captions.Where(x => x.Confidence > 0.75).ToList();
                //如果结果里边有置信度比较高的结论,以他为准
                if (caption.Count() != 0)
                {
                    //res = caption.Any(x =>
                    //    x.Text.Contains("animal") || x.Text.Contains("bird") || x.Text.Contains("sheep") ||
                    //    x.Text.Contains("bear") || x.Text.Contains("giraffe"));
                    res = caption.Any(x =>tagIsAnimalList.Any(l=>x.Text.Contains(l)));
                }
                else//否则就tags里边查
                {
                    res = data.Description.Tags.AsEnumerable().Any(x=>tagIsAnimalList.Any(l=>l==x));
                }
            }

            return res;
        }

        public static bool IsHuman(this AnalysisResult data, List<string> tagIsHumanList = null)
        {
            if (tagIsHumanList == null)
            {
                tagIsHumanList = new List<string>()
                {
                    "human","person"
                };
            }
            bool res = false;
            if (data.Tags != null)
            {
                res = data.Tags.AsEnumerable().Any(x => tagIsHumanList.Any(l => l == x.Name));
            }
            if (!res&&data.Description != null)
            {
                var caption = data.Description.Captions.Where(x => x.Confidence > 0.75).ToList();
                //如果结果里边有置信度比较高的结论,以他为准
                if (caption.Count() != 0)
                {
                    //res = caption.Any(x =>
                    //    x.Text.Contains("animal") || x.Text.Contains("bird") || x.Text.Contains("sheep") ||
                    //    x.Text.Contains("bear") || x.Text.Contains("giraffe"));
                    res = caption.Any(x => tagIsHumanList.Any(l => x.Text.Contains(l)));
                }
                else//否则就tags里边查
                {
                    res = data.Description.Tags.AsEnumerable().Any(x => tagIsHumanList.Any(l => l == x));
                }
            }
            return res;
        }
    }
}
