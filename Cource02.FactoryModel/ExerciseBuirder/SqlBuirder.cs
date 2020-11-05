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
                |BindingFlags.Instance).Where(c=>c.GetCustomAttribute(typeof(ORMTableToolAttribute))==null
                ||(c.GetCustomAttribute(typeof(ORMTableToolAttribute)) as ORMTableToolAttribute).Identity==false);

            var cloumn = string.Join(',',propers.Select(c => $"[{c.Name}]"));

            var value = string.Join(',', propers.Select(c => $"@{c.Name}"));

            var tableName = typeof(T).Name;
            var attrbute = typeof(T).GetCustomAttribute(typeof(ORMTableToolAttribute)) as ORMTableToolAttribute;
            if (attrbute != null && attrbute.TableName != "")  
            {
                tableName = attrbute.TableName;
            }
            AddString = $@"insert into {tableName}({cloumn}) values({value})";
            FindAllSql();
        }

        public static void FindAllSql() 
        {
            Type ty = typeof(T);
            var propers = ty.GetProperties(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly);
            var tableName = ty.Name;
            var ormtableattbute = ty.GetCustomAttribute(typeof(ORMTableToolAttribute)) as ORMTableToolAttribute;
            if (ormtableattbute != null) 
            {
                if (ormtableattbute.TableName != "") 
                {
                    tableName = ormtableattbute.TableName;
                }
            }
            FindAllstring = $"select {string.Join(',',propers.Select(c=>c.Name))} from {tableName}";
        }

        public static void Name() 
        {
        
        }
    }
}
