using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TwoWinForm.OneModel;
using System.Diagnostics;

namespace TwoWinForm.Model
{
    public class ThreadExercise
    {
        public static void OneExercise()
        {
            for (var i = 0; i < 10; i++)
            {
                Model.Name();
            }
        }

        public static void TwoExercise()
        {

            // 异步 委托完成的 回调函数
            AsyncCallback asyncCallback = st =>
            {
                Debug.WriteLine($"打印{Newtonsoft.Json.JsonConvert.SerializeObject(st)}_后台线程结束_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                Debug.WriteLine($"线程ID {Thread.CurrentThread.GetHashCode()}");
            };

            IAsyncResult asyncResult = null;

            Debug.WriteLine($"One 主 线程 Start:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            Action<string> action = OneActionName;

            Func<int> func = () => DateTime.Now.Hour;

            var iasy = func.BeginInvoke(s =>
            {

                //var ss = func.EndInvoke(s);

            }, null);

            //Thread.Sleep(200);

            var tt = func.EndInvoke(iasy);

            // action.Invoke("哈哈");

            //var i = action.BeginInvoke("哈哈", asyncCallback, "花生米");

            //判断 异步是否完成
            //var j = 0;
            //while (!i.IsCompleted) 
            //{
            //    if (j < 9)
            //    {
            //        Debug.WriteLine($"中华名族复兴 任务完成{j++ * 10}%");
            //    }
            //    else 
            //    {
            //        Debug.WriteLine($"中华名族复兴 任务完成99.99%");
            //    }
            //    Thread.Sleep(200);
            //}

            //Debug.WriteLine($"中华名族复兴 任务完成");

            //i.AsyncWaitHandle.WaitOne(1); //等待 毫秒  -1 一直等待 

            action.EndInvoke(asyncResult);  //即使等待 等待某次 异步操作完成

            Debug.WriteLine($"One 主 线程 End:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            //Thread.Sleep(100000);
            //Task.WaitAll();
        }

        public static void OneActionName(string Name)
        {
            Debug.WriteLine($"One 后台 线程 Start:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            var i = 0;
            for (var j = 0; j < 1_000_000_00; j++)
            {
                i++;
            }
            Thread.Sleep(2000);
            Debug.WriteLine($"One 后台 线程 End:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }

        public static void ThreeExercise()
        {
            ThreadStart threads = () => { OneActionName("123"); };
            Thread thread = new Thread(threads);
            thread.Suspend();  //暂停线程
            thread.Resume(); //恢复线程
            thread.Abort(); // 引发 异常 ，终止线程
            thread.Join(); // 等待线程的完成
            thread.Priority = ThreadPriority.Highest;  //线程调度的优先等级
            thread.IsBackground = true; // 获取或设置 该线程为后台线程  后台线程 关闭进程 线程退出
            thread.IsBackground = false;  //前台进程 进程关掉 线程执行完才关闭
        }
    }
}
