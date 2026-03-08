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
        private const string localUrl = "http://192.168.0.191:8089/api/client/"; //local
        private const string remoteUrl = "http://192.168.0.152:8089/api/client/"; //remote
        private bool UserDebug { get; set; } = false;
        private string baseUrl { 
            get
            {
                return UserDebug ? localUrl : remoteUrl;
            }
        }
        HttpClient apiClient = new HttpClient();
        HttpClient statusClient = new HttpClient();
        private async Task<T> DoRequest<T>(string url, HttpClient client, object payload = null)
        {
            client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 5);
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
            await DoRequest<string>("select_file", apiClient, new RequestData() { Data = path });
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
        public async Task SetPrinterValue(string key, int value)
        {
            RequestData payload = new RequestData() { Data = value.ToString() };
            switch (key)
            {
                case "BED":
                    await DoRequest<string>("set_bed", apiClient, payload);
                    break;
                case "NOZZLE":
                    await DoRequest<string>("set_nozzle", apiClient, payload);
                    break;
                case "FAN":
                    await DoRequest<string>("set_fan", apiClient, payload);
                    break;
            }
        }
        public async Task SetZeros()
        {
            await DoRequest<string>("set_zeros", apiClient);
        }
        public async Task SetDebug()
        {
            UserDebug = !UserDebug;
            await DoRequest<string>("set_debug", apiClient);
        }
    }
}
