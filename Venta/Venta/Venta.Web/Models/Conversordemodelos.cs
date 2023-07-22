using Venta.Domain.Entity;
using Venta.Infrastructure.Models;

namespace Venta.Web.Models
{
    public static class Conversordemodelos
    {
        public static VentaModel Convertventamodel(this ventaModel ventaModelinfra)
        {
            VentaModel ventamodel = new VentaModel() 
            {
                idVenta = ventaModelinfra.idVenta,
                numeroDocumento = ventaModelinfra.numeroDocumento,
                tipoPago = ventaModelinfra.tipoPago,
                total = ventaModelinfra.total
            };
            return ventamodel;
        }

        public static List<VentaModel> ConvertirModeloALista(List<ventaModel> datos)
        {
            List<VentaModel> ventasModelo = new List<VentaModel>();

            foreach (var dato in datos)
            {
                VentaModel ventaModeloWeb = Convertventamodel(dato);
                ventasModelo.Add(ventaModeloWeb);
            }

            return ventasModelo;
        }

    }
}
