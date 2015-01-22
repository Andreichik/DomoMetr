using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Helpers
{
    public static class NumericValidator
    {
        private static string Separator = ".|,";

        /// <summary>
        /// Проверка правильного ввода цифровых значений
        /// </summary>
        public static bool IsValidFormat(string value, int decimalNumbers = 2)
        {
            string format = "^(\\d*)";

            if (decimalNumbers > 0)
            {
                format += "(\\" + Separator + "?)";
                for (int i = 1; i <= decimalNumbers; i++)
                {
                    format += "(\\d?)";
                }
            }
            format += "$";

            bool valid = Regex.IsMatch(value, format);

            return valid;
        }
    }
}
