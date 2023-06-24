using Microsoft.AspNetCore.Mvc;
using Venta.Application.Contract;
using Venta.Application.Dtos.Detalleventa;
using Venta.Domain.Entity;
using Venta.Infrastructure.Interfaces;

namespace Venta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleventaController : ControllerBase
    {
        private readonly IDetalleventaService detalleventaService;

        public DetalleventaController(IDetalleventaService detalleventaService)
        {
            this.detalleventaService = detalleventaService;
        }

        [HttpGet("GetDetalleventa")]
        public IActionResult Get()
        {
            var result = this.detalleventaService.Get();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.detalleventaService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] DetalleventaAddDtos ventaAddDto)
        {
            var result = this.detalleventaService.Save(ventaAddDto);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] DetalleventaUpdateDto detalleventaUpdateDto)
        {
            var result = this.detalleventaService.Update(detalleventaUpdateDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Remove")]
        public IActionResult Delete([FromBody] DetalleventaRemoveDto detalleventaRemoveDto)
        {
            var result = this.detalleventaService.Remove(detalleventaRemoveDto);
            return Ok(result);
        }
    }
}