﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shearnie.Net
{
    public class OzTime
    {
        public static TimeZoneInfo tzidAEST
        {
            get
            {
                //// Get timezone id's here: http://stackoverflow.com/questions/5996320/net-timezoneinfo-from-olson-time-zone
                return TimeZoneInfo.FindSystemTimeZoneById("E. Australia Standard Time");
            }
        }

        public static DateTime ConvertAEST_To_UTC(DateTime date)
        {
            switch (date.Kind)
            {
                case DateTimeKind.Local:
                    return date.ToUniversalTime();

                case DateTimeKind.Utc:
                    return date;

                case DateTimeKind.Unspecified:
                    break;
            }

            return TimeZoneInfo.ConvertTimeToUtc(date, tzidAEST);
        }

        public static DateTime ConvertUTC_To_AEST(DateTime date)
        {
            switch (date.Kind)
            {
                case DateTimeKind.Local:
                    date = date.ToUniversalTime();
                    break;

                case DateTimeKind.Utc:
                    break;

                case DateTimeKind.Unspecified:
                    break;
            }

            return TimeZoneInfo.ConvertTimeFromUtc(date, tzidAEST);
        }

        public static DateTime? ConvertUTC_To_AEST(DateTime? date)
        {
            if (!date.HasValue) return null;
            return ConvertUTC_To_AEST(Convert.ToDateTime(date));
        }

        public static string ToString_UTC_To_AEST(DateTime? date, string format)
        {
            if (!date.HasValue) return "";
            var dt = ConvertUTC_To_AEST(Convert.ToDateTime(date));
            return dt.ToString(format);
        }

        public static DateTime GetNowAEST()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzidAEST);
        }

        public static DateTime GetMidnightAEST()
        {
            return GetNowAEST().Date;
        }

        public static DateTime GetMidnightUTC()
        {
            return TimeZoneInfo.ConvertTimeToUtc(GetMidnightAEST(), tzidAEST);
        }
    }
}
