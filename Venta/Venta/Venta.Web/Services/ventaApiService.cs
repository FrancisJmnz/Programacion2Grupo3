using Newtonsoft.Json;
using System.Text;
using Venta.Application.Dtos.Venta;
using Venta.Web.Models.Reponses;

namespace Venta.Web.Services
{
    public class ventaApiService : IventaApiService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<ventaApiService> logger;
        private readonly string baseUrl;

        public ventaApiService(IHttpClientFactory httpClientFactory,
                               IConfiguration configuration,
                               ILogger<ventaApiService> logger)
        {
            this.httpClient = httpClientFactory.CreateClient();
            this.baseUrl = configuration["ApiConfig:baseUrl"];
            this.logger = logger;
            this.httpClient.BaseAddress = new Uri(this.baseUrl);
        }

        private async Task<TResponse> SendRequestAsync<TResponse>(string apiUrl, HttpMethod httpMethod, object data = null)
        {
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(httpMethod, apiUrl);

                if (data != null)
                {
                    string jsonContent = JsonConvert.SerializeObject(data);
                    requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                }

                using (var response = await httpClient.SendAsync(requestMessage))
                {
                    response.EnsureSuccessStatusCode();
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TResponse>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al enviar la solicitud al API en {apiUrl}: {ex}");
                return default(TResponse);
            }
        }

        public async Task<VentaDetailReponse> Getventa(int id)
        {
            var apiUrl = $"{baseUrl}/venta/{id}";
            return await SendRequestAsync<VentaDetailReponse>(apiUrl, HttpMethod.Get);
        }

        public async Task<VentaListReponse> Getventas()
        {
            var apiUrl = $"{baseUrl}/venta/Getventas";
            return await SendRequestAsync<VentaListReponse>(apiUrl, HttpMethod.Get);
        }

        public async Task<VentaAddReponse> Save(ventaAddDto ventaAddDto)
        {
            var apiUrl = $"{baseUrl}/venta/Save";
            return await SendRequestAsync<VentaAddReponse>(apiUrl, HttpMethod.Post, ventaAddDto);
        }

        public async Task<VentaUpdateReponse> Update(ventaUpdateDto ventaUpdateDto)
        {
            var apiUrl = $"{baseUrl}/venta/Update";
            return await SendRequestAsync<VentaUpdateReponse>(apiUrl, HttpMethod.Post, ventaUpdateDto);
        }
    }
}
