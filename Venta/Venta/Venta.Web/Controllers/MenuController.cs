using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venta.Application.Contract;
using Venta.Infrastructure.Models;
using Venta.Application.Dtos.Menu;
using Venta.Web.Models;

namespace Venta.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService MenuService;
        
        public MenuController(IMenuService MenuService)
        {
            this.MenuService= MenuService;
        }
        // GET: Menu
        public ActionResult Index()
        {
            var result = this.MenuService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var datos = result.Data;

            List<MenuModel> menuModels = Conversordemodelos.ConvertirModeloALista(datos);

            return View(menuModels);
        }

        // GET: Menu/Details/5
        public ActionResult Details(int id)
        {
            var result = this.MenuService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var menu = (MenuModel)result.Data;

            var menumodel = Conversordemodelos.Convertventamodel(menu);


            return View(menumodel);
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(menuAddDto menuAdd)
        {
            try
            {
                var result = this.MenuService.Save(menuAdd);

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

        // GET: Menu/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.MenuService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
                
            var menu = (MenuModel)result.Data;

            var menumodel = Conversordemodelos.Convertventamodel(menu);


            return View(menumodel);
        }

        // POST: Menu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(menuUpdateDto menuUpdate)
        {
            try
            {
                var result = this.MenuService.Update(menuUpdate);

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
