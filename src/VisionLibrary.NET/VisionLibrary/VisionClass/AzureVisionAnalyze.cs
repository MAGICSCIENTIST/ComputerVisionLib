using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision.Contract;
using Newtonsoft.Json;
using VisionLibrary.Interface;
using VisionLibrary.Common;
using VisionLibrary.Enum;

namespace VisionLibrary.VisionClass
{
    public class AzureVisionAnalyze : IComputerVision
    {
        public string API { get => uriBase; set => uriBase = value; }
        public string Key { get => SubscriptionKey; set => SubscriptionKey = value; }
        private string SubscriptionKey;
        //const string uriBase = "https://westcentralus.api.cognitive.microsoft.com/vision/v2.0/analyze";
        //const string uriBase = "https://api.cognitive.azure.cn/vision/v1.0/analyze";//cn image analyze
        //private const string uriBase = "https://api.cognitive.azure.cn/vision/v1.0/tag"; //cn
        private string uriBase = "https://southeastasia.api.cognitive.microsoft.com/vision/v1.0/analyze";

        /// <summary>
        ///  Gets the analysis of the specified image file by usin
        /// the Computer Vision REST API.
        /// 识别,默认图片会有压缩600px
        /// 不想压缩或者想手动压缩的走byte那个方法
        /// </summary>
        /// <param name="image"></param>
        /// <param name="azureTagFeature"></param>
        /// <returns></returns>
        public async Task<AnalysisResult> UploadAndAnalyzeImage(Bitmap image, params System.Enum[] azureTagFeature)
        {
            byte[] byteData = VisCommonClass.GetImageAsByteArray(image);

            return  UploadAndAnalyzeImage(byteData, azureTagFeature).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the analysis of the specified image file by using
        /// the Computer Vision REST API.
        /// 识别,默认图片会有压缩600px
        /// 不想压缩或者想手动压缩的走byte那个方法
        /// </summary>
        /// <param name="imageFilePath">The image file to analyze.</param>
        /// <param name="azureTagFeature">type is a enum  'AzureTagFeature' .</param>
        public async Task<AnalysisResult> UploadAndAnalyzeImage(string imageFilePath, params System.Enum[] azureTagFeature)
        {


            
            byte[] byteData = VisCommonClass.GetImageAsByteArray(imageFilePath);

            return await UploadAndAnalyzeImage(byteData, azureTagFeature);

          
        }        
        /// <summary>
        /// 识别
        /// </summary>
        /// <param name="byteData"></param>
        /// <param name="azureTagFeature"></param>
        /// <returns></returns>
        public async Task<AnalysisResult> UploadAndAnalyzeImage(byte[] byteData, params System.Enum[] azureTagFeature)
        {

            HttpClient client = new HttpClient();
            //client.Timeout = TimeSpan.FromMinutes(30);
            // Request headers.
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);

            // Request parameters. A third optional parameter is "details".
            string requestParameters = "visualFeatures=";

            if (azureTagFeature.Length == 0)
            {
                requestParameters += "Tags";
            }
            else
            {
                var a = azureTagFeature.Select(x => x.GetEnumDescription()).ToArray();
                requestParameters += string.Join(",", a);
            }

            // Assemble the URI for the REST API Call.
            string uri = uriBase + "?" + requestParameters;

            HttpResponseMessage response;

            // Request body. Posts a locally stored JPEG image.
            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                // This example uses content type "application/octet-stream".
                // The other content types you can use are "application/json"
                // and "multipart/form-data".
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

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

            return JsonConvert.DeserializeObject<AnalysisResult>(contentString);
        }



    }
}

