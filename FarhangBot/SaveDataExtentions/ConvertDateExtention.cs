using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangBot.SaveDataExtentions
{
    public static class ConvertDateExtention
    {
        public static string ConvertMiladiToShamsi(this DateTime date)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            string shamsi = pc.GetYear(date).ToString("00") + " / " + pc.GetMonth(date).ToString("00") + " / " + pc.GetDayOfMonth(date).ToString("00")
                + " - " + pc.GetHour(date).ToString("00") + " : " + pc.GetMinute(date).ToString("00");

            return shamsi;
        }
    }
}
