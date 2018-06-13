﻿using System;
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
        /// Gets the analysis of the specified image file by using
        /// the Computer Vision REST API.
        /// </summary>
        /// <param name="imageFilePath">The image file to analyze.</param>
        /// <param name="azureTagFeature">type is a enum  'AzureTagFeature' .</param>
        public async Task<AnalysisResult> UploadAndAnalyzeImage(string imageFilePath, params System.Enum[] azureTagFeature)
        {

            HttpClient client = new HttpClient();

            // Request headers.
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);

            // Request parameters. A third optional parameter is "details".
            string requestParameters = "visualFeatures=";

            if (azureTagFeature.Length == 0)
            {
                requestParameters += "Categories,Description,Color,Tags";
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
            byte[] byteData = VisCommonClass.GetImageAsByteArray(imageFilePath);

            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                // This example uses content type "application/octet-stream".
                // The other content types you can use are "application/json"
                // and "multipart/form-data".
                content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

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

