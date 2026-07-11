namespace FerreteriaAPI.Models
{
    public class ProductoInventario
    {
        public string? NombreProducto { get; set; }

        public double StockInicial { get; set; }

        public double PromedioVentaDiaria { get; set; }

        public double PuntoReorden { get; set; }
    }
}