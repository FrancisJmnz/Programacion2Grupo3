using Newtonsoft.Json;
using System.Text;
using Venta.Application.Dtos.Detalleventa;
using Venta.Web.Models.Reponses;

namespace Venta.Web.Services
{
    public class DetalleventaApiService : IDetalleventaApiService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<DetalleventaApiService> logger;
        private readonly string baseUrl;

        public DetalleventaApiService(IHttpClientFactory httpClientFactory,
                                      IConfiguration configuration,
                                      ILogger<DetalleventaApiService> logger)
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

        public async Task<DetalleventaDetailReponse> GetDetalleventa(int id)
        {
            var apiUrl = $"{baseUrl}/Detalleventa/{id}";
            return await SendRequestAsync<DetalleventaDetailReponse>(apiUrl, HttpMethod.Get);   
        }

        public async Task<DetalleventaListReponse> GetDetalleventas()
        {
            var apiUrl = $"{baseUrl}/Detalleventa/GetDetalleventa";
            return await SendRequestAsync<DetalleventaListReponse>(apiUrl, HttpMethod.Get);
        }

        public async Task<DetalleventaAddReponse> Save(DetalleventaAddDtos DetalleventaAddDtos)
        {
            var apiUrl = $"{baseUrl}/Detalleventa/Save";
            return await SendRequestAsync<DetalleventaAddReponse>(apiUrl, HttpMethod.Post, DetalleventaAddDtos);
        }

        public async Task<DetalleventaUpdateReponse> Update(DetalleventaUpdateDto DetalleventaUpdateDto)
        {
            var apiUrl = $"{baseUrl}/Detalleventa/Update";
            return await SendRequestAsync<DetalleventaUpdateReponse>(apiUrl, HttpMethod.Post, DetalleventaUpdateDto);
        }
    }
}