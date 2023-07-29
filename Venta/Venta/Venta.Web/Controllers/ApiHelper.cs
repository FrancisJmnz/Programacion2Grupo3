using Newtonsoft.Json;
using System.Text;

namespace Venta.Web.Controllers
{
    public class ApiHelper
    {
        private readonly HttpClient httpClient;

        public ApiHelper()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => true;
            this.httpClient = new HttpClient(httpClientHandler);
            this.httpClient.BaseAddress = new Uri("http://localhost:5000/api/Detalleventa/GetDetalleventa");
        }

        public async Task<T> GetApiResponseAsync<T>(string apiUrl)
        {
            using (var response = await httpClient.GetAsync(apiUrl))
            {
                response.EnsureSuccessStatusCode();
                string apiResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiResponse);
            }
        }

        public async Task<T> PostApiRequestAsync<T>(string apiUrl, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync(apiUrl, content))
            {
                response.EnsureSuccessStatusCode();
                string apiResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiResponse);
            }
        }
    }
}