using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Venta.Application.Dtos.Venta;
using Venta.Web.Models.Reponses;

namespace Venta.Web.Controllers
{
    public class VentaController2 : Controller
    {
        private readonly ApiHelper apiHelper;

        public VentaController2(IConfiguration configuration)
        {
            apiHelper = new ApiHelper();
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var ventaListReponse = await apiHelper.GetApiResponseAsync<VentaListReponse>("Getventas");
                return View(ventaListReponse.data);
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
                var ventaDetailReponse = await apiHelper.GetApiResponseAsync<VentaDetailReponse>($"{id}");
                return View(ventaDetailReponse.data);
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
                var ventaDetailReponse = await apiHelper.GetApiResponseAsync<VentaDetailReponse>("");
                return View(ventaDetailReponse.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los datos necesarios para crear una venta: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ventaAddDto ventaAddDto)
        {
            try
            {
                var ventaAddResponse = await apiHelper.PostApiRequestAsync<VentaAddReponse>("Save", ventaAddDto);

                if (!ventaAddResponse.Success)
                {
                    ViewBag.Message = ventaAddResponse.Message;
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
                var ventaDetailReponse = await apiHelper.GetApiResponseAsync<VentaDetailReponse>($"{id}");
                return View(ventaDetailReponse.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los detalles de la venta para editar: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ventaUpdateDto ventaUpdateDto)
        {
            try
            {
                var ventaUpdateResponse = await apiHelper.PostApiRequestAsync<VentaUpdateReponse>("Update", ventaUpdateDto);

                if (!ventaUpdateResponse.Success)
                {
                    ViewBag.Message = ventaUpdateResponse.Message;
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
    }
}
