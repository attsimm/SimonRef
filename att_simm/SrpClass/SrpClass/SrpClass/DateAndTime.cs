using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpClass
{
    public class DateAndTime
    {
        /// <summary>
        /// Retourne l'age d'une personne
        /// </summary>
        /// <param name="bday">Date de naissance</param>
        /// <returns>L'age</returns>
        public static int GetAge(DateTime bday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            if (bday > today.AddYears(-age)) age--;
            return age;
        }
        /// <summary>
        /// Retourne la date en long.
        /// </summary>
        /// <param name="date">La date a retourner</param>
        /// <param name="culture">La culture (ex: fr-CA)</param>
        /// <returns></returns>
        public static string DateNormalized(DateTime date,string culture)
        {
            return date.ToString("D", new CultureInfo(culture));
        }
        /// <summary>
        /// Retourne la date en long selon la bonne culture
        /// </summary>
        /// <param name="date">La date a formatter</param>
        /// <param name="culture">La culture</param>
        /// <returns></returns>
        public static string DateNormalized(DateTime date, CultureInfo culture)
        {
            return date.ToString("D", culture);
        }
        /// <summary>
        /// Retourne la journée de la semaine dans la culture en paramètre
        /// </summary>
        /// <param name="dow">La journée de la semaine (DayOfWeek). Tu peux l'avoir en faisant exemple: Datetime.Now.DayOfWeek;</param>
        /// <param name="culture">La culture (ex: fr-CA)</param>
        /// <returns>La journée de la semaine normalisé pour la bonne langue.</returns>
        public static string DayOfWeekNormalized(DayOfWeek dow, string culture)
        {
            CultureInfo c = new CultureInfo(culture);
            return c.DateTimeFormat.GetDayName(dow);
        }
        /// <summary>
        /// Retourne le temps en long.
        /// </summary>
        /// <param name="date">Le temps a retourner</param>
        /// <param name="culture">La culture (ex: fr-CA)</param>
        /// <returns></returns>
        public static string TimeNormalized(DateTime t, string culture)
        {
            return t.ToString("HH:mm", new CultureInfo(culture));
        }
        /// <summary>
        /// Retourne le nombre de jour entre 2 dates
        /// </summary>
        /// <param name="Start">La date de début</param>
        /// <param name="End">La date de fin </param>
        /// <returns>Nombre de jour en double</returns>
        public static double NumberOfDays(DateTime Start, DateTime End)
        {
            return (End - Start).TotalDays;
        }
    }
}
