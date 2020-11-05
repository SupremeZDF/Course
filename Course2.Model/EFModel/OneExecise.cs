using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Course2.Model.EFModel
{
    public class OneExecise
    {
        public static void Run() 
        {
            //Course2.Model
            var basetype = Assembly.GetExecutingAssembly();
            var cc = Assembly.GetExecutingAssembly().GetType("");
            //cc.make
        }
    }
}
