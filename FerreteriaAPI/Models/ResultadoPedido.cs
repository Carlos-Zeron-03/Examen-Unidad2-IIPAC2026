namespace FerreteriaAPI.Models
{
    public class ResultadoPedido 
    {
        public List<DetalleArticulo>? Detalles { get; set; }

        public double SubtotalGeneral { get; set; }

        public double Descuento { get; set; }

        public double ISV { get; set; }

        public double TotalPagar { get; set; }
    }
}