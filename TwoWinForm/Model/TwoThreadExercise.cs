using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace TwoWinForm.Model
{
    public class TwoThreadExercise
    {
        //为什么 可以使用多个线程
        //1 多个 Cpu 的核 可以并行工作,多个模拟线程
        //4核8线程 线程指模拟核

        // cpu 分片 1s 的处理能力 分为 1000份 ，系统调度着去响应不同的任务
        // 宏观角度来说 就是多个任务并发执行
        // 微观角度 一个物理cpu同一时刻只能为一个任务服务


        //task netframework 3.0 出现的  线程是基于线程池的，提供了丰富的 API
        // 
        public async static void OneTaskExercse()
        {



            //1
            {



                Task task = new Task(() => { });


                Thread thread = new Thread(() => { });


                //Task.Run(() => { }).ContinueWith();

                //Task task = new Task().ContinueWith();

                //Task.Delay(2000).ContinueWith;
            }

            //ThreadPool.SetMaxThreads(8, 8);

            //线程池是单列的 ， 全局唯一的 进程（项目） 唯一的
            //设置后， 同时并发的 Task 的只用 8 个 ，而且线程是复用的 线程 ID 是重复的
            //Task 的 线程 是源于 线程池
            //进程 （项目） 全局的

            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                TaskFactory taskFactory = new TaskFactory();

                taskFactory.ContinueWhenAll(null, c => { });

                Debug.WriteLine("Start: 开始了");

                Task.Delay(2000).ContinueWith((t) =>
                {
                    stopwatch.Stop();
                    Debug.WriteLine($"耗时{stopwatch.ElapsedMilliseconds}");
                    Debug.WriteLine(t);
                    Debug.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString("00"));
                });

                Debug.WriteLine("Start: 结束了");
            }

            {
                ThreadPool.SetMaxThreads(8, 8);

                for (var i = 0; i < 100; i++)
                {
                    int k = i;
                    Task.Run(() =>
                    {
                        Thread.Sleep(1000);
                        Debug.WriteLine($"完成 __ {Thread.CurrentThread.ManagedThreadId}");
                    });
                }
            }

            {
                Task.Run(() => DateTime.Now).ContinueWith(
                    c =>
                    {
                        Debug.WriteLine("dedaewdawd" + Newtonsoft.Json.JsonConvert.SerializeObject(c.Result));
                    });
            }

            {
                //Task.Delay(2000);
                //TaskFactory taskFactory = new TaskFactory();
                //taskFactory

                Debug.WriteLine("线程 Start");

                TaskFactory taskFactory = new TaskFactory();

                List<Task> tasks = new List<Task>();


                tasks.Add(taskFactory.StartNew((c) =>
                {
                    OneRun("1", "1");
                }, "1"));

                tasks.Add(taskFactory.StartNew((c) =>
                {
                    OneRun("2", "2");
                }, "2"));

                tasks.Add(taskFactory.StartNew((c) =>
                {
                    OneRun("3", "3");
                }, "3"));

                tasks.Add(taskFactory.StartNew((c) =>
                {
                    OneRun("4", "4");
                }, "4"));


                //Task task = new Task();


                //非阻塞式回调  而且使用的线程 可能是新线程  也可能是 刚完成任务的线程 唯一不可能是主线程
                taskFactory.ContinueWhenAny(tasks.ToArray(), c => Console.WriteLine($"第一个完成，继续完任务_{c.AsyncState}"));

                //延续任务 创建的 一个任务  task 延续任务
                //taskFactory.ContinueWhenAll(tasks.ToArray(), c => { Console.WriteLine("完成了"); });

                //延续任务 后台线程
                tasks.Add(taskFactory.ContinueWhenAll(tasks.ToArray(), c => { Console.WriteLine("完成了"); }));

                //阻塞回调
                Task.WaitAny(tasks.ToArray());

                Console.WriteLine("123121");

                //Task.WaitAny();

                Task.WaitAll(tasks.ToArray());

                Debug.WriteLine("线程 End");
            }
        }



        public static void OneRun(string name, string Name)
        {
            Thread.Sleep(2000);
            Debug.WriteLine($"线程ID：{Thread.CurrentThread.ManagedThreadId}. Name {name}  Work  {Name} ");
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ThreeTaskExercise()
        {
            //2 控制 并发线程 在 20 以内 
            {
                //new List<int>().Where();
                //List<Task> tasks = new List<Task>();
                //for (var i = 0; i < 100; i++) 
                //{
                //    if (tasks.Count(j => j.Status != TaskStatus.RanToCompletion) >= 20) 
                //    {
                //        Task.WaitAny(tasks.ToArray());
                //        tasks = tasks.Where(j => j.Status != TaskStatus.RanToCompletion).ToList();
                //    }
                //    tasks.Add(Task.Run(() => 
                //    {
                //        Thread.Sleep(200);
                //        Console.WriteLine("");
                //    }));
                //}
            }

            //并发 任务
            {

                //Parallel 并发执行多个Action 多线程
                //主线程 会参与 计算 - 阻塞界面
                //等于 TaskWaitAll + 主线程计算
                ///Console.WriteLine("Start");

                //Parallel.Invoke(() =>
                //{
                //    OneRun("1", "1");
                //},
                //    () => { OneRun("2", "2"); },
                //    () => { OneRun("3", "3"); },
                //    () => { OneRun("4", "4"); },
                //    () => { OneRun("5", "5"); }
                //    );


                //Parallel.For(0, 6, i => {  Console.WriteLine($"dadasd___{i},cuurid_{Thread.CurrentThread.ManagedThreadId.ToString("00")}"); });

                //Parallel.ForEach(new int[] { 1,2,3,4,5,6},c=> {Thread.Sleep(2000); Console.WriteLine($"dadasd___{c},cuurid_{Thread.CurrentThread.ManagedThreadId.ToString("00")}"); });

                //Parallel.For();

                //Console.WriteLine("End");
            }

            //控制线程并发数目
            {
                Console.WriteLine("Start");
                Task.Run(()=> 
                {
                    //设置线程 最大 并发数目 
                    ParallelOptions parallelOptions = new ParallelOptions();

                    parallelOptions.MaxDegreeOfParallelism = 8;

                    Parallel.For(0, 100, parallelOptions, i => { Thread.Sleep(2000); Console.WriteLine($"dadasd___{i},cuurid_{Thread.CurrentThread.ManagedThreadId.ToString("00")}"); });
                });

                Console.WriteLine("End");
            }

            //1
            {
                IEnumerable<int> ts = new List<int> { };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void TwoTaskExercise()
        {
            // task.WaitAll 都是阻塞当前线程， 等线程完成后执行 
            // 阻塞卡界面 是为了开发以及顺序控制
            //网站首页 A数据库 B接口 C分布式服务 D搜索引擎 适合多线程开发 都完成以后才返回给用户 需要要等待 WaitAll 
            //列表页，核心数据可能来自数据库/分布式引擎/缓存 ，多线程并发请求，那个先完成就用那个 结果 ，其他的就不管了
        }
    }
}
