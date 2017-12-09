using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ISS_Client
{
    class RestClient
    {
        
       string path = "http://service1.jekobox.tk";
       HttpClient client;
        

       private static RestClient instance;

        private RestClient() {
            //Setup HttpClient basics
            client = new HttpClient();
            client.BaseAddress = new Uri(path);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        //Singleton
        public static RestClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RestClient();
                }
                return instance;
            }
        }

        public static RestClient getInstance()
        {
            if (instance == null)
            {
                instance = new RestClient();
            }
            else
            {
                return instance;
            }
            return instance;
        }


        public async Task<Message> getClassification(string subject, string message)
        {

            //query REST api for response
            //Pretty Hardcoded

            var values = new Dictionary<string, string>(){
                { "TextMessage", message} };

            var content = new FormUrlEncodedContent(values);
            HttpResponseMessage response = await client.PostAsync("api/query/", content);
            //Read Response as JSON
            var StringClasses = await response.Content.ReadAsStringAsync();

            //Convert JSON string to a Message Object
            dynamic ResponseMessage = Newtonsoft.Json.JsonConvert.DeserializeObject<Message>(StringClasses);
            Console.WriteLine(StringClasses);

            //Set remaining variables of MessageObject
            ResponseMessage.Text = message;
            ResponseMessage.Subject = subject;
            return ResponseMessage;
        }



        public async Task train(string Message, string Category)
        {
            var values = new Dictionary<string, string>(){
                { "TextMessage", Message},
                {"DesiredCategory",Category }};

            var content = new FormUrlEncodedContent(values);
            HttpResponseMessage response = await client.PostAsync("api/train/", content);
            var StringClasses = await response.Content.ReadAsStringAsync();
            Console.WriteLine(StringClasses);
            
            
        }


    }
}
