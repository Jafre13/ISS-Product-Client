using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ISS_Client
{
    class RestClient
    {

        static string path = "http://service1.jekobox.tk";
        static HttpClient client = new HttpClient();
        
        

        public static async Task<List<string>> getClassification(string message)
        {
            client.BaseAddress = new Uri(path);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


            Console.WriteLine("Sending Message: " + message);
            List<string> classes = null;
            HttpResponseMessage response = await client.PostAsJsonAsync("api/query?TextMessage", message);
            var StringClasses = await response.Content.ReadAsAsync<List<string>>();
            var test = response.Headers;
            var test2 = response.StatusCode;
            var test3 = response.Content;
            Console.WriteLine("REST: "+ StringClasses + ", " + test.ToString()+ ", " + test2+ ", " + test3);

            return null;
        }

        public static async Task<Uri> train(Message m)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("path", m);
            return response.Headers.Location;
        }


    }
}
