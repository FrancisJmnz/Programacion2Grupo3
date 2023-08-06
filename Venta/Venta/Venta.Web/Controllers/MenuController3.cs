using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Venta.Application.Dtos.Menu;
using Venta.Web.Models.Reponses;
using Venta.Web.Services;

namespace Venta.Web.Controllers
{
    public class MenuController3 : Controller
        {
            private readonly IMenuApiService menuApiService;

            public MenuController3(IMenuApiService ImenuApiService)
            {
                this.menuApiService = ImenuApiService;
            }

            // GET: VentaController3
            public async Task<ActionResult> Index()
            {
            MenuListReponse menuListReponse = await this.menuApiService.GetMenus();
                return View(menuListReponse.data);
            }

            // GET: VentaController3/Details/5
            public async Task<ActionResult> Details(int id)
            {
                MenuDetailsReponse menuDetailsReponse = await this.menuApiService.GetMenu(id);
                return View(menuDetailsReponse.data);
            }

            // GET: VentaController3/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: VentaController3/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create(menuAddDto menuAddDto)
            {
                try
                {
                    MenuAddReponse menuAddResponse = await this.menuApiService.Save(menuAddDto);

                    if (menuAddResponse.Success)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = menuAddResponse.Message;
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
                    MenuDetailsReponse menuDetailsReponse = await this.menuApiService.GetMenu(id);

                    if (menuDetailsReponse.Success && menuDetailsReponse.data != null)
                    {
                        return View(menuDetailsReponse.data);
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
            public async Task<ActionResult> Edit(int id, menuUpdateDto menuUpdateDto)
            {
                try
                {
                    MenuUpdateReponse ventaUpdateResponse = await this.menuApiService.Update(menuUpdateDto);

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

