using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;

namespace Course03.Model.TwoModel
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = true, Inherited = true)]
    public class OneAttrbute : Attribute
    {
        public OneAttrbute()
        {

        }

        public int ID { get; set; }

        public string Name { get; set; }

        public OneAttrbute(int a)
        {

        }

        public string GetName() 
        {
            return Name;
        }

        public OneAttrbute(string a)
        {

        }
    }

    [OneAttrbute(ID =1,Name ="12")]
    public class AAtrbute
    {
        public void Name([OneAttrbute] int name)
        {

        }
    }

    [ OneAttrbute(ID = 2, Name = "33"), OneAttrbute()]
    public class BAtrbute : AAtrbute
    {
        [OneAttrbute]
        public void Age([OneAttrbute][OneAttrbute] int age)
        {

        }
    }


    public class OneAttrbuteRun
    {
        [Description]
        public void Run()
        {
            {
                var a = typeof(BAtrbute);
                var b = a.GetCustomAttributes(typeof(OneAttrbute), false);
                var c = a.GetMethods()[0].GetParameters()[0].GetCustomAttributes(false);
            }

            {
                var a = typeof(BAtrbute);
                var b = a.GetCustomAttributes(true);
                var bb = a.GetCustomAttributes(true);
                var c = a.GetMethods()[0].GetParameters()[0].GetCustomAttributes(true);
            }
        }

        public int AA { get; private set; }
    }



    public class OneA 
    {
        public void SimpleOne() 
        {
            OneAttrbuteRun run = new OneAttrbuteRun();
            var t = run.AA;
            //run.AA = 12;

            var uu = typeof(int);
            //var b = uu.GetFields()[0].IsDefined;
        }
    }
}
