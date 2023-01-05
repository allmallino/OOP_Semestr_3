using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace Lab_2_OOP
{
    internal static class ConsoleLog
    {

        public delegate void AnonWriting(int index);
        public delegate string LambdaWriting(int index);
        public static string[] logList;
        public static void ToAdd(string log)
        {
            for (int i = 0; i < logList.Length; i++)
            {
                if (logList[i] == null)
                {
                    logList[i] = log;
                    return;
                }
            }
            for (int i = 0; i < logList.Length - 1; i++)
            {
                logList[i] = logList[i + 1];
            }
            logList[logList.Length - 1] = log;
        }
        public static void Show()
        {
            #region anonymous method
            AnonWriting awr = delegate (int index)
            {
                CursorLeft = 70;
                if (ConsoleLog.logList[index] == null)
                    return;
                WriteLine(ConsoleLog.logList[index]);
            };
            CursorTop = 4;
            CursorLeft = 70;
            WriteLine("Console log:");
            for (int j = 0; j < ConsoleLog.logList.Length; j++)
                awr(j);
            #endregion
            #region lambda method
            //CursorTop = 4;
            //CursorLeft = 70;
            //WriteLine("Console log:");
            //LambdaWriting lwr = (j) => { return (ConsoleLog.logList[j] != null) ? ConsoleLog.logList[j] + "\n" : ""; };
            //for (int j = 0; j < ConsoleLog.logList.Length; j++)
            //{
            //    CursorLeft = 70;
            //    Write(lwr(j));
            //}
            #endregion
        }
        public static string LastElement()
        {
            for (int i = 0; i < logList.Length; i++)
            {
                if (logList[i] == null)
                {
                    return logList[Math.Max(i-1,0)];
                }
            }
            return logList[logList.Length - 1];
        }
        static ConsoleLog()
        {
            logList = new string[6];
        }

    }
}
