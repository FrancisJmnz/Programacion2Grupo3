using Microsoft.AspNetCore.Mvc;
using Venta.Application.Contract;
using Venta.Application.Dtos.Menu;
using Venta.Application.Dtos.MenuRol;
using Venta.Domain.Entity;
using Venta.Infrastructure.Interfaces;
using Venta.Infrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Venta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuRolController : ControllerBase
    {
        private readonly IMenuRolRepository menurolRepository;

        public MenuRolController(IMenuRepository menuRepository)
        {
            this.menurolRepository = menurolRepository;
        }
        private readonly IMenuRolService menurolService;

        public MenuRolController(IMenuRolService menurolService)
        {
            this.menurolService = menurolService;
        }

        [HttpGet("GetMenuRol")]
        public IActionResult Get()
        {
            var result = this.menurolService.Get();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.menurolService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] menurolAddDto menurolAddDto)
        {
            var result = this.menurolService.Save(menurolAddDto);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] menurolUpdateDto menurolUpdateDto)
        {
            var result = this.menurolService.Update(menurolUpdateDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Remove")]
        public IActionResult Delete([FromBody] menurolRemoveDto menurolRemoveDto)
        {
            var result = this.menurolService.Remove(menurolRemoveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
