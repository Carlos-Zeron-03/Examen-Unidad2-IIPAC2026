using FerreteriaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        [HttpPost("cotizar")]
        public IActionResult Cotizar(Pedido pedido)
        
        {
            double SubtotalGeneral = 0;
            int totalUnidades = 0;

            List<DetalleArticulo> detalles = new List<DetalleArticulo>();

            foreach (var articulo in pedido.Articulos)
            {
                double subtotal = articulo.PrecioUnitario * articulo.Cantidad;
                SubtotalGeneral += subtotal;
                totalUnidades += articulo.Cantidad;
                detalles.Add(new DetalleArticulo
                {
                    NombreProducto = articulo.NombreProducto,
                    Subtotal = subtotal
                });
            }

            double porcentajeDescuento;
           
            if (totalUnidades >= 30)
            {
                porcentajeDescuento = 0.10;
            }
            else
            {
                if (totalUnidades >= 10)
                {
                    porcentajeDescuento = 0.05;
                }
                else
                {
                    porcentajeDescuento = 0;
                }
            }

            double subtotalConDescuento = SubtotalGeneral * (1 - porcentajeDescuento);
            double isv = subtotalConDescuento * 0.15;
            double TotalPagar = subtotalConDescuento + isv;

            ResultadoPedido resultado = new ResultadoPedido
            {
                Detalles = detalles,
                SubtotalGeneral = SubtotalGeneral,
                Descuento = porcentajeDescuento * 100,
                ISV = isv,
                TotalPagar = TotalPagar
            };
            return Ok(resultado);
        }
    }
}