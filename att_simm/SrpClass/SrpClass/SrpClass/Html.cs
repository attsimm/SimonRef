using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SrpClass
{
    public class Html
    {
        /// <summary>
        /// Retourne une string normalisé et enlève les tags html. Cette string sera aussi réduite pour avoir le nombre de caractères désiré.
        /// </summary>
        /// <param name="a">La string a normaliser et réduire</param>
        /// <param name="b">Le nombre de charactères max</param>
        /// <returns>La string a avec un nombre b de caractères. Ah aussi "..." à la fin si nécessaire.</returns>
        public static string GetFirstChar(string a, int b)
        {
            if (string.IsNullOrEmpty(a))
            {
                return "";
            }
            a = Regex.Replace(a, @"<[^>]+>|&nbsp;", "").Trim();
            a = Regex.Replace(a, @"\s{2,}", " ");
            if (a.Length < b)
            {
                return a;
            }
            else
            {
                return a.Substring(0, b) + "...";
            }
        }
        /// <summary>
        /// Converti une string TSql en Html
        /// </summary>
        /// <param name="a">String à normaliser</param>
        /// <returns>La string normaliser</returns>
        public static string FormatTSqlToHtml(string a)
        {
            return a.Replace("\r\n", "<br />");
        }
        /// <summary>
        /// Converti une string TSql en Html
        /// </summary>
        /// <param name="a">String à normaliser</param>
        /// <returns>La string normaliser</returns>
        public static string FormatTSqlToHtmlP(string a)
        {
            a = "<p>" + a;
            a = a.Replace("\r\n", "</p><p>");
            if(a.Substring(a.Length - Math.Min(4, a.Length)) != "</p>"){
                a = a + "</p>";
            }
            a = a.Replace("<p></p>", "");
            return a;
        }
    }
}