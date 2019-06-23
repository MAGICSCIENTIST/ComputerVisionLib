using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VisionLibrary.Module;

namespace VisionLibrary.Common
{
    public static class BaiduAccessToken

    {
        // 调用getAccessToken()获取的 access_token建议根据expires_in 时间 设置缓存        
       
        private static string url = "https://aip.baidubce.com/oauth/2.0/token";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ak">百度云中开通对应服务应用的 API Key 建议开通应用的时候多选服务</param>
        /// <param name="secretKey">百度云中开通对应服务应用的 Secret Key</param>
        /// <returns></returns>
        public static BaiduAccessTokenModel getAccessToken(string ak,string secretKey)
        {
            String authHost = url;
            HttpClient client = new HttpClient();
            List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
            paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            paraList.Add(new KeyValuePair<string, string>("client_id", ak));
            paraList.Add(new KeyValuePair<string, string>("client_secret", secretKey));

            HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
            String contentString = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(contentString);

            BaiduAccessTokenModel result = JsonConvert.DeserializeObject<BaiduAccessTokenModel>(contentString);
            return result;
        }
    }
}
