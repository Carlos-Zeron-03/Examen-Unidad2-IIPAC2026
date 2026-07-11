namespace FerreteriaAPI.Models
{
    public class ResultadoInventario
    {
        public List<DetalleHerramientas>? Herramientas { get; set; }
        public double ValorTotalInventario { get; set; }
        public string? HerramientaMayorMargen { get; set; }
    }
}