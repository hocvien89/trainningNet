using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SalesProcject.Common
{
    public static class Utils
    {
        public static bool IsNumber(string str)
        {
            try
            {
                var a = Convert.ToInt64(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool IsNumberPrice(string str)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(str);
        }
        public static bool IsNumberPhone(string str)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(str);
        }
        public static bool SpecialCharacter(string str)
        {
            var regex = new Regex("^[a-zA-Z0-9 ]*$");
            return regex.IsMatch(str);
        }
    }
}