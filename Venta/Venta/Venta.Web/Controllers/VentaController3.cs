using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venta.Application.Dtos.Venta;
using Venta.Web.Models.Reponses;
using Venta.Web.Services;

namespace Venta.Web.Controllers
{
    public class VentaController3 : Controller
    {
        private readonly IventaApiService ventaApiService;

        public VentaController3(IventaApiService iventaApiService)
        {
            this.ventaApiService = iventaApiService;
        }

        // GET: VentaController3
        public async Task<ActionResult> Index()
        {
            VentaListReponse ventaListReponse = await this.ventaApiService.Getventas();
            return View(ventaListReponse.data);
        }

        // GET: VentaController3/Details/5
        public async Task<ActionResult> Details(int id)
        {
            VentaDetailReponse ventaDetailReponse = await this.ventaApiService.Getventa(id);
            return View(ventaDetailReponse.data);
        }

        // GET: VentaController3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VentaController3/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ventaAddDto ventaAddDto)
        {
            try
            {
                VentaAddReponse ventaAddResponse = await this.ventaApiService.Save(ventaAddDto);

                if (ventaAddResponse.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = ventaAddResponse.Message;
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error Creando la Venta.";
                return View();
            }
        }

        // GET: VentaController3/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                VentaDetailReponse ventaDetailReponse = await this.ventaApiService.Getventa(id);

                if (ventaDetailReponse.Success && ventaDetailReponse.data != null)
                {
                    return View(ventaDetailReponse.data);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: VentaController3/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ventaUpdateDto ventaUpdateDto)
        {
            try
            {
                VentaUpdateReponse ventaUpdateResponse = await this.ventaApiService.Update(ventaUpdateDto);

                if (ventaUpdateResponse.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = ventaUpdateResponse.Message;
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error updating the sale.";
                return View();
            }
        }
    }
}