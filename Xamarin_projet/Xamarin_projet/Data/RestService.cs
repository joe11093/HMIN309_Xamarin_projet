using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Xamarin_projet
{
    public class RestService : IRestService
    {
        HttpClient httpClient;
        public List<Message> Messages { get; private set; }

        public RestService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Message>> RefreshDataAsync()
        {
            Messages = new List<Message>();

            var uri = new Uri(string.Format(Constants.BaseAddress, string.Empty));
            Console.WriteLine(uri.ToString());
            try
            {
                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Messages = JsonConvert.DeserializeObject<List<Message>>(content);
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(@"\tERROR {0}", e.Message);

            }
            return Messages;
            
        }
    }
}
