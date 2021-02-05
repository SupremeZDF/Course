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
               
               

                //Task task = new Task(()=> { });


                //Thread thread = new Thread(()=> { });


                //Task.Run(()=> { }).ContinueWith();

                //Task task = new Task().ContinueWith();

                //Task.Delay(2000).ContinueWith;
            }

            //ThreadPool.SetMaxThreads(8, 8);

            //线程池是单列的 ， 全局唯一的 进程（项目） 唯一的
            //设置后， 同时并发的 Task 的只用 8 个 ，而且线程是复用的 线程 ID 是重复的
            //Task 的 线程 是源于 线程池
            //进程 （项目） 全局的

            {
                //Stopwatch stopwatch = new Stopwatch();

                //stopwatch.Start();

                //TaskFactory taskFactory = new TaskFactory();

                // taskFactory.ContinueWhenAll();

                //Debug.WriteLine("Start: 开始了");

                //Task.Delay(2000).ContinueWith((t) => 
                //{
                //    stopwatch.Stop();
                //    Debug.WriteLine($"耗时{stopwatch.ElapsedMilliseconds}");
                //    Debug.WriteLine(t);
                //    Debug.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString("00"));
                //});

                //Debug.WriteLine("Start: 结束了");
            }

            {
                //ThreadPool.SetMaxThreads(8, 8);

                //for (var i = 0; i < 100; i++) 
                //{
                //    int k = i;
                //    Task.Run(() => 
                //    {
                //        Thread.Sleep(1000);
                //        Debug.WriteLine($"完成 __ {Thread.CurrentThread.ManagedThreadId}");
                //    });
                //}
            }

            {
                //Task.Delay(2000);
                //TaskFactory taskFactory = new TaskFactory();
                //taskFactory

                TaskFactory taskFactory = new TaskFactory();

                List<Task> tasks = new List<Task>();

                taskFactory.StartNew(() =>
                {
                    OneRun("1", "1");
                });

                taskFactory.StartNew(() =>
                {
                    OneRun("1", "1");
                });

                taskFactory.StartNew(() =>
                {
                    OneRun("1", "1");
                });

                taskFactory.StartNew(() =>
                {
                    OneRun("1", "1");
                });
            }
        }

        public static void OneRun(string name , string Name) 
        {
            Console.WriteLine($"线程ID：{Thread.CurrentThread.ManagedThreadId}. Name {name}  Work  {Name} ");
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
