using HtmlAgilityPack;
using LoteriaWebScrapy.API.DTOs;
using LoteriaWebScrapy.API.Servicios;
using LoteriaWebScrapy.API.Servicios.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace LoteriaWebScrapy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoLoteriaController : ControllerBase
    {

        private IObtenerResultadosService _resultadosServices;
        private IScrapyResultadosService _scrapyResultadosService;

        public ResultadoLoteriaController(IScrapyResultadosService scrapyResultadosService, IObtenerResultadosService resultadosService)
        {
            this._scrapyResultadosService = scrapyResultadosService;
            this._resultadosServices = resultadosService;
        }

        [HttpPost("ActualizarResultados")]
        public async Task<string> ActualizarResultadosAsync()
        {

            //Se cargan los documentos html de la loterias que quieres hacer el scrapy
            HtmlDocument docGanaMas = _scrapyResultadosService.CargarWebHtml("gana-mas");
            HtmlDocument docQuinielaLeidsa = _scrapyResultadosService.CargarWebHtml("quiniela-leidsa");
            HtmlDocument docPega3Mas = _scrapyResultadosService.CargarWebHtml("pega-3-mas");
            HtmlDocument docLaPrimera = _scrapyResultadosService.CargarWebHtml("la-primera");


            /*SI NECESITAS AGREGAR OTRA LOTERIA NAVEGUE A LA PAGINA : https://loteriadominicanas.com/loteria
                SELECCIONE LA LOTERIA DE LA CUAL QUIERE OBTENER LOS RESULTADOS, TENGA EN CUENTA QUE SOLO SE ACEPTAN QUINIELA
                OSEA LOS RESULTADOS QUE SOLO SON 3 NUMEROS. 

                UNA VEZ EN LA LOTERIA QUE QUIERES, COPIE EL FINAL DE LA URL REGRESE ACA Y LLAME AL METODO CargarWebHtml("finalde-url")

             ejemplo: https://loteriadominicanas.com/loteria/loteria-nacional <----> "loteria-nacional" es lo que tienes que pasar como parametro al metodo CargarWebHtml

            ASI-->   HtmlDocument docLoteriaNacional = _scrapyResultadosService.CargarWebHtml("loteria-nacional");

            Luego agregelo a la lista como se muestra a bajo
             */




            HtmlDocument docLaPrimeraNoche = _scrapyResultadosService.CargarWebHtml("la-primera-noche");

            List<HtmlDocument> listaDocumentosHtml = new List<HtmlDocument>
            {
                docGanaMas,
                docQuinielaLeidsa,
                docPega3Mas,
                docLaPrimera,
                /*AGREGANGO A LA LISTA *///--->     docLoteriaNacional,
                docLaPrimeraNoche
            };

            //Se pasa la lista de los documentos ya cargados, para actualizar o agregar a la base de datos.
            string SeActualizo = await _scrapyResultadosService.ActualizarResultados(listaDocumentosHtml);

            return SeActualizo;
        }



        [HttpGet("ObtenerResultados")]
        public async Task<ActionResult<List<ObtenerResultadoDTO>>> ObtenerResultadosAsync()
        {
            var resultados = await _resultadosServices.ObtenerRetultados();
            return (resultados.Count > 0)? Ok(resultados) : NotFound("No se encontraron resultados, intente actualizar");
        }



    }
}
