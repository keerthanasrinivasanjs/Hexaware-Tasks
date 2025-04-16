using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlling
{
    internal class Logger
    {
        public static void LogError(string message)
        {
            try
            {
                using (StreamWriter logFile = new StreamWriter("log.txt", true))
                {
                    logFile.WriteLine(message);
                }
            }
            catch (IOException e)
            {
                // Pass the original exception 'e' as the inner exception  
                throw new FileIOException("Logging failed due to an I/O error.", e);
            }
        }
    }
}
