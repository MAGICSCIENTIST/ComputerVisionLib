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
        public static bool IsAnimal(this AnalysisResult data)
        {
            bool res = false;
            if (data.Tags != null)
            {                
                res = data.Tags.AsEnumerable().Any(x => x.Name == "animal"||x.Name == "bird");

            }
            if (!res&&data.Description != null)
            {
                res = data.Description.Tags.AsEnumerable().Any(x => x == "animal" || x == "bird");
            }

            return res;
        }
    }
}
