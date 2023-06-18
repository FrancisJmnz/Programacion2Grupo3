using Microsoft.AspNetCore.Mvc;
using Venta.Domain.Entity;
using Venta.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Venta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository menuRepository;
        public MenuController(IMenuRepository menuRepository) { 
            this.menuRepository= menuRepository;
        }
        [HttpGet("GetMenu")]
        public IActionResult Get()
        {
            var menus = this.menuRepository.GetMenu();
            return Ok(menus);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var menus = this.menuRepository.GetMenu(id);
            return Ok(menus);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] Menu Menu)
        {
            this.menuRepository.Add(Menu);
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] Menu menu)
        {
            this.menuRepository.Update(menu);
            return Ok();
        }
    }
}
