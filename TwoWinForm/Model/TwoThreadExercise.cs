using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
        public static void OneTaskExercse() 
        {
            //1
            {
                ThreadPool.SetMaxThreads(8, 8);

                //线程池是单列的 ， 全局唯一的 进程（项目） 唯一的
                //设置后， 同时并发的 Task 的只用 8 个 ，而且线程是复用的 线程 ID 是重复的
                //Task 的 线程 是源于 线程池
                //进程 （项目） 全局的

                //Task task = new Task(()=> { });


                Task.Delay();
            }
        }
    }
}
