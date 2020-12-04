using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Course04.Model.Model
{
    public class TwoDelegate
    {
        public  delegate void NoneReturn();

        //事件权限 只能在内部调用 private
        public static event NoneReturn aa;

        public static Func<int> Func;

        public   Action cc;

        public delegate int HaveReturn(ref int a);

        public delegate void NoneReturnHandle( int a); // 类 委托类型继承于 DELEGATE

        //事件  固定动作、可变动作分开 完成固定动作 可变动作分离出去
        public  event HaveReturn have;

        public event NoneReturnHandle returnHandle;

        public TwoDelegate() 
        {
        
        }

        static TwoDelegate() 
        {
          
        }



        public  void twoRun()
        {
            //var c = this.GetHashCode();
            //EventHandler
            //var s = have;
            //returnHandle = this.Onetest;
            returnHandle += TwoTest;
            returnHandle += threeTest;
            //var i = 1;
            //returnHandle.Invoke(i);
            foreach (NoneReturnHandle item in returnHandle.GetInvocationList()) 
            {
                //var i = typeof(int);
                //var d = Activator.CreateInstance(i);
                //var ii = i.GetMethod("");
                //ii.Invoke(i,new object[] { });
                var i = this;
                item.Invoke(1);
                //for (var i = 0; i < 100; i++) 
                //{
                //    var w = 1;
                //}
            }
        }


        public int Onetest(int i) 
        {
            i = i + 1;
            return i;
        }

        public void TwoTest(int i)
        {
            i = i + 1;
        }

        public static void  threeTest( int i) 
        {
            i = i + 1;
        }

        public void fourTest() 
        {
        
        }

        public void ii() { }

        /// <summary>
        /// 内部方法 固定的方法
        /// </summary>
        public void ivwardAction(int i) 
        {
            Console.WriteLine("1");
            returnHandle?.Invoke(i);
        }
    }

    /// <summary>
    /// 外部事件方法 不固定方法 适合用事件 
    /// </summary>
    public class threeDelegate 
    {
        public int Onetest(int i)
        {
            i = i + 1;
            return i;
        }

        public void TwoTest(int i)
        {
            i = i + 1;
        }

        public static void threeTest(int i)
        {
            //var s = this;
            i = i + 1;
        }

        public void fourTest()
        {

        }
    }

    public class OneInterface 
    {
    
    }

    public class fourDelegate : OneInterface
    {
      
        public void OneRun() 
        {
            threeDelegate three = new threeDelegate();
            TwoDelegate a = new TwoDelegate();

            //TwoDelegate.aa += a.TwoTest;
            //TwoDelegate.aa = null;
            a.returnHandle += three.TwoTest;

            a.ivwardAction(1);
        }
    }
}
