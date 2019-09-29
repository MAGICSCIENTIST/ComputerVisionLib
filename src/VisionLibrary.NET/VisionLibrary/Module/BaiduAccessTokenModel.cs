using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionLibrary.Module
{
    public class BaiduAccessTokenModel
    {        
        public double expires_in { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public string session_key { get; set; }
        public string access_token { get; set; }
        public string session_secret { get; set; }
        
    }
}
