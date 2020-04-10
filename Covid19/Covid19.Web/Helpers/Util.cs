using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Web.Helpers
{
    public static class Util
    {
        

        public static DateTime ConvertDateTimeToUTC9(DateTime dateTime)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");

            var localDateTime = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Local, localTimeZone);

            return localDateTime;

        }
    }
}
