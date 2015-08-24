using System;
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

        public static DateTime ConvertUTC_To_AEST(DateTime date)
        {
            if (date.Kind != DateTimeKind.Utc)
                date = date.ToUniversalTime();

            return TimeZoneInfo.ConvertTimeFromUtc(date, tzidAEST);
        }

        public static DateTime? ConvertUTC_To_AEST(DateTime? date)
        {
            if (!date.HasValue) return null;
            return ConvertUTC_To_AEST(Convert.ToDateTime(date));
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
