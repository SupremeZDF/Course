using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Course05.Model.Model
{
    public class Model
    {
        private static readonly object Lock = new object();

        public static void Name()
        {
            lock (Lock)
            {
                Thread.Sleep(2000);

                Names();
            }
        
        }

        public static void Names() 
        {
            var code = Thread.CurrentThread.GetHashCode();
            Console.WriteLine(code);
            code = Thread.CurrentThread.GetHashCode();
            Console.WriteLine(code);
            code = Thread.CurrentThread.GetHashCode();
            Console.WriteLine(code);
        }
    }
}
