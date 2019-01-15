using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace SalesProcject.Cm
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

        public static long? ConvertStrToLong(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                    return null;
                else
                    return Convert.ToInt64(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int? ConvertStrToInt(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                    return null;
                else
                    return Convert.ToInt32(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static double? ConvertStrToDouble(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                    return null;
                else
                    return Convert.ToInt64(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsNumberPhone(string str)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(str);
        }
        
        public static bool IsEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        


    }
}