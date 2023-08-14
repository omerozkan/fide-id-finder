using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIDE_ID_Finder.Helpers
{
    public class PlayerNameFilter
    {
        public static string Filter(string value)
        {
            return value.Replace("ı", "i")
                .Replace("ğ", "g")
                .Replace("ç", "c")
                .Replace("ö", "o")
                .Replace("ü", "u")
                .Replace("ş", "s")
                .Replace("İ", "I")
                .Replace("Ğ", "G")
                .Replace("Ç", "C")
                .Replace("Ö", "O")
                .Replace("Ü", "U")
                .Replace("Ş", "S");
        }

        public static string FilterAndUpperFirst(string value)
        {
            var ti = System.Globalization.CultureInfo.CurrentCulture.TextInfo;
            return ti.ToTitleCase(Filter(value.ToLowerInvariant()));
        }
    }
}
