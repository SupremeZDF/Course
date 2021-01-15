using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Course04.Model.IoSerzlia
{
    public class ICOnfigBuiolder
    {
        public static IConfiguration Configuration;

        static ICOnfigBuiolder() 
        {
            var a = Directory.GetCurrentDirectory();
            var b = AppDomain.CurrentDomain.BaseDirectory;
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("json.json", true,true).Build();
        }

        public static IConfiguration GetConfigBuilder() 
        {
            return Configuration;
        }

        public static int OneDG(int n) 
        {
            if (n > 0)
            {
                return 1;
            }
            return n + OneDG(n - 1);
        }

        /// <summary>
        /// 27 45
        /// 45 %27 = 1    18
        /// 27%18 = 1      9
        /// 18 % 9 = 2     0
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int UU(int a,int b) 
        {
            if (b == 0) { return a; }
            return UU(b,a%b);
        }
    }
}
