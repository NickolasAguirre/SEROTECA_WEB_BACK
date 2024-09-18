using System.ComponentModel.DataAnnotations;

namespace SEROTECA_WEB_BACK.Models
{
    public class PortaMuestra
    {
        [Required]
        [Key]
        [MaxLength(255)]
        public int? IdPortaMuestra { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        [MaxLength(10)]
        public DateTime? FechaIni { get; set; }

        [MaxLength(10)]
        public DateTime? FechaFin { get; set; }

        [MaxLength(255)]
        public int Columnas { get; set; }

        [MaxLength(255)]
        public int? Filas { get; set; }

    }
}
