using FerreteriaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyeccionController : ControllerBase
    {
        [HttpPost ("inventario")]
        public IActionResult Inventario(ProductoInventario inventario)
        {
            double stock = inventario.StockInicial;
            int dia = 0;
            List<DIaInventario> historial = new List<DIaInventario>();

            if (stock <= inventario.PuntoReorden)
            {
                ResultadoProyeccion resultado = new ResultadoProyeccion
                {
                    NombreProducto = inventario.NombreProducto,
                    Historial = historial,
                    DiaReorden = 0,
                    Mensaje = "El producto ya se encuentra en Reorden"  
                };
                return Ok(resultado);
            }

            while (stock > inventario.PuntoReorden)
            {
                dia ++;
                stock -= inventario.PromedioVentaDiaria;
                historial.Add(new DIaInventario
                {
                   Dia = dia,
                   StockRestante = stock 
                });
            }

            ResultadoProyeccion respuesta = new ResultadoProyeccion
            {
               NombreProducto = inventario.NombreProducto,
               Historial = historial,
               DiaReorden = dia,
               Mensaje = "Se ha alcanzado el dia de Reorden" 
            } ;

            return Ok(respuesta);
        }
    }
}