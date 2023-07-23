using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venta.Application.Contract;
using Venta.Application.Dtos.Detalleventa;
using Venta.Infrastructure.Models;
using Venta.Web.Models;

namespace Venta.Web.Controllers
{
    public class DetalleventaController : Controller
    {
        private readonly IDetalleventaService detalleventaService;

        public DetalleventaController(IDetalleventaService detalleventaService)
        {
            this.detalleventaService = detalleventaService;
        }

        // GET: DetalleventaController
        public ActionResult Index()
        {
            var result = this.detalleventaService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var datos = result.Data;

            // Utiliza el método ConvertirAVentaModelos para obtener la lista de modelos de web
            List<DetalleventaModel> detalleventasMoldelo = Conversordemodelos.ConvertirModeloALista(datos);

            return View(detalleventasMoldelo);
        }



        // GET: DetalleventaController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.detalleventaService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var detalleventa = (detalleventaModel)result.Data;

            var detalleventamodel = Conversordemodelos.Convertventamodel(detalleventa);


            return View(detalleventamodel);
        }



        // GET: DetalleventaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleventaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetalleventaAddDtos detalleventaAdd)
        {
            try
            {
                var result = this.detalleventaService.Save(detalleventaAdd);
                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DetalleventaController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.detalleventaService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            var detalleventa = (detalleventaModel)result.Data;

            var detalleventamodel = Conversordemodelos.Convertventamodel(detalleventa);

            return View(detalleventamodel);
        }

        // POST: DetalleventaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetalleventaUpdateDto detalleventaUpdate)
        {
            try
            {
                var result = this.detalleventaService.Update(detalleventaUpdate);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
