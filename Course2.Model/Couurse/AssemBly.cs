using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Course2.Model.Couurse
{
    public class AssemBly
    {
        public static void GetAssemBly()
        {
            Assembly assembly = Assembly.Load("Course02.API");

            var a = assembly.GetTypes();

            var b = assembly.GetType("Course02.API");
            //获取并创建石烈
            dynamic mic = Activator.CreateInstance(b);

            var c = mic as DD;

            //idhelper
        }
    }

    public class DD
    {
        public void dd() 
        {
        
        }
    }
}
