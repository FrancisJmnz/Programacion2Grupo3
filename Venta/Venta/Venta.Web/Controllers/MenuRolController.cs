using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venta.Application.Contract;
using Venta.Application.Dtos.MenuRol;
using Venta.Infrastructure.Models;
using Venta.Web.Models;

namespace Venta.Web.Controllers
{
    public class MenuRolController : Controller
    {
        private readonly IMenuRolService MenuRolService;

        public MenuRolController(IMenuRolService MenuRolService)
        {
            this.MenuRolService = MenuRolService;
        }
        // GET: MenuRol
        public ActionResult Index()
        {
            var result = this.MenuRolService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var datos = result.Data;

            List<menuRolModel> MenuRolModel = Conversordemodelos.MRConvertirModeloALista(datos);

            return View(MenuRolModel);
        }

        // GET: MenuRol/Details/5
        public ActionResult Details(int id)
        {
            var result = this.MenuRolService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var menurol = (menuRolModel)result.Data;

            var MenuRolmodel = Conversordemodelos.Convertventamodel(menurol);


            return View(MenuRolmodel);
        }

        // GET: MenuRol/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuRol/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(menurolAddDto MenuRolAdd)
        {
            try
            {
                var result = this.MenuRolService.Save(MenuRolAdd);

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

        // GET: MenuRol/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.MenuRolService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var menuRol = (menuRolModel)result.Data;

            var MenuRolmodel = Conversordemodelos.Convertventamodel(menuRol);


            return View(MenuRolmodel);
        }

        // POST: MenuRol/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(menurolUpdateDto MenuRolUpdate)
        {
            try
            {
                var result = this.MenuRolService.Update(MenuRolUpdate);

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
