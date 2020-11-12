using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Course03.Model.Model
{
    public class OneExercise
    {
        public static void Run() 
        {
            OneModel model = new OneModel();
            model["Name"] = "123";
            model["Password"] = "123";

            var name = model["Name"];
            var password = model["Password"];
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        public static void TwoRun() 
        {
            ThreeModel model = new ThreeModel();
            model["张三", 1] = 12;
            model["张三", 2] = 13;
            model["张三", 3] = 14;
            model["李四", 4] = 15;
            model["王二", 5] = 16;

            var d = model["张三", 2];

            var f = model["张三"];
        }
    }
}
