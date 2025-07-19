using System;
using System.ComponentModel.DataAnnotations;

namespace AlmaCarne.Models
{
    public class CorteCarne
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del corte es obligatorio.")]
        [StringLength(100)]
        public string? Nombre { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }

        [StringLength(100)]
        public string? SupermercadoDestino { get; set; }
    }
}
