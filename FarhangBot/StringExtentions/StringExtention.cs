using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FarhangBot.StringExtentions
{
    public static class StringExtention
    {
        public static string RemoveUniCodes(this string text)
        {
            //string result = Regex.Replace(text, @"\p{Cs}",string.Empty);
            //return result;

            string result = "";
            if (text.Contains("نظرسنجی")) result= "نظرسنجی";
            if (text.Contains("پرسش پاسخ")) result="پرسش پاسخ";
            if (text.Contains("درباره ما")) result="درباره ما";
            if (text.Contains("تماس با ما"))result= "تماس با ما";

            return result;
        }
    }
}
