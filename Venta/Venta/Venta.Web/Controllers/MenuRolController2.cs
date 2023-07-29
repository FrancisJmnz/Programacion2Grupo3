using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Venta.Web.Models.Reponses;

namespace Venta.Web.Controllers
{
    public class MenuRolController2 : Controller
    {

        HttpClientHandler httpClientHandler = new HttpClientHandler();
        public MenuRolController2(IConfiguration configuration)
        {

            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }


        // GET: MenuRolController2
        public ActionResult Index()
        {
            MenuRolListReponse menuRolListReponse = new MenuRolListReponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync("http://localhost:5000/api/Menu/GetMenu").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        menuRolListReponse = JsonConvert.DeserializeObject<MenuRolListReponse>(apiResponse);

                    }


                }
            }



            return View(menuRolListReponse.data);
        }

        // GET: MenuRolController2/Details/5
        public ActionResult Details(int id)
        {
            MenuRolDetailsReponse menuRolDetailsReponse = new MenuRolDetailsReponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync($"http://localhost:5000/api/Menu/GetMenu/{id}").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        menuRolDetailsReponse = JsonConvert.DeserializeObject<MenuRolDetailsReponse>(apiResponse);

                    }


                }
            }



            return View(menuRolDetailsReponse.data);
        }

        // GET: MenuRolController2/Create
        public ActionResult Create()
        {
            MenuRolDetailsReponse menuRolDetailsReponse = new MenuRolDetailsReponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync("http://localhost:5000/api/Menú#/Guardar#").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        menuRolDetailsReponse = JsonConvert.DeserializeObject<MenuRolDetailsReponse>(apiResponse);

                    }


                }
            }



            return View(menuRolDetailsReponse.data);
        }

        // POST: MenuRolController2/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuRolController2/Edit/5
        public ActionResult Edit(int id)
        {
            MenuRolDetailsReponse menuRolDetailsReponse = new MenuRolDetailsReponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync("http://localhost:5000/api/Menú#/Actualizar#").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        menuRolDetailsReponse = JsonConvert.DeserializeObject<MenuRolDetailsReponse>(apiResponse);

                    }


                }
            }



            return View(menuRolDetailsReponse.data);
        }

        // POST: MenuRolController2/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
