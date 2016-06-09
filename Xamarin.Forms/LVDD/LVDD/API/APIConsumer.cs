using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LVDD.API
{
    public class APIConsumer : IDisposable
    {
        private string baseUri;
        private HttpClient client;

        public APIConsumer(string baseUri)
        {
            this.baseUri = baseUri;
            this.client = new HttpClient();
        }
        
        public IEnumerable<Model.UserItem> GetUsers()
        {
            var uri = System.IO.Path.Combine(this.baseUri, "users");
            var messageResponse = this.client.GetAsync(new Uri(uri));
            messageResponse.Wait();
            var messageTask = messageResponse.Result.Content.ReadAsStringAsync();
            messageTask.Wait();

            return JsonConvert.DeserializeObject<IEnumerable<Model.UserItem>>(messageTask.Result);
        }

        public void Dispose()
        {
            this.client.Dispose();
        }
    }
}
