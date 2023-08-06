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


    }
}
