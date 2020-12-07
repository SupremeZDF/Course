using Cource02.FactoryModel.Exercise.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using Cource02.FactoryModel.Exercise.Tool;

namespace Cource02.FactoryModel.ExerciseBuirder
{
    public class SqlBuirder<T> where T: ExerciseBaseModel
    {
         public static  string AddString { get; set; }

        public static string FindAllstring { get; set; }

        static SqlBuirder() 
        {
            var d = typeof(T).GetProperties();
            var a = typeof(T).GetFields();
            var aa = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var aaa = typeof(T).GetProperties(BindingFlags.Public |BindingFlags.Instance|  BindingFlags.DeclaredOnly);
            var aaaa = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Static);

            var propers =typeof(T).GetProperties(BindingFlags.Public|BindingFlags.DeclaredOnly
                |BindingFlags.Instance).Where(c=>c.GetCustomAttribute(typeof(ormTableColumnNameAttribute))==null
                ||(c.GetCustomAttribute(typeof(ormTableColumnNameAttribute)) as ormTableColumnNameAttribute).Identity==false);

            var cloumn = string.Join(',',propers.Select(c => $"[{c.GetTableColumn()}]"));

            var value = string.Join(',', propers.Select(c => $"@{c.GetTableColumn()}"));
            //获取表名
            var tableName = typeof(T).GetTableClassName();
            AddString = $@"insert into {tableName}({cloumn}) values({value})";
            FindAllSql();
        }

        public static string FindAllSql() 
        {
            Type ty = typeof(T);
            var propers = ty.GetProperties(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly);
            var tableName = ty.GetTableClassName();
            FindAllstring = $@"select {string.Join(',',propers.Select
                (c=>
                {
                if (c.GetTableColumn() != c.Name && c.GetTableColumn() != "" && c.GetTableColumn() != null)
                    { 
                        return $"{c.GetTableColumn()} as {c.Name}";
                    }
                    else
                    {
                        return $"{c.Name}";
                    }
                })
                )} from {tableName}";
            return FindAllstring;
        }

        public static void Name() 
        {
        
        }
    }
}
