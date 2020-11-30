using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.Model
{
    public delegate void NonReturnNoparaOutClass();
    public class OneDeleggate
    {
        //委托 IL(中间语言) 是一个类
        // 委托继承 MulticastDelegate 
        public delegate void NonReturnPara();
        public delegate void NonReturnWithPara();
        public delegate void withRetrunPara();
        public delegate OneDeleggate withReturnWithPara(out int x, ref int y);

        public static void twoRun(string a, NonReturnWithPara b) 
        {
            try
            {
                //公共逻辑 代码重用 
                Console.WriteLine("");
                //业务逻辑
                //解耦 委托 
                b.Invoke();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void America() 
        {
            
        }

        public void Run()
        {
            //var ty = typeof(int);
            ////ty.GetConstructor;
            ////ty.GetProperties();
            //var dd = Activator.CreateInstance(ty);
            //var c = ty.GetMethod("");
            //c.Invoke(dd,new object[]{ 1,23,4});

            NonReturnPara nonReturnPara = new NonReturnPara(this.OneDelegate);
            nonReturnPara.Invoke();
            nonReturnPara.BeginInvoke(null, null);  //启动一个线程完成计算
            nonReturnPara.EndInvoke(null);
        }

        //
        public void OneDelegate() 
        {
            
        }
    }

    public class OneRunA 
    {
     
    }
}
