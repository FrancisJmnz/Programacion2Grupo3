using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Venta.Application.Dtos.Menu;
using Venta.Web.Models.Reponses;

namespace Venta.Web.Controllers
{
    public class MenuController2 : Controller
    {
        private readonly ApiHelper apiHelper;

        public MenuController2(IConfiguration configuration)
        {
            apiHelper = new ApiHelper();
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var menuListReponse = await apiHelper.GetApiResponseAsync<MenuListReponse>("GetMenu");
                return View(menuListReponse.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los menus desde el API: " + ex.Message;
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var menuDetailsReponse = await apiHelper.GetApiResponseAsync<MenuDetailsReponse>($"{id}");
                return View(menuDetailsReponse.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los detalles de el menu desde el API: " + ex.Message;
                return View();
            }
        }

        public async Task<ActionResult> Create()
        {
            try
            {
                var menuDetailsReponse = await apiHelper.GetApiResponseAsync<MenuDetailsReponse>("");
                return View(menuDetailsReponse.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los datos necesarios para crear un menu: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(menuAddDto menuAddDto)
        {
            try
            {
                var ventaAddResponse = await apiHelper.PostApiRequestAsync<MenuAddReponse>("Save", menuAddDto);

                if (!ventaAddResponse.Success)
                {
                    ViewBag.Message = ventaAddResponse.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al guardar el nueva menu: " + ex.Message;
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var menuDetailsReponse = await apiHelper.GetApiResponseAsync<MenuDetailsReponse>($"{id}");
                return View(menuDetailsReponse.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los detalles de el menu para editar: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(menuUpdateDto menuUpdateDto)
        {
            try
            {
                var menuUpdateResponse = await apiHelper.PostApiRequestAsync<MenuUpdateReponse>("Update", menuUpdateDto);

                if (!menuUpdateResponse.Success)
                {
                    ViewBag.Message = menuUpdateResponse.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al actualizar la menu: " + ex.Message;
                return View();
            }
        }


        /*HttpClientHandler httpClientHandler = new HttpClientHandler();
          public MenuController2(IConfiguration configuration)
          {

               this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
          }


          // GET: MenuController2
          public ActionResult Index()
          {
              MenuListReponse menuListReponse = new MenuListReponse();

              using (var httpClient = new HttpClient(this.httpClientHandler))
              {

                  using (var response = httpClient.GetAsync("http://localhost:5000/api/Menu/GetMenu").Result)
                  {
                      if (response.StatusCode == System.Net.HttpStatusCode.OK)
                      {
                          string apiResponse = response.Content.ReadAsStringAsync().Result;
                       menuListReponse = JsonConvert.DeserializeObject<MenuListReponse>(apiResponse);

                      }


                  }
              }



              return View(menuListReponse.data);
          }

          // GET: MenuController2/Details/5
          public ActionResult Details(int id)
          {
              MenuDetailsReponse menuDetailsReponse = new MenuDetailsReponse();

              using (var httpClient = new HttpClient(this.httpClientHandler))
              {

                  using (var response = httpClient.GetAsync($"http://localhost:5000/api/Menú/{id}").Result)
                  {
                      if (response.StatusCode == System.Net.HttpStatusCode.OK)
                      {
                          string apiResponse = response.Content.ReadAsStringAsync().Result;
                          menuDetailsReponse = JsonConvert.DeserializeObject<MenuDetailsReponse>(apiResponse);

                      }


                  }
              }



              return View(menuDetailsReponse.data);
          }

          // GET: MenuController2/Create
          public ActionResult Create()
          {
              MenuDetailsReponse menuDetailsReponse = new MenuDetailsReponse();

              using (var httpClient = new HttpClient(this.httpClientHandler))
              {

                  using (var response = httpClient.GetAsync("http://localhost:5000/api/Menú#/Guardar#").Result)
                  {
                      if (response.StatusCode == System.Net.HttpStatusCode.OK)
                      {
                          string apiResponse = response.Content.ReadAsStringAsync().Result;
                          menuDetailsReponse = JsonConvert.DeserializeObject<MenuDetailsReponse>(apiResponse);

                      }


                  }
              }



              return View(menuDetailsReponse.data);
          }

          // POST: MenuController2/Create
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create(menuAddDto MenuDtoA)
          {
              try
              {
                  var MenuAddReponse = new MenuAddReponse();

                  using (var httpClient = new HttpClient(this.httpClientHandler))
                  {

                      StringContent content = new StringContent(JsonConvert.SerializeObject(MenuDtoA), Encoding.UTF8, "application/json");

                      using (var response = httpClient.PostAsync("http://localhost:5000/api/Menú#/Guardar#", content).Result)
                      {
                          if (response.IsSuccessStatusCode)
                          {
                              string apiResponse = response.Content.ReadAsStringAsync().Result;

                              var result = JsonConvert.DeserializeObject<MenuAddReponse>(apiResponse);

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

          // GET: MenuController2/Edit/5
          public ActionResult Edit(int id)
          {
              MenuDetailsReponse menuDetailsReponse = new MenuDetailsReponse();

              using (var httpClient = new HttpClient(this.httpClientHandler))
              {

                  using (var response = httpClient.GetAsync("http://localhost:5000/api/Menú#/Actualizar#").Result)
                  {
                      if (response.StatusCode == System.Net.HttpStatusCode.OK)
                      {
                          string apiResponse = response.Content.ReadAsStringAsync().Result;
                          menuDetailsReponse = JsonConvert.DeserializeObject<MenuDetailsReponse>(apiResponse);

                      }


                  }
              }



              return View(menuDetailsReponse.data);
          }

          // POST: MenuController2/Edit/5
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(menuUpdateDto MenuDtoU)
          {
              try
              {
                  var MenuUpdateReponse = new MenuUpdateReponse();

                  using (var httpClient = new HttpClient(this.httpClientHandler))
                  {

                      StringContent content = new StringContent(JsonConvert.SerializeObject(MenuDtoU), Encoding.UTF8, "application/json");

                      using (var response = httpClient.PostAsync("http://localhost:5000/api/Menú#/Actualizar#", content).Result)
                      {
                          if (response.IsSuccessStatusCode)
                          {
                              string apiResponse = response.Content.ReadAsStringAsync().Result;

                              var result = JsonConvert.DeserializeObject<MenuUpdateReponse>(apiResponse);

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
          }*/
    }
}
