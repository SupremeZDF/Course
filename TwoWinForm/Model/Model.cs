using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TwoWinForm.Model
{
    public class Model
    {
        private static readonly object Lock = new object();

        public static void Name() 
        {
            lock (Lock) 
            {
                //Thread.Sleep(1000);
                var code = Thread.CurrentThread.GetHashCode();
                Console.WriteLine(code);
            }
        }
    }
}
