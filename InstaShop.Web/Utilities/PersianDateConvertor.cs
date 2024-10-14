using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace InstaShop.Web
{
    public static class PersianDateConvertor
    {
        public static string ToShamsiDateTime(this DateTime? value)
        {

            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value.Value) + "/" +
                pc.GetMonth(value.Value).ToString("00") + "/" +
                pc.GetDayOfMonth(value.Value).ToString("00") + " " +
                value.Value.ToString("HH:mm:ss");
        }

        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }

        public static string ToShamsiDateTime(this DateTime value)
        {

            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" +
                   pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00") + " " +
                   value.ToString("HH:mm:ss");
        }
    }
}