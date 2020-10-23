using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Course2.Model.BaseModel
{
    public class JsonConfig
    {
        private static IConfigurationBuilder _Configuration;

        static JsonConfig()
        {
            //var cc=Microsoft.Extensions.Configuration.FileConfigurationExtensions()

            _Configuration = new ConfigurationBuilder();
            //IConfiguration
        }

        public  void name() 
        {

        }
    }
}
