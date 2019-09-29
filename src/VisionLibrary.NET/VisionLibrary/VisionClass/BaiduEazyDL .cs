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
    public class BaiduEazyDL : IComputerVision
    {
        public BaiduEazyDL(AnalyzeOptions options)
        {
            this.Key = options.Key;
            this.SecretKey = options.Skey;
            this.threshold = options.Threshold;
            if (!string.IsNullOrWhiteSpace(options.Url))
            {
                this.API = options.Url;
            }
            else
            {
                throw new Exception("easyDL need an url ");
            }
        }
        public string API { get; set; }
        public string Key { get; set; }
        public string SecretKey { get; set; }
        public double? threshold { get; set; }

        public async Task<IAnalyzeResult> UploadAndAnalyzeImage(Bitmap image, params System.Enum[] features)
        {
            //getBase64
            byte[] imageBytes = VisCommonClass.GetImageAsByteArray(image);
            return await UploadAndAnalyzeImage(imageBytes);
        }

        public async Task<IAnalyzeResult> UploadAndAnalyzeImage(string imageFilePath, params System.Enum[] features)
        {
            //getBase64
            byte[] imageBytes = VisCommonClass.GetImageAsByteArray(imageFilePath, maxSize: (int)(3.2 * 1024));
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
            string jsonContent = this.threshold == null ? $"{{\"image\":\"{base64String}\"}}" : $"{{\"threshold\":\"{this.threshold}\",\"image\":\"{base64String}\"}}";



            byte[] buffer = Encoding.Default.GetBytes(jsonContent);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "post";
            request.KeepAlive = true;
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string contentString = reader.ReadToEnd();


            //HttpResponseMessage response;
            //using (HttpContent content = new StringContent(jsonContent))
            //{
            //    // Make the REST API call.
            //    response = await client.PostAsync(uri, content);
            //}


            //string contentString = await response.Content.ReadAsStringAsync();

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
