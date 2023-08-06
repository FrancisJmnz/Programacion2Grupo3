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
    }
}