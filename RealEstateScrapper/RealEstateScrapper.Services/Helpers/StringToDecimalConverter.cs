using System.Globalization;
using System.Text.RegularExpressions;

namespace RealEstateScrapper.Services.Helpers
{
    public static class StringToDecimalConverter
    {
        public static decimal ConvertStringToDecimal(string input)
        {
            string replaced = Regex.Replace(input, @"[^0-9.,]+", string.Empty)
                .Replace(",", ".");

            return decimal.Parse(replaced, CultureInfo.InvariantCulture);
        }
    }
}
