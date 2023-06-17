using Microsoft.AspNetCore.Mvc;
using Venta.Domain.Entity;
using Venta.Infrastructure.Interfaces;

namespace Venta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleventaController : ControllerBase
    {
        private readonly IDetalleventaRepository detalleventaRepository;

        public DetalleventaController(IDetalleventaRepository detalleventaRepository)
        {
            this.detalleventaRepository = detalleventaRepository;
        }

        [HttpGet("GetDetalleventa")]
        public IActionResult Get()
        {
            var detalleventas = this.detalleventaRepository.GetDetalleventa();
            return Ok(detalleventas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var venta = this.detalleventaRepository.GetDetalleventas(id);
            return Ok(venta);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] DetalleVenta detalleventas)
        {
            this.detalleventaRepository.Add(detalleventas);
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] DetalleVenta detalleventas)
        {
            this.detalleventaRepository.Update(detalleventas);
            return Ok();
        }
    }
}