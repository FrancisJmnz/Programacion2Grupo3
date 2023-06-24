using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using Venta.Application.Contract;
using Venta.Application.Dtos.Venta;
using Venta.Domain.Entity;
using Venta.Infrastructure.Interfaces;

namespace Venta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ventaController : ControllerBase
    {
        private readonly IventaService ventaService;

        public ventaController(IventaService ventaService)
        {
            this.ventaService = ventaService;
        }
      
        [HttpGet("Getventas")]
        public IActionResult Get()
        {
            var result = this.ventaService.Get();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.ventaService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] ventaAddDto ventaAddDto)
        {
            var result = this.ventaService.Save(ventaAddDto);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] ventaUpdateDto VentaUpdateDto)
        {
            var result = this.ventaService.Update(VentaUpdateDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Remove")]
        public IActionResult Delete([FromBody] ventaRemoveDto VentaRemoveDto)
        {
            var result = this.ventaService.Remove(VentaRemoveDto);
            return Ok(result);
        }


    }
}
