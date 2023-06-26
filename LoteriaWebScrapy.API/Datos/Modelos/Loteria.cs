using System.ComponentModel.DataAnnotations;

namespace LoteriaWebScrapy.API.Datos.Modelos
{
    public class Loteria
    {
        [Key]
        public string IdLoteria { get; set; }
        [Required]
        public string NombreLoteria { get; set; }
        public List<ResultadoQuiniela>? ResultadosQuiniela { get; set; }
    }
}
