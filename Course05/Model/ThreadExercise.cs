using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Course05.Model.Model
{
    public class ThreadExercise
    {
        public static void OneExercise()
        {
            //for (var i = 0; i < 10; i++)
            //{
            //    Model.Name();
            //}

            Action<string> action = new Action<string>(OneName);
            action.BeginInvoke("", null, null);
        }

        public static void OneName(string Name) 
        {
           
        }

        public static void TwoThreadExerce() 
        {
            ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            for (var i = 0; i < 3; i++)
            {
                Task.Run(() =>
                {
                    ThreadPool.GetAvailableThreads(out int worksThreads, out int complatePortThreads);
                    Console.WriteLine($"线程数量worksThreads——{worksThreads}  - complatePortThreads———{complatePortThreads}");
                    Console.WriteLine($"当前线程ID——{Thread.CurrentThread.ManagedThreadId.ToString("00")}  ");
                    manualResetEvent.WaitOne();
                });
            }
        }
    }
}
