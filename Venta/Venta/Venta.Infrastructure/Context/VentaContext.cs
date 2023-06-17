using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Venta.Domain.Entity;

namespace Venta.Infrastructure.Context
{
    public partial class VentaContext : DbContext
    {

        public VentaContext() { }

        public VentaContext(DbContextOptions<VentaContext> options):base(options) { }

        public DbSet<venta> Venta { get; set; }
        

    }
}
