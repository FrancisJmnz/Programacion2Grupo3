using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Venta.Application.Dtos.Detalleventa;
using Venta.Web.Models.Reponses;
using System.Text;

namespace Venta.Web.Controllers
{
    public class DetalleventaController2 : Controller
    {
        private readonly ApiHelper apiHelper;

        public DetalleventaController2(IConfiguration configuration)
        {
            apiHelper = new ApiHelper();
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var detalleventaListReponse = await apiHelper.GetApiResponseAsync<DetalleventaListReponse>("GetDetalleventa");
                return View(detalleventaListReponse.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener las ventas desde el API: " + ex.Message;
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var detalleventaDetailReponse = await apiHelper.GetApiResponseAsync<DetalleventaDetailReponse>($"{id}");
                return View(detalleventaDetailReponse.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los detalles de la venta desde el API: " + ex.Message;
                return View();
            }
        }

        public async Task<ActionResult> Create()
        {
            try
            {
                var detalleventaDetailReponse = await apiHelper.GetApiResponseAsync<DetalleventaDetailReponse>("");
                return View(detalleventaDetailReponse.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los datos necesarios para crear una venta: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DetalleventaAddDtos detalleventaAddDtos)
        {
            try
            {
                var detalleventaAddResponse = await apiHelper.PostApiRequestAsync<DetalleventaAddReponse>("Save", detalleventaAddDtos);

                if (!detalleventaAddResponse.Success)
                {
                    ViewBag.Message = detalleventaAddResponse.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al guardar la nueva venta: " + ex.Message;
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var detalleventaDetailReponse = await apiHelper.GetApiResponseAsync<DetalleventaDetailReponse>($"{id}");
                return View(detalleventaDetailReponse.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los detalles de la venta para editar: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DetalleventaUpdateDto detalleventaUpdateDto)
        {
            try
            {
                var detalleventaUpdateResponse = await apiHelper.PostApiRequestAsync<DetalleventaUpdateReponse>("Update", detalleventaUpdateDto);

                if (!detalleventaUpdateResponse.Success)
                {
                    ViewBag.Message = detalleventaUpdateResponse.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al actualizar la venta: " + ex.Message;
                return View();
            }
        }

        /*
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        public DetalleventaController2(IConfiguration configuration) 
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }
        // GET: DetalleventaController2
        public ActionResult Index()
        {
            DetalleventaListReponse detalleventaListReponse = new DetalleventaListReponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = httpClient.GetAsync("http://localhost:5000/api/Detalleventa/GetDetalleventa").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        detalleventaListReponse = JsonConvert.DeserializeObject<DetalleventaListReponse>(apiResponse);
                    }
                }
            }
            return View(detalleventaListReponse.data);
        }

        // GET: DetalleventaController2/Details/5
        public ActionResult Details(int id)
        {
            {
                DetalleventaDetailReponse detalleventaDetailReponse = new DetalleventaDetailReponse();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    using (var response = httpClient.GetAsync($"http://localhost:5000/api/Detalleventa/{id}").Result)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            detalleventaDetailReponse = JsonConvert.DeserializeObject<DetalleventaDetailReponse>(apiResponse);
                        }
                    }
                }
                return View(detalleventaDetailReponse.data);
            }
        }

        // GET: DetalleventaController2/Create
        public ActionResult Create()
        {
            DetalleventaDetailReponse detalleventaDetailReponse = new DetalleventaDetailReponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = httpClient.GetAsync("http://localhost:5000/api/Detalleventa/Save").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        detalleventaDetailReponse = JsonConvert.DeserializeObject<DetalleventaDetailReponse>(apiResponse);
                    }
                }
            }
            return View(detalleventaDetailReponse.data);
        }

        // POST: DetalleventaController2/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetalleventaAddDtos detalleventaAddDtos)
        {
            try
            {
                var detalleventaAddResponse = new DetalleventaAddReponse();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(detalleventaAddDtos), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync("http://localhost:5000/api/Detalleventa/Save", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            var result = JsonConvert.DeserializeObject<DetalleventaAddReponse>(apiResponse);

                            if (!result.Success)
                            {
                                ViewBag.Message = result.Message;
                                return View();
                            }
                        }
                        else
                        {
                            ViewBag.Message = "Error actualizando el departamento";
                            return View();
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DetalleventaController2/Edit/5
        public ActionResult Edit(int id)
        {
            DetalleventaDetailReponse detalleventaDetailReponse = new DetalleventaDetailReponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync($"http://localhost:5000/api/Detalleventa/{id}").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        detalleventaDetailReponse = JsonConvert.DeserializeObject<DetalleventaDetailReponse>(apiResponse);
                    }
                }
            }
            return View(detalleventaDetailReponse.data);
        }

        // POST: DetalleventaController2/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetalleventaUpdateDto detalleventaUpdateDto)
        {
            try
            {
                var detalleventaUpdateReponse = new DetalleventaUpdateReponse();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {

                    StringContent content = new StringContent(JsonConvert.SerializeObject(detalleventaUpdateDto), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync("http://localhost:5000/api/Detalleventa/Update", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            var result = JsonConvert.DeserializeObject<DetalleventaUpdateReponse>(apiResponse);

                            if (!result.Success)
                            {
                                ViewBag.Message = result.Message;
                                return View();
                            }
                        }
                        else
                        {
                            ViewBag.Message = "Error actualizando el departamento";
                            return View();
                        }

                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}