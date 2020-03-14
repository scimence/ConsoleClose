using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        /// <summary>
        /// console控制台，关闭消息接收示例；
        /// 点击console窗体上的关闭按钮，或 Ctrl + C
        /// </summary>
        static void Main(string[] args)
        {
            bool result = ConsoleMsg.SetHandler(HandleF, true);
            //Console.WriteLine("设置系统消息接收函数结果 -> " + result);
            Console.ReadLine();
        }


        /// <summary>
        /// 用于处理系统消息的函数
        /// </summary>
        /// <param name="msg">系统消息</param>
        /// <returns>对系统消息的处理结果</returns>
        private static bool HandleF(int msg)
        {
            String str = "接收到console控制台消息-> " + msg;
            WriteLog(str);

            return false;
        }

        private static Object writeLock = new object();

        /// <summary>
        /// 输出运行log信息
        /// </summary>
        /// <param name="text"></param>
        private static void WriteLog(string text)
        {
            lock (writeLock)
            {
                System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "log.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + text + "\r\n");
            }
        }
    }
}
