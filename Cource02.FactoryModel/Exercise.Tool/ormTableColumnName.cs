using System;
using System.Collections.Generic;
using System.Text;

namespace Cource02.FactoryModel.Exercise.Tool
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class ormTableColumnNameAttribute : Attribute
    {
        public ormTableColumnNameAttribute() 
        {
           
        }

        public bool isPrimarky { get; set; }

        public bool Identity { get; set; }

        public string ParameterName { get; set; }
    }
}
