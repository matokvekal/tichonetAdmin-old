﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Helpers
{
    public class DateTimeHelper
    {
        public static string DateToString(DateTime? dt)
        {
            return (dt.HasValue ? dt.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) : "");
        }

        public static DateTime? StringToDate(string s)
        {
            DateTime? dtNull = null;
            if (!string.IsNullOrWhiteSpace(s))
            {
                DateTime dt = new DateTime();
                if (DateTime.TryParseExact(s, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    dtNull = (DateTime?)dt;
            }
            return dtNull;
        }

        public static string TimeToString(DateTime? dt)
        {
            return (dt.HasValue ? dt.Value.ToString("HH:mm", CultureInfo.InvariantCulture) : "");
        }

        public static DateTime? StringToTime(string s)
        {
            DateTime? dtNull = null;
            if (!string.IsNullOrWhiteSpace(s))
            {
                DateTime dt = new DateTime();
                if (DateTime.TryParseExact(s, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    dtNull = (DateTime?)dt;
            }
            return dtNull;
        }

    }
}
