using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Venta.WebApp.Controllers
{
    public class DetalleventaController : Controller
    {
        // GET: DetalleventaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DetalleventaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetalleventaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleventaController/Create
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

        // GET: DetalleventaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetalleventaController/Edit/5
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
