using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venta.Application.Dtos.Menu;
using Venta.Application.Dtos.MenuRol;
using Venta.Web.Models.Reponses;
using Venta.Web.Services;

namespace Venta.Web.Controllers
{
    public class MenuRolController3 : Controller
    {
        private readonly IMenuRolApiService menuRolApiService;

        public MenuRolController3(IMenuRolApiService ImenuRolApiService)
        {
            this.menuRolApiService = ImenuRolApiService;
        }

        // GET: VentaController3
        public async Task<ActionResult> Index()
        {
            MenuRolListReponse menuRolListReponse = await this.menuRolApiService.GetMenuRols();
            return View(menuRolListReponse.data);
        }

        // GET: VentaController3/Details/5
        public async Task<ActionResult> Details(int id)
        {
            MenuRolDetailsReponse menuRolDetailsReponse = await this.menuRolApiService.GetMenuRol(id);
            return View(menuRolDetailsReponse.data);
        }

        // GET: VentaController3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VentaController3/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(menurolAddDto menurolAddDto)
        {
            try
            {
                MenuRolAddReponse menuRolAddResponse = await this.menuRolApiService.Save(menurolAddDto);

                if (menuRolAddResponse.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = menuRolAddResponse.Message;
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error Creando el Menu.";
                return View();
            }
        }

        // GET: VentaController3/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                MenuRolDetailsReponse menuRolDetailsReponse = await this.menuRolApiService.GetMenuRol(id);

                if (menuRolDetailsReponse.Success && menuRolDetailsReponse.data != null)
                {
                    return View(menuRolDetailsReponse.data);
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
        public async Task<ActionResult> Edit(int id, menurolUpdateDto menurolUpdateDto)
        {
            try
            {
                MenuRolUpdateReponse menuRolUpdateResponse = await this.menuRolApiService.Update(menurolUpdateDto);

                if (menuRolUpdateResponse.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = menuRolUpdateResponse.Message;
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
