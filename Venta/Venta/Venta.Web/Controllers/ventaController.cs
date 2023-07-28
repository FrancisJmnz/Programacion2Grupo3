using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venta.Application.Contract;
using Venta.Application.Dtos.Venta;
using Venta.Infrastructure.Models;
using Venta.Web.Models;

namespace Venta.Web.Controllers
{
    public class ventaController : Controller
    {
        private readonly IventaService ventaService;

        public ventaController(IventaService ventaService)
        {
            this.ventaService = ventaService;
        }

        // GET: ventaController
        public ActionResult Index()
        {
            var result = this.ventaService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var datos = result.Data;

            // Utiliza el método ConvertirAVentaModelos para obtener la lista de modelos de web
            List<VentaModel> ventasModelo = Conversordemodelos.ConvertirModeloALista(datos);

            return View(ventasModelo);
        }

        // GET: ventaController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.ventaService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var venta = (ventaModel)result.Data;

            var ventamodel = Conversordemodelos.Convertventamodel(venta);


            return View(ventamodel);
        }

        // GET: ventaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ventaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ventaAddDto ventaAdd)
        {
            try
            {
                var result = this.ventaService.Save(ventaAdd);

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

        // GET: ventaController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.ventaService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var venta = (ventaModel)result.Data;

            var ventamodel = Conversordemodelos.Convertventamodel(venta);


            return View(ventamodel);
        }

        // POST: ventaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ventaUpdateDto ventaUpdate)
        {
            try
            {
                var result = this.ventaService.Update(ventaUpdate);

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
