using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TwoWinForm.Model
{

    //public struct Daru 
    //{
    //    public int ID ;

    //    public string Name { get; set; }

    //    public Daru(int a) 
    //    {
    //        ID = 1;
    //        Name = "212";
    //    }

    //    public void Names(int id, string name) { ID = id; Name = name; }
    //}

    public interface Name
    {
        void Name();

        string Dome { get; set; }

        string this[int i] { get; set; }
    }

    public class ThreThreadExercise
    {
        //线程服务 
        //线程 捕获异常
        public static void OneThreadExercise()
        {

            //try
            //{
            //    int iii = 1;

            //    if (iii == 1)
            //    {
            //        throw new Exception("异常");
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}

            //Daru daru;
            // 1 多线程异常
            {
                try
                {
                    Debug.WriteLine($"Start CurrThreadID {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                    List<Task> task = new List<Task>();

                    for (int i = 0; i < 100; i++)
                    {
                        string Name = $"Name _{i}";
                        task.Add(Task.Run(() =>
                        {
                            try
                            {
                                if (Name == "Name _11")
                                {
                                    throw new Exception("111111");
                                }

                                if (Name == "Name _33")
                                {
                                    throw new Exception("3333333");
                                }

                                if (Name == "Name _55")
                                {
                                    throw new Exception("555555");
                                }

                                Thread.Sleep(1000);
                                Console.WriteLine($"this is Name {Name} ,This is CurrThreadid  {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                            }
                            catch (Exception ex)
                            {

                            }
                        }));
                    }

                    Task.WaitAll(task.ToArray());  //等待结果 并获取线程异常 

                    Debug.WriteLine($"End CurrThreadID {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                }

                //多线程里面的异常 ，会终结当前线程 不会影响别的线程
                // 线程异常跑哪里了 被吞了
                // 获取异常信息 还需要通知别的线程
                catch (AggregateException agrex)
                {
                    foreach (var i in agrex.InnerExceptions)
                    {
                        Debug.WriteLine(i.Message);
                    }
                }

                //可以 多 catch  先具体 - 全部
                catch (Exception ex)
                {

                }
                // 线程异常后 经常 是需要通知别的线程 而不是等待 WaitAll 问题就是要 线程取消
                //工作中  常规建议 多线程委托里 不允许异常 ，包一层 Try - Catch  然后记录下异常信息
            }
        }

        /// <summary>
        /// 线程 异常 取消线程
        /// </summary>
        //线程取消
        public static void TwoThreadRunExercise()
        {
            //2 线程取消
            {

                //Thread thread = new Thread(() =>
                //{
                //    try
                //    {
                //        Debug.WriteLine("1231321");
                //        Thread.Sleep(1000);
                //        Debug.WriteLine("1231321");
                //    }
                //    catch (Exception ex)
                //    {
                //        Debug.WriteLine(ex.Message);
                //    }
                //});
                //thread.Start();

                //thread.Abort();  //

                //准备 cts 2 try - catch -cancel  3 action 要随时判断 IsCancellationRequested 
                //尽快停止 肯定有延迟  判断环节取消
                // 如果线程 没有启动 直接取消掉
                try
                {

                    //多线程并发任务  ， 某个失败后 希望通知别的线程  都停下来  ， how？
                    //  Thread.Abort 终止线程 ： 向当前线程 抛一个异常 然后 终结任务
                    //线程安全
                    //CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                    //传达取消请求。
                    //cancellationTokenSource.Cancel();

                    //var cancelBool = cancellationTokenSource.IsCancellationRequested;

                    //cancellationTokenSource.Cancel(false);
                    //var cancelTrue = cancellationTokenSource.IsCancellationRequested;


                    //CancellationToken cancellationToken = cancellationTokenSource.Token;



                    //CancellationToken.None

                    List<Task> tasks = new List<Task>();

                    Debug.WriteLine($"Start CurrThreadID {Thread.CurrentThread.ManagedThreadId.ToString("00")}");


                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                    for (int i = 0; i < 50; i++)
                    {
                        string Name = $"Name _{i}";
                        tasks.Add(Task.Run(() =>
                        {

                            try
                            {
                                Thread.Sleep(new Random().Next(500, 1000));
                                if (Name == "Name _11")
                                {
                                    throw new Exception("111111");
                                }

                                if (Name == "Name _33")
                                {
                                    throw new Exception("3333333");
                                }

                                if (Name == "Name _55")
                                {
                                    throw new Exception("555555");
                                }

                                if (cancellationTokenSource.IsCancellationRequested == true)
                                {
                                    Debug.WriteLine("任务已被取消");
                                    return;
                                }
                                Console.WriteLine($"this is Name {Name} ,This is CurrThreadid  {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                            }
                            catch (Exception ex)
                            {
                                //取消请求
                                cancellationTokenSource.Cancel();
                            }
                            //CancellationTokenSource 如果 cancel() 以后，还没有启动后的线程 就不会启动了 ，也就是抛异常 （已取消一个任务）
                            //cancellationTokenSource.Token.ThrowIfCancellationRequested
                        }, cancellationTokenSource.Token));
                    }

                    Task.WaitAll(tasks.ToArray());  //等待结果 并获取线程异常  


                    Debug.WriteLine($"End CurrThreadID {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                }
                catch (AggregateException agrex)
                {
                    foreach (var i in agrex.InnerExceptions)
                    {
                        Debug.WriteLine(i.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ThreeThreadExercise()
        {

            //var i = 1;
            //var u = i++;
            //var j = i;
            //j = ++i;

            //for (var i = 0; i < 100; i++)
            //{

            //}

            Debug.WriteLine("Start");

            //1 临时变量
            {
                //临时变量问题  线程是非阻塞的  延迟启动的 ， i 已经是 5 了 
                for (var i = 0; i < 100; i++)
                {
                    //Thread.Sleep(100);
                    Task.Run(() =>
                    {
                        //lock (DD)
                        //{

                        Debug.WriteLine($"");
                        Debug.WriteLine($"线程变量的问题{i}  ___ CurrThread_{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                        //}
                    });
                }
            }

            // 2  线程安全  ( lock ) : 如果你代码 在进程中 被多个线程 同时运行 如果每次运行的结果 跟 单线程的结果一致  那么 线程是安全的  
            //    线程 安全问题 一般都是有 全局变量 共享变量  静态变量  硬盘文件 数据库得数据  只要多线程访问和修改

            //  多个线程同时进行操作 导致进行重复操作
            {

            }

            Debug.WriteLine("End");
        }


        public void OneName()
        {

            for (var j = 0; j < 5; j++)
            {
                lock (DD)
                {
                    Thread.Sleep(4000);

                    Debug.WriteLine($"{j}____{DD?.GetHashCode()}");
                }

            }
        }

        public void TwoName()
        {

            for (var j = 0; j < 5; j++)
            {
                lock (DD)
                {
                    Thread.Sleep(4000);

                    Debug.WriteLine($"TwoName_{j}____{DD?.GetHashCode()}");
                }
            }
        }


        private  object DD = new object();

        public static int DS { get; set; }
    }
}
