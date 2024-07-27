using System;
using System.Globalization;
using System.Threading;

namespace Bee.DateTime
{
    public class DateTime
    {
        public event Action<int, string, string> StartComplete;
        public event Action<int, string, string> StartError;

        private string[] formats = new string[]
        {
            "yyyy-MM-dd HH:mm:ss",           // Год-месяц-день час:минута:секунда (24-часовой формат)
            "yyyy-MM-dd hh:mm:ss tt",        // Год-месяц-день час:минута:секунда AM/PM (12-часовой формат)
            "yyyy-MM-ddTHH:mm:ssZ",          // ISO 8601 UTC формат
            "yyyy-MM-ddTHH:mm:ss.fffZ",      // ISO 8601 UTC формат с миллисекундами
            "dd/MM/yyyy HH:mm:ss",           // День/месяц/год час:минута:секунда (24-часовой формат)
            "MM/dd/yyyy hh:mm:ss tt",        // Месяц/день/год час:минута:секунда AM/PM (12-часовой формат)
            "yyyy-MM-dd",                    // Год-месяц-день
            "dd/MM/yyyy",                    // День/месяц/год
            "MM/dd/yyyy",                    // Месяц/день/год
            "yyyy-MM-ddTHH:mm:ss",           // Год-месяц-день час:минута:секунда (без UTC)
            "yyyy-MM-ddTHH:mm:ss.fff",       // Год-месяц-день час:минута:секунда с миллисекундами
            "MM/dd/yyyy HH:mm:ss",           // Месяц/день/год час:минута:секунда (24-часовой формат)
            "dd/MM/yyyy hh:mm:ss tt",        // День/месяц/год час:минута:секунда AM/PM (12-часовой формат)
            "yyyy-M-d H:m:s",                // Год-месяц-день час:минута:секунда без ведущих нулей
            "yyyy-MM-ddTHH:mm:sszzz",        // Год-месяц-день час:минута:секунда с часовым поясом
            "yyyy-MM-ddTHH:mm:ss.fffzzz",    // Год-месяц-день час:минута:секунда с миллисекундами и часовым поясом
            "yyyyMMddHHmmss",                // Компактный формат годмесяцденьчасминутасекунда
            "yyyyMMddHHmmssfff",             // Компактный формат годмесяцденьчасминутасекундамиллисекунда
            "yyyyMMdd",                      // Компактный формат годмесяцдень
            "yyyy-MM",                       // Год-месяц
            "yyyy",                          // Год
            "MM/yyyy",                       // Месяц/год
            "HH:mm:ss",                      // Час:минута:секунда (24-часовой формат)
            "hh:mm:ss tt",                   // Час:минута:секунда AM/PM (12-часовой формат)
        };

        private System.DateTime dt;
        private Thread t;
        private bool isStart;

        public DateTime()
        { 
            isStart = false;
        }

        public void start(string datetimeFromString)
        {
            try
            {
                if (System.DateTime.TryParseExact(datetimeFromString, formats, null, DateTimeStyles.None, out dt))
                {
                    isStart = true;

                    t = new Thread(start);
                    t.IsBackground = true;
                    t.Start();

                    OnStartComplete(1, "Successfully", "RawDatetime:" + datetimeFromString + ", ParsedDatetime:" + dt.ToString());
                }
                else
                {
                    OnStartError(0, "Parse fail", "RawDatetime:" + datetimeFromString);
                }
            }
            catch (Exception e)
            {
                OnStartError(0, "Exception, " + e.Message, "RawDatetime:" + datetimeFromString);
            }
        }

        public void stop()
        {
            isStart = false;
        }

        private void start()
        {
            while (isStart)
            {
                dt.AddSeconds(1);

                Thread.Sleep(1000);
            }
        }

        protected virtual void OnStartComplete(int code, string message, string data)
        {
            if (StartComplete != null)
                StartComplete(code, message, data);
        }

        protected virtual void OnStartError(int code, string message, string data)
        {
            if (StartError != null)
                StartError(code, message, data);
        }
    }
}
