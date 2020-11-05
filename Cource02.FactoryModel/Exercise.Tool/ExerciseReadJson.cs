using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Cource02.FactoryModel.Exercise.Tool
{
    public class ExerciseReadJson
    {
        private static IConfiguration configuration;

        private ExerciseReadJson() 
        {
        
        }

        /// <summary>
        /// 设置读取配置文件
        /// </summary>
        static ExerciseReadJson() 
        {
            configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("ConfigEF.json",true,true).Build();
        }

        /// <summary>
        /// 获取配置 json 文件
        /// </summary>
        /// <returns></returns>
        public static IConfiguration GetConfiguration() 
        {
            return configuration;
        }
    }
}
