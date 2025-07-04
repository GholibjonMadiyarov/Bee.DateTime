using System;
using System.Threading;

namespace Bee.DateTime
{
    public class DateTime
    {
        private static Thread t;
        private static long ts = 0;

        private static System.DateTime dt = System.DateTime.Now;

        public static bool start(long timestamp = 0)
        {
            try
            {
                if (timestamp < 0 || timestamp == 0)
                    return false;

                ts = timestamp;

                t = new Thread(start);
                t.IsBackground = true;
                t.Start();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static System.DateTime? getDateTime()
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(ts).ToLocalTime();

            return dateTime;
        }

        public static string getDateTimeString(string format = "yyyy-MM-dd HH:mm:ss")
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            string datetimeFromString = dateTime.AddSeconds(ts).ToLocalTime().ToString(format);

            return datetimeFromString;
        }

        public static long? getTimestamp()
        {
            return ts;
        }

        private static void start()
        {
            while (true)
            {
                if (System.DateTime.Now >= dt)
                {
                    dt = System.DateTime.Now.AddSeconds(1);
                    ts++;
                }

                Thread.Sleep(1);
            }
        }
    }
}
