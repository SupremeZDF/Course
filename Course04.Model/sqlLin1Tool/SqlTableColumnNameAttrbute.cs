using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.sqlLin1Tool
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =true,Inherited =true)]
    public class SqlTableColumnNameAttrbute:Attribute
    {
        public SqlTableColumnNameAttrbute() 
        {
        
        }
        
        public string ColumnName { get; set; }

        public bool isPrikey { get; set; }

        public bool Identity { get; set; }
    }
}
