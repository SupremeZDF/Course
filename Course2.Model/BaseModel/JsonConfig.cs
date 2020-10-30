using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Course2.Model.BaseModel
{
    public class JsonConfig
    {
        private static IConfiguration _Configuration;

        private JsonConfig() 
        {
        
        }

        static JsonConfig()
        {
            //var cc=Microsoft.Extensions.Configuration.FileConfigurationExtensions()

            _Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfigEF.json", optional: true, reloadOnChange: true)
                .Build();
            //IConfiguration
        }

        public static  IConfiguration jsonConfigRead() 
        {
            return _Configuration;
        }
    }
}
