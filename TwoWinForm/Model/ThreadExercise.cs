using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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


            AsyncCallback asyncCallback = st => 
            { 
                Console.WriteLine($"打印{Newtonsoft.Json.JsonConvert.SerializeObject(st)}_后台线程结束_{Thread.CurrentThread.ManagedThreadId.ToString()}");
                Console.WriteLine($"线程ID {Thread.CurrentThread.GetHashCode()}");
            } ;

            IAsyncResult asyncResult = null;

            Console.WriteLine($"One 主 线程 Start:{Thread.CurrentThread.CurrentCulture}_{Thread.CurrentThread.ManagedThreadId.ToString()}");

            Action<string> action = new Action<string>(OneActionName);

           // action.Invoke("哈哈");

            var i = action.BeginInvoke("哈哈", asyncCallback, "花生米");

            //action.EndInvoke(asyncResult);

            Console.WriteLine($"One 主 线程 End:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString()}");
        }

        public static void OneActionName(string Name) 
        {
            Console.WriteLine($"One 后台 线程 Start:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString()}");
            var i = 0;
            for (var j = 0; j < 1_000_000_000; i++)
            {
                i++;
            }
            Thread.Sleep(2000);
            Console.WriteLine($"One 后台 线程 End:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString()}");
        }
    }
}
