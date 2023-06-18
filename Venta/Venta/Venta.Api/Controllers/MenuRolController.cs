using Microsoft.AspNetCore.Mvc;
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
        public MenuRolController(IMenuRolRepository menurolRepository)
        {
            this.menurolRepository = menurolRepository;
        }
        [HttpGet("GetMenuRol")]
        public IActionResult Get()
        {
            var menurols = this.menurolRepository.GetMenuRol();
            return Ok(menurols);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var menus = this.menurolRepository.GetMenuRol(id);
            return Ok(menus);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] MenuRol MenuRol)
        {
            this.menurolRepository.Add(MenuRol);
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] MenuRol MenuRol)
        {
            this.menurolRepository.Update(MenuRol);
            return Ok();
        }
    }
}
