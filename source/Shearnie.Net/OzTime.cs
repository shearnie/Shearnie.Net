using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shearnie.Net
{
    public class OzTime
    {     
        //// Get timezone id's here: http://stackoverflow.com/questions/5996320/net-timezoneinfo-from-olson-time-zone
        public static string AEST => "E. Australia Standard Time";

        public static TimeZoneInfo tzidAEST => TimeZoneInfo.FindSystemTimeZoneById(AEST);


        public static DateTime ConvertAEST_To_UTC(DateTime date)
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(new DateTime(date.Ticks), AEST, "UTC");
        }

        public static DateTime ConvertUTC_To_AEST(DateTime date)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(new DateTime(date.Ticks), tzidAEST);
        }

        public static DateTime? ConvertAEST_To_UTC(DateTime? date) =>
            date.HasValue ? ConvertAEST_To_UTC(date.Value) : (DateTime?)null;
        

        public static DateTime? ConvertUTC_To_AEST(DateTime? date) =>
            date.HasValue ? ConvertUTC_To_AEST(date.Value) : (DateTime?)null;


        public static string ToString_AEST_To_UTC(DateTime? date, string format) =>
            date.HasValue ? ConvertAEST_To_UTC(Convert.ToDateTime(date)).ToString(format) : "";

        public static string ToString_UTC_To_AEST(DateTime? date, string format) =>
            date.HasValue ? ConvertUTC_To_AEST(Convert.ToDateTime(date)).ToString(format) : "";
        

        public static DateTime GetNowAEST() => ConvertUTC_To_AEST(DateTime.UtcNow);

        public static DateTime GetMidnightAEST() => GetNowAEST().Date;

        public static DateTime GetMidnightUTC() => ConvertAEST_To_UTC(GetMidnightAEST());
    }
}
