using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    public static class Log
    {
        public static LogMode currentMode = LogMode.ERROR;
        public static bool doLogFile = true;

        public static void d(string message)
        {
            if ((int)currentMode >= (int)LogMode.DEBUG)
            {
                write(message);
            }
        }

        public static void v(string message)
        {
            if ((int)currentMode >= (int)LogMode.VERBOSE)
            {
                write(message);
            }
        }

        public static void e(string message)
        {
            if ((int)currentMode >= (int)LogMode.ERROR)
            {
                write(message);
            }
        }

        private static void write(string message)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(message);
        }

        public static void setLogMode(LogMode l)
        {
            currentMode = l;
        }

        public enum LogMode
        {
            ERROR = 0,
            DEBUG = 1,
            VERBOSE = 2
        }
    }
}
