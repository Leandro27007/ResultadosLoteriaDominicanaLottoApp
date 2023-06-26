using HtmlAgilityPack;
using LoteriaWebScrapy.API.Datos;
using LoteriaWebScrapy.API.Datos.Modelos;
using ScrapySharp.Extensions;
using System.Globalization;

namespace LoteriaWebScrapy.API.Servicios
{
    public class ScrapyResultadoQuinielaService : IScrapyResultadosService
    {

        private ApplicationDbContext _db;
        public ScrapyResultadoQuinielaService(ApplicationDbContext context)
        {
            this._db = context;


        }


        public async Task<string> ActualizarResultados(List<HtmlDocument> documentos)
        {


            try
            {
                List<ResultadoQuiniela> resultados = new List<ResultadoQuiniela>();

                //-Con este ciclo Itero mi lista de documentos, como vemos hay otro ciclo dentro de este, dicho ciclo me sirve
                //-para iterar el documento, al cual llamo contenidoLoteria. Este documento tiene las diferentes etiquetas
                //-que contienen los valores que defienen un resultado. por ejemplo: loteria, numeros y la fecha.
                foreach (var doc in documentos)
                {
                    //-Aqui saco el contenido que necesito, para no tener que estar iterando sobre el docuemento completo
                    //-aca solo selecciono parte del documento que esta dentro de las etiquetas "article" y "div{class=content}"
                    var contenidoLoteria = doc.DocumentNode.CssSelect("article div.content");

                    //-aqui itero el contenido seleccionado y accedo a cada etiqueta "div{Class=content} que esta en el documento"
                    //-cada una de estas etiquetas son las que tienen los resultados. por ejemplo: loteria, numeros y la fecha.

                    foreach (var item in contenidoLoteria)
                    {
                        //-Aqui obtengo el nombre de la loteria ubicado en un h3{class=title} dentro de una etiqueta "a".  uso el ">" para indicar que es una etiqueta <a>
                        var loteria = item.CssSelect("h3.title >a").FirstOrDefault();
                        //-Tambien obtengo los numeros, le hago un ToList a los elementos dentro del div{class="c"}
                        var numeros = item.CssSelect("div.data div.c").ToList();
                        //-Almaceno la fecha que esta dentro de la etiqueta <span{class="tag"}>
                        var fecha = item.CssSelect("span.tag").FirstOrDefault();

                        //-Aqui construyo lo que sera mi Id para el Resultado, es una composicion de la fecha y la loteria
                        string idResultado = Utilidades.RemoveAccentsAndSpaces(fecha.InnerText + loteria.InnerText);


                        //-Verifico si ya existe el resultado en la base de datos, si existe hago un break para salir de iterar ese elemento
                        //-Al salir de ese foreach no agrego ningun resultado a mi lista, salgo al otro Foreach a buscar otro documento.
                        //-Mi Id en la base de datos esta compuesdo de la fecha del resultado + el nombre de la loteria
                        if (_db.Set<ResultadoQuiniela>().FirstOrDefault(d => d.IdResultado == idResultado) != null)
                        {
                            break;
                        }


                        //-Creo un objeto resultado y le asigno sus propiedades obtenida anterior mente al inicio de este ciclo foreach
                        ResultadoQuiniela resultado = new ResultadoQuiniela()
                        {
                            IdResultado = idResultado,
                            IdLoteria = Utilidades.RemoveAccentsAndSpaces(loteria.InnerText),
                            FechaResultado = Utilidades.ConvertirAFecha(Utilidades.RemoveAccentsAndSpaces(fecha.InnerText)),
                            Primera = numeros.FirstOrDefault().InnerText.Trim(),
                            //-Como los numeros primera, segunda y tercera lo estoy obteniendo de una lista
                            //-la cual siempre tendra 3 numeros por que se trata de una quiniela
                            //-accedo a los dos ultimos elementos uando Skip(count)
                            Segunda = numeros.Skip(1).FirstOrDefault().InnerText.Trim(),
                            Tercera = numeros.Skip(2).FirstOrDefault().InnerText.Trim()

                        };


                        //-Agrego el resultado ya mapeado a la lista.
                        resultados.Add(resultado);
                    }

                }
                //-Marco la entidad como agregada
                await _db.AddRangeAsync(resultados);
                //-Guardo cambios en la base de datos, si las filas afectatas son mayor a 0 retorno "Se actualizaron los resultados"
                return (await _db.SaveChangesAsync() > 0) ? "Se actualizaron los resultados" : "No hay nuevos resultados, espere un proximo sorteo";

            }
            catch (Exception ex)
            {

                return $"Ocurrio un error, No se guardo nada en la base de datos. El codigo del error es: {ex.Message}";
            }

        }


        //-El string que recibe es en este formato "Loteria-nacional", esto lo concatena con la url para ir a los ultimos 6 resultados de la loteria deseada
        public HtmlDocument CargarWebHtml(string nombreLoteria)
        {
            HtmlWeb web = new HtmlWeb();

            //-aqui regreso la WebHTML cargada.
            return web.Load($"https://loteriadominicanas.com/loteria/{nombreLoteria}");
        }

    }
}
