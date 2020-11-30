using System;
using System.Collections.Generic;
using System.Text;

namespace Cource02.FactoryModel.Exercise.Tool
{
    [AttributeUsage( AttributeTargets.All,AllowMultiple =true,Inherited =true)]
    public class ORMTableToolAttribute : Attribute 
    {
        public ORMTableToolAttribute() 
        {
        
        }

        public string TableName { get; set; }
    }
}
