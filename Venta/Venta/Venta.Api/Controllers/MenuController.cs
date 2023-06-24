using Microsoft.AspNetCore.Mvc;
using Venta.Application.Contract;
using Venta.Application.Dtos.Menu;
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

        public MenuController(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        [HttpGet("GetMenu")]
        public IActionResult Get()
        {
            var result = this.menuService.Get();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.menuService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] menuAddDto menuAddDto)
        {
            var result = this.menuService.Save(menuAddDto);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] menuUpdateDto menuUpdateDto)
        {
            var result = this.menuService.Update(menuUpdateDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpPost("Remove")]
        public IActionResult Delete([FromBody] menuRemoveDto menuRemoveDto)
        {
            var result = this.menuService.Remove(menuRemoveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
