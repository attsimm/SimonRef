using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SrpClass
{
    public class Url
    {
        public static string CustomUrl(string c)
        {
            string normalized = c.Normalize(NormalizationForm.FormD);
            StringBuilder resultBuilder = new StringBuilder();
            foreach (var character in normalized)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(character);
                if (category == UnicodeCategory.LowercaseLetter
                    || category == UnicodeCategory.UppercaseLetter
                    || category == UnicodeCategory.SpaceSeparator)
                    resultBuilder.Append(character);
            }
            return Regex.Replace(resultBuilder.ToString(), @"\s+", "-");
        }
    }
}
