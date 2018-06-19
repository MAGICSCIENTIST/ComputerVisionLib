using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Vision.Contract;
using Newtonsoft.Json;
using VisionLibrary.Common;
using VisionLibrary.Interface;
using VisionLibrary.Module;

namespace VisionLibrary.VisionClass
{
    public class BaiduVisionAnalyze
    {
        private string _api = "https://aip.baidubce.com/rest/2.0/image-classify/v1/animal";

        public string API { get => _api; set => _api = value; }
        public string Key { get; set; }
        public string SKey { get; set; }
        public async Task<BaiduAnalyzeResult> UploadAndAnalyzeImage(string imageFilePath, params System.Enum[] features)
        {
            //byte[] imageBytes = VisCommonClass.GetImageAsByteArray(imageFilePath);

            //// Convert byte[] to Base64 String
            //string base64String = Convert.ToBase64String(imageBytes);


            //string token = BaiduAccessToken.getAccessToken(Key, SKey);
            //string host = $"{API}?access_token={token}";
            //Encoding encoding = Encoding.Default;
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            //request.Method = "post";
            //request.KeepAlive = true;
            //// 图片的base64编码                    
            //String str = "image=" + HttpUtility.UrlEncode(base64String);
            //byte[] buffer = encoding.GetBytes(str);
            //request.ContentLength = buffer.Length;
            //request.GetRequestStream().Write(buffer, 0, buffer.Length);
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            //string result = reader.ReadToEnd();





            HttpClient client = new HttpClient();
            

            //getToken
            string token = BaiduAccessToken.getAccessToken(Key, SKey);
            string uri = API+"?" + $"access_token={token}" ;

            //getBase64
            byte[] imageBytes = VisCommonClass.GetImageAsByteArray(imageFilePath);
            string base64String = Convert.ToBase64String(imageBytes);

            HttpResponseMessage response;
            using (HttpContent content = new StringContent($"image={HttpUtility.UrlEncode(base64String)}"))
            {                
                // Make the REST API call.
                response = await client.PostAsync(uri, content);
            }




            string contentString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(contentString);
            }
            // Get the JSON response.

            // Display the JSON response.
            Console.WriteLine("\nResponse:\n");
            Console.WriteLine(VisCommonClass.JsonPrettyPrint(contentString));

            return JsonConvert.DeserializeObject<BaiduAnalyzeResult>(contentString);


        }


    }

}
