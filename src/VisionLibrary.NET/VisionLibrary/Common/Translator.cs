using System;
using System.Net.Http;
using System.Text;
// NOTE: Install the Newtonsoft.Json NuGet package.
using Newtonsoft.Json;

namespace VisionLibrary.Common
{
    public class Translator
    {
        private string _key;
        public string key
        {
            get => _key;
            set => _key = value;
        }

        private string _API = "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0";
        public string API
        {
            get => _API;
            set => _API = value;
        }

        public async void Translate(string text, params string[] to)
        {
            
            
            using (HttpClient client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                //翻译成谁
                string requestParameters = "&to=zh-Hans";
                request.Method = HttpMethod.Post;
                request.Headers.Add("Ocp-Apim-Subscription-Key", _key);
                System.Object[] body = new System.Object[] { new { Text = text } };
                var requestBody = JsonConvert.SerializeObject(body);
                //request.RequestUri = new Uri(host + path + requestParameters);
                request.RequestUri = new Uri(_API + requestParameters);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody), Formatting.Indented);

                Console.OutputEncoding = UnicodeEncoding.UTF8;
                Console.WriteLine(result);
            }

        }
    }
}
