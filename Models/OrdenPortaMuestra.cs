using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEROTECA_WEB_BACK.Models
{
    public class OrdenPortaMuestra
    {
        [Key]
        [MaxLength(30)]
        public string OrdenPortaMuestraId { get; set; }

        [MaxLength(2)]
        public int? PosicionColumna { get; set; }

        [MaxLength(2)]
        public int? PosicionFila { get; set; }

        [MaxLength(10)]
        public int? Numero { get; set; }

        [ForeignKey("PortaMuestra")]
        [MaxLength(30)]
        public string? IdPortaMuestra { get;set; }
        public PortaMuestra? PortaMuestra { get; set; }

    }
}
