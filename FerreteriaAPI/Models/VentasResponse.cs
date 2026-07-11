namespace FerreteriaAPI.Models
{
    public class VentasResponse
    {
       public string? NombreVendedor { get; set; }
       public double TotalVentas { get; set; }
       public double PromedioVentas { get; set; }
       public double VentaMayor { get; set; }
       public double VentaMenor { get; set; }
       public int DiasSobreMeta { get; set; }
       public double Comision { get; set; }
    }
}