using System.ComponentModel.DataAnnotations;

namespace SEROTECA_WEB_BACK.DataAccess
{
    public class PortaMuestraDA
    {
        public int Columnas { get; set; }
        public int? Filas { get; set; }
    }

    public class PortaMuestraCommandDA
    {

        public string? Description { get; set; }

        public DateTime? FechaIni { get; set; }

        public DateTime? FechaFin { get; set; }

        public int Columnas { get; set; }

        public int? Filas { get; set; }
    }
}
