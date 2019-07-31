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
using Newtonsoft.Json.Linq;
using VisionLibrary.Common;
using VisionLibrary.Interface;
using VisionLibrary.Module;

namespace VisionLibrary.VisionClass
{
    public class BaiduVisionAnalyze:IComputerVision
    {
        private string _api = "https://aip.baidubce.com/rest/2.0/image-classify/v1/animal";

        public string API { get => _api; set => _api = value; }
        public string Key { get; set; }
        public string SecretKey { get; set; }

        public BaiduVisionAnalyze(AnalyzeOptions options)
        {
            this.Key = options.Key;
            this.SecretKey = options.Skey;
            if (!string.IsNullOrWhiteSpace(options.Url))
            {
                this.API = options.Url;
            }
        }

        public async Task<IAnalyzeResult> UploadAndAnalyzeImage(Bitmap image, params System.Enum[] features)
        {
            //getBase64
            byte[] imageBytes = VisCommonClass.GetImageAsByteArray(image);
            return await UploadAndAnalyzeImage(imageBytes);
        }

        public async Task<IAnalyzeResult> UploadAndAnalyzeImage(string imageFilePath, params System.Enum[] features)
        {
            //getBase64
            byte[] imageBytes = VisCommonClass.GetImageAsByteArray(imageFilePath);
            return await UploadAndAnalyzeImage(imageBytes);
        }

        public async Task<IAnalyzeResult> UploadAndAnalyzeImage(byte[] imageBytes, params System.Enum[] features)
        {
            HttpClient client = new HttpClient();

            //getToken
            string token = BaiduAccessToken.getAccessToken(Key, SecretKey).access_token;
            string uri = API + "?" + $"access_token={token}";

            //getBase64            
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

            contentString = contentString.Replace("\"result", "\"results");

            return JsonConvert.DeserializeObject<BaiduAnalyzeResult>(contentString);


        }


    }

}
