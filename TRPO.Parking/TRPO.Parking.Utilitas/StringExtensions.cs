using System.Globalization;

namespace TRPO.Parking.Utilitas
{
    public static class StringExtensions
    {
        public static string ReplaceCultureRealSepataror(this string str, string oldSep)
        {
            var sep = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            var res = str.Replace(oldSep, sep);
            return res;
        }
    }
}
