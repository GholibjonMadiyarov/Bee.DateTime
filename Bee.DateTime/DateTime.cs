using System;
using System.Threading;

namespace Bee.DateTime
{
    public class DateTime
    {
        private static bool isStart = false;
        private static Thread t;
        private static long? ts = 0;

        public static bool start(long? timestamp = 0)
        {
            try
            {
                if (timestamp == null || timestamp == 0)
                    return false;

                isStart = true;

                ts = timestamp;

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
                dateTime = dateTime.AddSeconds(ts.Value).ToLocalTime();

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
                string datetimeFromString = dateTime.AddSeconds(ts.Value).ToLocalTime().ToString(format);

                return datetimeFromString;
            }
            catch
            {
                return null;
            }
        }

        public static long? getTimestamp()
        {
            if (isStart == false)
                return null;

            return ts;
        }

        private static void start()
        {
            while (true)
            {
                try
                {
                    ts++;

                    Thread.Sleep(1000);
                }
                catch
                {

                }
            }
        }
    }
}
