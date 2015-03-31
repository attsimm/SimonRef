using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpClass
{
    public class StringFormatting
    {
        /// <summary>
        /// Met la première lettre d'une string en majuscule.
        /// </summary>
        /// <param name="input">String à majusculer</param>
        /// <returns>String avec la majuscule</returns>
        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("string is empty");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}
