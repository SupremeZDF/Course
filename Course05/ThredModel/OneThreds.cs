using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Course05.Model.ThredModel
{
    public class OneThreds
    {
        //进程 ： 计算机概念，程序在服务器运行时占据全部计算资源总和 虚拟得
        // 线程 ： 计算机概念 进程在响应操作时最小单位，也包含cpu内存 网络 硬盘 IO
        //一个进程会包含多个线程，线程隶属于某个进程,进程销毁 线程也销毁
        //句柄 ： 其实是个 Long 数字 是操作系统标识应用程序

        //线程 ： 计算机概念 一个进程有多个线程同时进行

        public static void OneRunThread() 
        {
            //Task
            Name();
            Name();
            Name();
        }

        public static void Name() 
        {
            var o = 0;
            for (var i = 0; i < 1_000_000_00; i++) 
            {
                o += 1;
            }
            Console.WriteLine("哈哈");
        }

        public static void TwoRunThread()
        {
            //Task
            Action action = new Action(Name);
            Task.Factory.StartNew(()=> { Name(); });
            Task.Factory.StartNew(() => { Name(); });
            Task.Factory.StartNew(() => { Name(); });
            AsyncCallback asyncCallback = s => Console.WriteLine("sss");
            var a = action.BeginInvoke(null, null);
            Func<string, string> func = null;
            var b = func.BeginInvoke("",null,null);
            //action.BeginInvoke(null, null);
            Task.WaitAll();
        }

        /// <summary>
        /// 执行线程
        /// </summary>
        public static void ThreeRunThread() 
        {
            Console.WriteLine($"One 主 线程 Start:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            ThreadStart thread = () => 
            {
                Thread.Sleep(5000);
                Console.WriteLine("1");
                
                Thread.Sleep(3000);

                Console.WriteLine($"One 后台 线程 Start:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            };

            Thread thread1 = new Thread(thread);

            thread1.IsBackground = false;

            thread1.Start();


            Console.WriteLine($"One 主 线程 Start:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }
    }
}
