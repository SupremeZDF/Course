using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Cource02.FactoryModel.Exercise.Tool
{
    public static class ExtendORMGetModleName
    {
        public static string GetTableClassName(this Type property) 
        {
            if (property.IsDefined(typeof(ORMTableToolAttribute),true))
            {
                foreach (ORMTableToolAttribute i in property.GetCustomAttributes(typeof(ORMTableToolAttribute))) 
                {
                    return i.TableName;
                }
                return property.Name;
            }
            else 
            {
                return property.Name;
            }
        }

        public static string GetTableColumn(this PropertyInfo property) 
        {
            if (property.IsDefined(typeof(ormTableColumnNameAttribute)))
            {
                foreach (ormTableColumnNameAttribute i in property.GetCustomAttributes(typeof(ormTableColumnNameAttribute)))
                {
                    return i.ParameterName;
                }
                return property.Name;
            }
            else
            {
                return property.Name;
            }
        }
    }
    }
}
