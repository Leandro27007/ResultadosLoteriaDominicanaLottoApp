using HtmlAgilityPack;

namespace LoteriaWebScrapy.API.Servicios
{
    public interface IScrapyResultadosService
    {
        Task<string> ActualizarResultados(List<HtmlDocument> doc);
        HtmlDocument CargarWebHtml(string nombreLoteria);
    }
}
