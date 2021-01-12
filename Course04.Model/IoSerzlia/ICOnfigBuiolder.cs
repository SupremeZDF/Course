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
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",true,true).Build();
        }

        public static IConfiguration GetConfigBuilder() 
        {
            return Configuration;
        }
    }
}
