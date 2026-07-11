using FerreteriaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        [HttpPost("Analizar")]
        public IActionResult Analizar (VentasRequest ventas)
        {
            double totalVentas = 0;
            double ventaMayor = 0;
            double ventaMenor = 0;
            int diasSobreMeta = 0;

            for (int i = 0; i < ventas.Ventas?.Count; i++)
            {
                totalVentas += ventas.Ventas[i];
                
                if (ventas.Ventas[i] > ventaMayor)
                {
                    ventaMayor = ventas.Ventas [i];
                }

                if (ventas.Ventas[i] < ventaMenor)
                {
                    ventaMenor = ventas.Ventas[i];
                }

                if (ventas.Ventas[i] > 3000)
                {
                    diasSobreMeta ++;
                }
            }

            double promedio = totalVentas / ventas.Ventas.Count;

            //Comisión
            double comision;
            if (totalVentas <= 5000)
            {
                comision = totalVentas * 0.03;
            }
            else
            {
                if (totalVentas <= 10000)
                {
                    comision = totalVentas * 0.05;
                }
                else
                {
                    comision = totalVentas * 0.08;
                }
            }

            VentasResponse respuesta = new VentasResponse
            {
                NombreVendedor = ventas.NombreVendedor,
                TotalVentas = totalVentas,
                PromedioVentas = promedio,
                VentaMayor = ventaMayor,
                VentaMenor = ventaMenor,
                DiasSobreMeta = diasSobreMeta,
                Comision = comision
            };

            return Ok(respuesta);
        }
    }
}