using LoteriaWebScrapy.API.DTOs;

namespace LoteriaWebScrapy.API.Servicios.Interfaces
{
    public interface IObtenerResultadosService
    {

        Task<List<ObtenerResultadoDTO>> ObtenerRetultados();


    }
}
