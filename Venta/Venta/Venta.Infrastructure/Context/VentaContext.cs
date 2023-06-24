using Microsoft.EntityFrameworkCore;
using Venta.Domain.Entity;

namespace Venta.Infrastructure.Context
{
    public partial class VentaContext : DbContext
    {
        public VentaContext () 
        {
        
        }
        public VentaContext(DbContextOptions<VentaContext> options) : base (options)
        {

        }
        
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
    }
}