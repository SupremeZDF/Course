using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course1Model
{
    public class OneClass
    {
        /// <summary>
        /// 显示值 
        /// </summary>
        /// <param name="value"></param>
        public static void ShowObject(object value)
        {
            //var a = typeof(OneClass);
            //var b = value.GetType().Name;
            ////value.GetType().GetProperty().na
            //var c = value;
        }

        //public OneClass() { }

        /// <summary>
        /// 装箱 拆箱
        /// Object 在堆里面
        /// 值类型在 堆里面
        /// 把int 值 传入Object里面 会把值从栈Copy到堆里面
        /// </summary>
        public static void ZCObject()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        //public static void Show<T>(T tParameter)  
        //{
        //    var c = typeof(List<>);
        //    var d = typeof(Dictionary<,>);
        //}

        //设计思想-延迟声明，推迟一切可以推迟的，一切能晚点再做的事儿，就晚点在做

        //泛型原理
        // c#高级语言  ->  编译器编译  ->  DLL/EXE(IL（中间语言）/METADATA) -> CLR（公共语言运行库）/JIT->机器码

        /// <summary>
        /// 性能测试
        /// </summary>
        public static void Show()
        {
            int isValue = 12345;
            long comonSecond = 0;
            long objectSecond = 0;
            long genericSecond = 0;
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (var i = 0; i < 100_000_000; i++)
                {
                    //ShowIbnt(isValue);
                }
                stopwatch.Stop();
                comonSecond = stopwatch.ElapsedMilliseconds;  //536
            }
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (var i = 0; i < 100_000_000; i++)
                {
                    ShowObject(isValue);
                }
                stopwatch.Stop();
                objectSecond = stopwatch.ElapsedMilliseconds;    //1162
            }
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (var i = 0; i < 100_000_000; i++)
                {
                    Show<int>(isValue);
                }
                stopwatch.Stop();
                genericSecond = stopwatch.ElapsedMilliseconds;  //481 
            }
        }

        public static void ShowIbnt(int isParameter, object name)
        {
            int c = (int)name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iParameter"></param>
        public static void Show<T>(T iParameter)
        {
            Newtonsoft.Json.JsonConvert.SerializeObject("");
        }

        //public static void ShowObjects(object oParameter) 
        //{

        //}
    }

    public class A<T> { }

    public interface C<S>
    {
        //public int CC{ get; set; }
        //int cc { get; set; }
        //int ccc;
    }

    public class B : A<String>, C<int>
    {
        //public int cc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void cc() 
        {
            DD<OneClass> D = new DD<OneClass>();
        }
    }

    public class dd { }


    public class DD<T> where T:class ,new()
    {
      
    }

    public struct Name 
    {
    
    }

    
}
