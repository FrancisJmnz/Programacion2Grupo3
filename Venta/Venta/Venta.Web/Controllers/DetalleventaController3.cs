using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venta.Application.Dtos.Detalleventa;
using Venta.Web.Models.Reponses;
using Venta.Web.Services;

namespace Venta.Web.Controllers
{
    public class DetalleventaController3 : Controller
    {
        private readonly IDetalleventaApiService DetalleventaApiService;

        public DetalleventaController3(IDetalleventaApiService IDetalleventaApiService)
        {
            this.DetalleventaApiService = IDetalleventaApiService;
        }

        // GET: DetalleventaController3
        public async Task<ActionResult> Index()
        {
            DetalleventaListReponse DetalleventaListReponse = await this.DetalleventaApiService.GetDetalleventas();
            return View(DetalleventaListReponse.data);
        }

        // GET: DetalleventaController3/Details/5
        public async Task<ActionResult> Details(int id)
        {
            DetalleventaDetailReponse DetalleventaDetailReponse = await this.DetalleventaApiService.GetDetalleventa(id);
            return View(DetalleventaDetailReponse.data);
        }

        // GET: DetalleventaController3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleventaController3/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DetalleventaAddDtos DetalleventaAddDtos)
        {
            try
            {
                DetalleventaAddReponse DetalleventaAddReponse = await this.DetalleventaApiService.Save(DetalleventaAddDtos);

                if (DetalleventaAddReponse.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = DetalleventaAddReponse.Message;
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error Creando el Detalleventa.";
                return View();
            }
        }

        // GET: DetalleventaController3/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                DetalleventaDetailReponse DetalleventaDetailReponse = await this.DetalleventaApiService.GetDetalleventa(id);

                if (DetalleventaDetailReponse.Success && DetalleventaDetailReponse.data != null)
                {
                    return View(DetalleventaDetailReponse.data);
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

        // POST: DetalleventaController3/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DetalleventaUpdateDto DetalleventaUpdateDto)
        {
            try
            {
                DetalleventaUpdateReponse DetalleventaUpdateReponse = await this.DetalleventaApiService.Update(DetalleventaUpdateDto);

                if (DetalleventaUpdateReponse.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = DetalleventaUpdateReponse.Message;
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