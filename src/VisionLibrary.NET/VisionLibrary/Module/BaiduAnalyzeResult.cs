using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using VisionLibrary.Interface;

namespace VisionLibrary.Module
{
    public class BaiduAnalyzeResult: IAnalyzeResult
    {
        public long log_id { get; set; }
        [JsonProperty(propertyName:"results")]
        public List<Score> result { get; set; }

    }
}
