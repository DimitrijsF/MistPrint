using MistPrintCore.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiForms
{
    public class NetCore
    {
       // private const string baseUrl = "http://192.168.0.191:8089/api/client/"; //local
        private const string baseUrl = "http://192.168.0.152:8089/api/client/"; //remote
        HttpClient apiClient = new HttpClient();
        HttpClient statusClient = new HttpClient();
        private async Task<T> DoRequest<T>(string url, HttpClient client, object payload = null)
        {
            client = new HttpClient();
            HttpResponseMessage response = null;
            client.BaseAddress = new Uri(baseUrl);
            if (payload != null)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));
            }
            else
                response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            else
                throw new Exception("Failed to call API. " + response.StatusCode);
        }
        public ClientStatus GetStatus()
        {
            return DoRequest<ClientStatus>("status", statusClient).Result;
        }
        public async Task<FileSystem.Directory> GetFileSystem()
        {
            return await DoRequest<FileSystem.Directory>("get_all_files", apiClient);
        }
        public async Task SelectFile(string path)
        {
            await DoRequest<string>("select_file", apiClient, new FileRequest() { Path = path });
        }
        public async Task StartPrint()
        {
            await DoRequest<string>("start_print", apiClient);
        }
        public async Task StopPrint()
        {
            await DoRequest<string>("stop_print", apiClient);
        }
        public async Task<FileSystem.Directory> RefreshFiles()
        {
            return await DoRequest<FileSystem.Directory>("refresh_files", apiClient);
        }
    }
}
