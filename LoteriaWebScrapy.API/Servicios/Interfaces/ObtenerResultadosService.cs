using LoteriaWebScrapy.API.Datos;
using LoteriaWebScrapy.API.Datos.Modelos;
using LoteriaWebScrapy.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LoteriaWebScrapy.API.Servicios.Interfaces
{
    public class ObtenerResultadosService : IObtenerResultadosService
    {


        private ApplicationDbContext _db;
        public ObtenerResultadosService(ApplicationDbContext context)
        {
            this._db = context;

        }


        public async Task<List<ObtenerResultadoDTO>> ObtenerRetultados()
        {
            //Obtiene una consulta a la entidad ResultadoQuiniela
            IQueryable<ResultadoQuiniela> consultaResultados = _db.Set<ResultadoQuiniela>().AsQueryable();


            //Ejecuta la consulta y guarda la lista en resultadoDTO
            List<ObtenerResultadoDTO>? resultadosDTO = await consultaResultados
                                                                              .Select(item => new ObtenerResultadoDTO
                                                                              {
                                                                                  IdResultado = item.IdResultado,
                                                                                  Primera = item.Primera,
                                                                                  Segunda = item.Segunda,
                                                                                  Tercera = item.Tercera,
                                                                                  FechaResultado = item.FechaResultado,
                                                                                  IdLoteria = item.IdLoteria
                                                                              })
                                                                              .ToListAsync();

            return resultadosDTO;
        }
    }
}
