using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.sqlLin1Tool
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true,Inherited = true)]
    public class SqlTableNameAttribute : Attribute
    {
        public SqlTableNameAttribute() 
        {
        
        }

        public string TableName { get; set; }
    }
}
