using FerreteriaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaAPI.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        [HttpPost("analizar")]
        public IActionResult Analizar(List<Herramientas> herramientas)
        {
            double ValorTotal = 0;
            double mayorMargen = double.MinValue;
            string? HerramientaMayorMargen = "";

            List<DetalleHerramientas> detalles = new List<DetalleHerramientas>();

            foreach (var h in herramientas)
            {
                double utilidad = h.PrecioVenta - h.PrecioCompra;

                double margen = (utilidad / h.PrecioCompra) * 100;

                double valorInventario = h.PrecioVenta * h.Cantidad;

                ValorTotal += valorInventario;

                if (margen > mayorMargen)
                {
                    mayorMargen = margen;
                    HerramientaMayorMargen = h.Nombre;
                }

                detalles.Add(new DetalleHerramientas
                {
                    Nombre = h.Nombre,
                    Utilidad = utilidad,
                    Margen = margen,
                    ValorInventario = valorInventario
                });
            }

            ResultadoInventario resultado = new ResultadoInventario
            {
                Herramientas = detalles,
                ValorTotalInventario = ValorTotal,
                HerramientaMayorMargen = HerramientaMayorMargen
            };
            return Ok(resultado);
        }
    }
}