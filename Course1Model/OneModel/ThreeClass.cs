using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Course1Model.OneModel
{
    public class ThreeClass
    {
        public static T Get<T>(T obj)
            //where  T :struct  值类型
            //where T : new()  无参数构造函数 
            where T :class,new() //引用类型约束
            //where T : A // 基类约束
            //where T:B //接口约束
        {
            //var a=default(string);
            //var b = default(int);
            //var c = default(long);

            var c = new T();

            return default(T);
        }

        public void Name<T>()
            where T :A,B 
        {
            dynamic d = "123";
        }

        public void OneName() 
        {
            Name<C>();
        }
        
    }

    public class A 
    {
        public static void Name<T>(T obj)where T: AA,new ()
        {
        
        }

        public static void cc() 
        {
            Name<BB>(new BB());
        }
    }

    public interface B { }

    public class C : A, B { }

    public interface AAA 
    {
        void L();
    }

    public interface BBB 
    {
        void L();
    }

    public class CCC : AAA, BBB
    {
        public void L()
        {
            throw new NotImplementedException();
        }
    }

    public class AA
    {
        //public AA() { }

        //public AA(int a) { }
    }

    public class BB:AA 
    {
        public BB() { }

        public BB(int a) { }
    }
}
