using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleTest
{
    /// <summary>
    /// console控制台消息接收。
    /// 添加消息处理：SetHandler(F,true)
    /// 移除消息处理：SetHandler(F,false)
    /// </summary>
    public class ConsoleMsg
    {
        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleCtrlHandler(Handler handFunc, bool Add);

        /// <summary>
        /// 委托方法申明，用于处理系统消息处。
        /// </summary>
        /// <param name="sysMSG">接收到的系统消息</param>
        /// <returns>对系统消息的处理结果</returns>
        public delegate bool Handler(int sysMSG);

        /// <summary>
        /// 设置console控制台消息接收处理函数。
        /// 当发生系统事件时，会调用handFunc函数。
        /// </summary>
        /// <param name="handFunc">用于处理系统消息的函数</param>
        /// <param name="add">添加 或 删除，消息处理函数</param>
        /// <returns>设置是否成功</returns>
        public static bool SetHandler(Handler handFunc, bool add)
        {
            bool result = SetConsoleCtrlHandler(handFunc, add);
            Console.Read();
            return result;
        }
    }
}
