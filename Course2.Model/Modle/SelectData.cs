using System;
using System.Collections.Generic;
using System.Text;

namespace Course2.Model.Modle
{
    public class SelectData
    {
        //数据
        public List<SelectReslut> results { get; set; }

        //分页
        public mores pagination { get; set; }

        //页数
        public int total_Count { get; set; }
    }
}
