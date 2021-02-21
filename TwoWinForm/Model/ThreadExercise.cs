using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TwoWinForm.OneModel;
using System.Diagnostics;
using System.Data;

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

            //action.BeginInvoke();

            Func<int> func = () => DateTime.Now.Hour;

            {
                Func<int, int> func1 = c => { return DateTime.Now.Year; };

                var s = func1.BeginInvoke(1, sss => { }, "123");

                var ss = func1.EndInvoke(s);

                //Action<int> action1 = delegate (int a) { Console.WriteLine(""); };
            }


            var iasy = func.BeginInvoke(s =>
            {

                //var ss = func.EndInvoke(s);
                //AsyncCallback async =

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

        /// <summary>
        /// 
        /// </summary>
        public static void FourExercise()
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

            //是否是后台(前台)线程
            thread1.IsBackground = true;

            thread1.Start();
            Console.WriteLine($"One 主 线程 End:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }

        private static void ThreadCallBacak(ThreadStart threadStart, Action action)
        {
            //Func<Model, ThreadExercise> func = x => new ThreadExercise { model = x.GetType() }; 
            //var r = func.Invoke(null);

            ThreadStart thread = new ThreadStart(() =>
            {
                threadStart.Invoke();
                action.Invoke();
            });

            Thread threads = new Thread(thread);
            //执行线程
            threads.Start();

            //thread.Start(); //开始 
            //thread.Join(); // 等待 
            //thread.Resume(); //恢复
        }

        /// <summary>
        /// 异步 阻塞 结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T ThreadWithReturn<T>(Func<T> func)
        {
            var t = default(T);
            //ThreadStart threadStart = new ThreadStart(() =>
            //{
            //    t = func.Invoke();
            //});
            Thread thread = new Thread(() =>
            {
                t = func.Invoke();
            });

            thread.Start();

            //thread.Join();
            Func<T> ts = () => { thread.Join(); return t; };
            return t;
        }

        /// <summary>
        /// 异步改造 异步 非阻塞 结果 等待交给外面等待
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Func<T> ThreadWithReturnGZ<T>(Func<T> func)
        {
            var t = default(T);
            //ThreadStart threadStart = new ThreadStart(() =>
            //{
            //    t = func.Invoke();
            //});
            Thread thread = new Thread(() =>
            {
                t = func.Invoke();
            });
            thread.Start();

            //返回结果 交给 外面等待
            return new Func<T>(() =>
            {
                thread.Join();
                return t;
            });
        }
        /// <summary>
        /// 线程完成回调 线程异步 不阻塞 有返回值
        /// </summary>
        public static void FiveExercise()
        {

            //死锁
            // 不要阻塞 线程池 的 线程 (线程死锁)
            {

                ManualResetEvent manualResetEvent = new ManualResetEvent(false);

                //设置线程池最大的线程数量
                ThreadPool.SetMaxThreads(8, 8);

                //var k = 0;

                for (var i = 0; i < 15; i++)
                {
                    var k = i;

                    if (i > 7)
                    {
                        //不受  线程池 数量限制  ，但是会占用线程池数量
                        new Thread(() =>
                        {
                            Debug.WriteLine($" 线程 线程_{k} Start等待{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                            manualResetEvent.WaitOne();
                        }).Start();
                    }
                    else
                    {
                        ThreadPool.QueueUserWorkItem(c =>
                        {
                            Debug.WriteLine($" 线程池 线程_{k} Start等待{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                            //等待
                            manualResetEvent.WaitOne();
                            manualResetEvent.Set();
                        });
                    }
                }

                if (manualResetEvent.WaitOne())
                {
                    Debug.WriteLine($"One 线程池 线程 End 结束了{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                }
            }

            {

                //设置线程池数量 
                ThreadPool.SetMaxThreads(10, 12);

                Action action = () =>
                {
                    Debug.WriteLine($" 线程池 线程 Start等待{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    Thread.Sleep(3000);
                };

                //action.BeginInvoke(null,null);


                Thread thread = new Thread(() =>
                {
                    action.Invoke();
                });

                thread.Start();

                //action.EndInvoke(null);

                //ThreadPool.QueueUserWorkItem((c)=> 
                //{
                //    Debug.WriteLine($" 线程池 线程 Start等待{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                //    Thread.Sleep(3000);
                //});

                Thread.Sleep(1000);
                ThreadPool.GetAvailableThreads(out int workThreadss, out int conplatePosrtThreadss);
                Debug.WriteLine($" 线程池 线程数  {workThreadss} 线程 I/O 数量  {conplatePosrtThreadss} ");

                //Thread.Sleep(3000);
                ThreadPool.GetAvailableThreads(out int workThreads, out int conplatePosrtThreads);
                Debug.WriteLine($" 线程池 线程数  {workThreads} 线程 I/O 数量  {conplatePosrtThreads} ");

                //DataRow a = new DataRow();
                //a.RowState
            }





            //线程池 线程等待 ManualResetEvent（锁、线程阻塞）
            //ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            //false - 关闭 - set打开（waitOne就会收到信号） - true  -waitOne就能通过
            //true  - 打开 - reset 关闭 -  waitOne 就只能等待
            {
                ManualResetEvent manualResetEvent = new ManualResetEvent(false);
                //线程池委托
                WaitCallback waitCallback = (c) =>
                {
                    Debug.WriteLine($"One 后台 线程 Start:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    Thread.Sleep(3000);
                    Console.WriteLine(c);
                    Debug.WriteLine($"One 后台 线程 End:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    manualResetEvent.Set(); //相当于锁的 开关
                };
                //线程池任务等待

                ThreadPool.QueueUserWorkItem(waitCallback, "昔日");

                manualResetEvent.WaitOne(); //等待线程池 线程任务
                Console.WriteLine("任务已经完成了 。。。。。。");
            }

            //ThreadPool.QueueUserWorkItem();



            //线程完成回调 
            //回调 启动子线程执行动作 A  - 不阻塞 - A 执行完后子线程会调用 动作 B  
            {
                ThreadCallBacak(() => { Console.WriteLine("a"); }, () => { Console.WriteLine("b"); });
            }



            //线程异步 不阻塞 有返回值
            {
                var fun = ThreadWithReturnGZ(() =>
                {
                    Thread.Sleep(2000);
                    return DateTime.Now.Year;
                });

                fun.Invoke(); //需要结果进行阻塞 获得返回结果
            }


            {
                //Thread thread = new Thread(() => { Console.WriteLine(); });

                //thread.ThreadState;
            }


            //ThreadPool.GetMaxThreads();
        }

        /// <summary>
        /// 线程池
        /// </summary>
        public static void SixExercise()
        {
            //线程池 
            {
                Debug.WriteLine($"One 主 线程 Start:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                //ThreadStart thread = () =>
                //{
                //    Console.WriteLine($"One 后台 线程 Start:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                //    Thread.Sleep(3000);
                //    Console.WriteLine("1");
                //    Console.WriteLine($"One 后台 线程 End:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                //};

                //Thread thread1 = new Thread(thread);
                //thread1.IsBackground = true;
                //thread1.Start();

                ManualResetEvent manualResetEvent = new ManualResetEvent(false);

                ManualResetEvent manualResetEvent1 = new ManualResetEvent(false);

                //线程池委托
                WaitCallback waitCallback = (c) =>
                {
                    Debug.WriteLine($"One 后台 线程 Start:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    Thread.Sleep(3000);
                    Console.WriteLine(c);
                    Debug.WriteLine($"One 后台 线程 End:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    manualResetEvent.Set();
                };

                WaitCallback waitCallbacks = (c) =>
                {
                    Debug.WriteLine($"One 后台 线程 Start:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    Thread.Sleep(3000);
                    Console.WriteLine(c);
                    Debug.WriteLine($"One 后台 线程 End:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    manualResetEvent1.Set();
                };

                //线程池任务等待

                ThreadPool.QueueUserWorkItem(waitCallback, "昔日");
                ThreadPool.QueueUserWorkItem(waitCallbacks, "西蒙");

                Debug.WriteLine("DO SOME TINGING.......");
                Debug.WriteLine("DO SOME TINGING.......");
                Debug.WriteLine("DO SOME TINGING.......");

                //线程池等待
                WaitHandle.WaitAll(new ManualResetEvent[] { manualResetEvent, manualResetEvent1 });

                Debug.WriteLine("任务已经完成了 。。。。。。");

                Debug.WriteLine($"One 主 线程 End:{Thread.CurrentThread.GetHashCode()}_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                //获取电脑当前最大线程数量 最大 I/O 线程数量
            }

            //ThreadPool.thread
            //设置线程池数量是进程全局的
            //委托异步调用  - task - parrallel - async 全部是 线程池
            //直接 new thread（不是走线程池的） 不受这个数量限制的（但是会占用线程池的线程数量）
            //获取线程池数量
            {
                ThreadPool.GetMaxThreads(out int maxWorkThreads, out int completionPortThreads);
                Console.WriteLine($"线程池中辅助线程的最大数目:{maxWorkThreads}, 线程池中异步 I/O 线程的最大数目{completionPortThreads}");

                ThreadPool.GetMinThreads(out int maxWorkThreadsMin, out int completionPortThreadsMin);

                Console.WriteLine($"线程池中辅助线程的最小数目:{maxWorkThreadsMin}, 线程池中异步 I/O 线程的最小数目{completionPortThreadsMin}");
            }
            //设置线程池数量
            {
                ThreadPool.SetMaxThreads(4, 4);  //设置最大线程数量 必须大于cpu 核数

                ThreadPool.SetMinThreads(2, 2);

                ThreadPool.GetMaxThreads(out int maxWorkThreads, out int completionPortThreads);
                Console.WriteLine($"线程池中辅助线程的最大数目:{maxWorkThreads}, 线程池中异步 I/O 线程的最大数目{completionPortThreads}");

                ThreadPool.GetMinThreads(out int maxWorkThreadsMin, out int completionPortThreadsMin);

                Console.WriteLine($"线程池中辅助线程的最小数目:{maxWorkThreadsMin}, 线程池中异步 I/O 线程的最小数目{completionPortThreadsMin}");
            }
        }

        string this[int inex]
        {
            get { return "1"; }
        }
    }
}
