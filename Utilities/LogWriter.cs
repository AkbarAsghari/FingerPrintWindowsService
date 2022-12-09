using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Reflection;

namespace Utilities
{
    public class LogWriter
    {
        private static string m_exePath = string.Empty;
        public static void Log(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    LogWrite(logMessage, w);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// for Stream
        /// </summary>
        /// <param name="logMessage"></param>
        /// <param name="txtWriter"></param>
        private static void LogWrite(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry   : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.Write("\r\nLog Message : ");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("─────────────────────────────────────────────");
            }
            catch (Exception)
            {
            }
        }

       
        

    }
}
