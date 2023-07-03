using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommunalPayments.Wpf.Services
{
    internal static class TextBoxValidationService
    {
        // Строка должна быть положительной, может содержать не больше одной запятой, строка может быть пустой
        private const string PatternIntDec = @"^(?:\d+(?:[,]\d*)?|\d*[,]\d+)?$";

        public static bool IsIntOrDecNumber(string value)
        {
            return Regex.IsMatch(value, PatternIntDec);
        }

        public static bool IsIntNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            return int.TryParse(value, out int number) && number > 0;
        }
    }
}
