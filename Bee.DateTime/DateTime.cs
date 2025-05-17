using System;
using System.Threading;

namespace Bee.DateTime
{
    public class DateTime
    {
        private static bool isStart = false;
        private static Thread t;
        private static long? v = 0;

        public static bool start(long? unixTimeStamp = 0)
        {
            try
            {
                if (unixTimeStamp == null || unixTimeStamp == 0)
                    return false;

                isStart = true;

                v = unixTimeStamp;

                t = new Thread(start);
                t.IsBackground = true;
                t.Start();

                return true;
            }
            catch
            {
                isStart = false;

                return false;
            }
        }

        public static System.DateTime? getDateTime()
        {
            try
            {
                if (isStart == false)
                    return null;

                System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(v.Value).ToLocalTime();

                return dateTime;
            }
            catch
            {
                return null;
            }
        }

        public static string getDateTimeString(string format = "yyyy-MM-dd HH:mm:ss")
        {
            try
            {
                if (isStart == false)
                    return null;

                System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                string datetimeFromString = dateTime.AddSeconds(v.Value).ToLocalTime().ToString(format);

                return datetimeFromString;
            }
            catch
            {
                return null;
            }
        }

        public static long? getDateTimeFromUnixTime()
        {
            if (isStart == false)
                return null;

            return v;
        }

        private static void start()
        {
            while (true)
            {
                try
                {
                    v++;

                    Thread.Sleep(1000);
                }
                catch
                {

                }
            }
        }
    }
}
