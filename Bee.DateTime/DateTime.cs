using System;

namespace Bee.DateTime
{
    public class DateTime
    {
        public static System.DateTime? getDateTimeFromTimestamp(long timestamp)
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(timestamp).ToLocalTime();

            return dateTime;
        }

        public static string getDateTimeString(string format = "yyyy-MM-dd HH:mm:ss")
        {
            var dt = System.DateTime.Now.ToString(format);

            return dt;
        }

        public static System.DateTime getNow()
        {
            var dt = System.DateTime.Now;

            return dt;
        }

        public static long? getTimestamp()
        {
            var ts = (long)(DateTimeOffset.Now - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds;
            return ts ;
        }
    }
}
