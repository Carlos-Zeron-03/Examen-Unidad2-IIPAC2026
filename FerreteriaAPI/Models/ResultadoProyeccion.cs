namespace FerreteriaAPI.Models
{
    public class ResultadoProyeccion
    {
        public string? NombreProducto { get; set; }

        public List<DIaInventario>? Historial { get; set; }

        public int DiaReorden { get; set; }

        public string? Mensaje { get; set; }
    }
}