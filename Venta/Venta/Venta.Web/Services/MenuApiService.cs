using Newtonsoft.Json;
using System.Text;
using Venta.Application.Dtos.Menu;
using Venta.Infrastructure.Models;
using Venta.Web.Controllers;
using Venta.Web.Models;
using Venta.Web.Models.Reponses;

namespace Venta.Web.Services
{

    public class MenuApiService : IMenuApiService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<IMenuApiService> logger;
        private readonly string baseUrl;

        public MenuApiService(IHttpClientFactory httpClientFactory,
                               IConfiguration configuration,
                               ILogger<MenuApiService> logger)
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

        public async Task<MenuDetailsReponse> GetMenu(int id)
        {
            var apiUrl = $"{baseUrl}/Menú/{id}";
            return await SendRequestAsync<MenuDetailsReponse>(apiUrl, HttpMethod.Get);
        }

        public async Task<MenuListReponse> GetMenus()
        {
            var apiUrl = $"{baseUrl}/Menu/GetMenus";
            return await SendRequestAsync<MenuListReponse>(apiUrl, HttpMethod.Get);
        }

        public async Task<MenuAddReponse> Save(menuAddDto menuAddDto)
        {
            var apiUrl = $"{baseUrl}/Menu/Save";
            return await SendRequestAsync<MenuAddReponse>(apiUrl, HttpMethod.Post, menuAddDto);
        }

        public async Task<MenuUpdateReponse> Update(menuUpdateDto menuUpdateDto)
        {
            var apiUrl = $"{baseUrl}/Menu/Update";
            return await SendRequestAsync<MenuUpdateReponse>(apiUrl, HttpMethod.Post, menuUpdateDto);
        }
    }
}
