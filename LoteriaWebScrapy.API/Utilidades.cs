using System.Text.RegularExpressions;
using System.Text;
using System.Globalization;

namespace LoteriaWebScrapy.API
{
    public static class Utilidades
    {
        public static string RemoveAccentsAndSpaces(string input)
        {
            // Quitar acentos
            string cadenaSinAcentos = Regex.Replace(input.Normalize(NormalizationForm.FormD), @"[\p{Mn}]", "");

            // Quitar espacios
            string cadenaSinEspacios = Regex.Replace(cadenaSinAcentos, @"\s+", "");

            return cadenaSinEspacios;
        }

        public static DateOnly ConvertirAFecha(string fechaString)
        {
            return DateOnly.ParseExact(fechaString, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }

    }
}
