using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpClass
{
    public class Mathematics
    {
        /// <summary>
        /// Calcul le pourcentage d'une fraction
        /// </summary>
        /// <param name="nominator">Nominateur de la fraction</param>
        /// <param name="denominator">Dénominateur de la fraction</param>
        /// <returns>Le pourcentage</returns>
        public static double GetPercentage(double nominator, double denominator)
        {
            return (nominator * 100) / denominator;
        }
    }
}
