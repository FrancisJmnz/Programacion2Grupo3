using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using Venta.Domain.Entity;
using Venta.Infrastructure.Interfaces;

namespace Venta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ventaController : ControllerBase
    {

        private readonly IventaRepository ventarepository;

        public ventaController(IventaRepository ventarepository) 
        { 
          this.ventarepository = ventarepository;
        }

        [HttpGet("Getventas")]
        public IActionResult Get()
        {
            var ventas = this.ventarepository.Getventas();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var venta = this.ventarepository.Getventa(id);
            return Ok(venta);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] venta Venta)
        {
            this.ventarepository.Add(Venta);
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] venta Venta)
        {
            this.ventarepository.Update(Venta);
            return Ok();
        }
    }
}
