using Newtonsoft.Json;
using System.Text;
using Venta.Application.Dtos.Menu;
using Venta.Application.Dtos.MenuRol;
using Venta.Web.Models.Reponses;

namespace Venta.Web.Services
{
    public class MenuRolApiService: IMenuRolApiService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<IMenuRolApiService> logger;
        private readonly string baseUrl;

        public MenuRolApiService(IHttpClientFactory httpClientFactory,
                               IConfiguration configuration,
                               ILogger<MenuRolApiService> logger)
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

        public async Task<MenuRolDetailsReponse> GetMenuRol(int id)
        {
            var apiUrl = $"{baseUrl}/MenuRol/{id}";
            return await SendRequestAsync<MenuRolDetailsReponse>(apiUrl, HttpMethod.Get);
        }

        public async Task<MenuRolListReponse> GetMenuRols()
        {
            var apiUrl = $"{baseUrl}/MenRol/GetMenuRols";
            return await SendRequestAsync<MenuRolListReponse>(apiUrl, HttpMethod.Get);
        }

        public async Task<MenuRolAddReponse> Save(menurolAddDto menurolAddDto)
        {
            var apiUrl = $"{baseUrl}/MenuRol/Save";
            return await SendRequestAsync<MenuRolAddReponse>(apiUrl, HttpMethod.Post, menurolAddDto);
        }

        public async Task<MenuRolUpdateReponse> Update(menurolUpdateDto menurolUpdateDto)
        {
            var apiUrl = $"{baseUrl}/MenuRol/Update";
            return await SendRequestAsync<MenuRolUpdateReponse>(apiUrl, HttpMethod.Post, menurolUpdateDto);
        }
    }
}
