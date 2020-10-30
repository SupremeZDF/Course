using System;
using System.Collections.Generic;
using System.Text;

namespace Course2.Model
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class EFTableAttribute :Attribute
    {

        public EFTableAttribute() 
        {
        
        }

        public string TableName { get; set; }
    }
}
