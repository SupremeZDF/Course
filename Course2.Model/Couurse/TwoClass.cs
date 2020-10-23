using System;
using System.Collections.Generic;
using System.Text;

namespace Course2.Model.Couurse
{
    public class TwoClass
    {

        private static TwoClass twoClass;
        public TwoClass()
        {
            var a = 1;
        }

        //单列模式
        public TwoClass(int a)
        {

        }


        static TwoClass()
        {
            twoClass = new TwoClass();
        }

        public static TwoClass Name()
        {
            return twoClass;
        }

        public void error()
        {
            //dd dds = new dd();
            //Test<dd>(new dd(1));
        }

        public void Test<T>(T s) where T : class,new()
        {
        
        }
    }

    public class dd
    {
        public dd(int i) 
        {
        
        }
    }

    public class GenericClass<A,B,C>
    {
       
    }
}
