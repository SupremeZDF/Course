﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace TwoWinForm
{
    static class Program
    {

        //[DllImport("kernel32.dll")]
        //public static extern bool AllocConsole();
        //[DllImport("kernel32.dll")]
        //public static extern bool FreeConsole();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        //[STAThread]
        static void Main()
        {

            //ThreadPool.SetMaxThreads(8,8);


            //ThreadPool.GetAvailableThreads(out int workThreads, out int complatePortThreads);

            //Debug.WriteLine($"线程池线程数量{workThreads} ___ {complatePortThreads}");

            //Process p = new Process();
            //string appPath = Application.StartupPath + @"aa.exe";//
            //p.StartInfo.FileName = appPath;
            //p.StartInfo.UseShellExecute = false;
            //p.StartInfo.RedirectStandardOutput = true;
            //p.StartInfo.RedirectStandardInput = false;
            //p.StartInfo.CreateNoWindow = false;

            // 允许调用控制台输出
            //AllocConsole();


            //Console.WriteLine("sdasdasda");
            //p.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());

            // 释放
            //FreeConsole();
        }
    }
}
