using System;
using System.Collections.Generic;
using System.Text;

namespace Cource02.FactoryModel.Exercise.Tool
{
    public class Result<T>
    {
        public int code { get; set; }

        public string message { get; set; }

        public T @object { get; set; }
    }

    public class Result
    {
        public int code { get; set; }

        public string message { get; set; }

        public dynamic @object { get; set; }
    }
}
