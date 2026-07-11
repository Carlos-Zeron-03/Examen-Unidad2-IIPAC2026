namespace FerreteriaAPI.Models
{
    public class VentasRequest
    {
        public string? NombreVendedor { get; set; }
        public List<double> Ventas { get; set; } = new List<double>();
    }
}