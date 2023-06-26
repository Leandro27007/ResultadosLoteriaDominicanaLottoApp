using System.ComponentModel.DataAnnotations;

namespace LoteriaWebScrapy.API.Datos.Modelos
{
    public class ResultadoQuiniela
    {
        [Key]
        public string IdResultado { get; set; }
        [Required]
        public string Primera { get; set; }
        [Required]
        public string Segunda { get; set; }
        [Required]
        public string Tercera { get; set; }
        public DateOnly FechaResultado { get; set; }
        [Required]
        public string IdLoteria { get; set; }
        public Loteria Loteria { get; set; }
    }
}
