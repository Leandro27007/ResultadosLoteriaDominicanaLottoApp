using LoteriaWebScrapy.API.Datos.Modelos;
using System.ComponentModel.DataAnnotations;

namespace LoteriaWebScrapy.API.DTOs
{
    public class ObtenerResultadoDTO
    {

        public string IdResultado { get; set; }
        public string Primera { get; set; }
        public string Segunda { get; set; }
        public string Tercera { get; set; }
        public DateOnly FechaResultado { get; set; }
        public string? IdLoteria { get; set; } = "Indefinido";


    }
}
