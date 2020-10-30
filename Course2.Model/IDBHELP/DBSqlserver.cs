using Course2.Model.BaseModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Course2.Model.EFModel;
using Course2.Model.Couurse;
using System.Reflection;
using System.Data;
using System.Net.Sockets;

namespace Course2.Model.IDBHELP
{
    public class DBSqlserver
    {
        private static IConfiguration configuration;

        private DBSqlserver() { }

        static DBSqlserver()
        {
            configuration = JsonConfig.jsonConfigRead();
        }

        //新增
        public static bool sqlDelete<T>(T t) where T : BaseModel.BaseModel
        {
            if (t == null) { return false; }
            var obj = t.GetType();

            var fileName = "";
            List<string> strArry = new List<string>();
            StringBuilder value = new StringBuilder();
            if (obj.IsClass)
            {
               
                fileName = obj.Name;
                var fileAttbute = obj.GetCustomAttribute(typeof(EFTableAttribute));
                if (fileAttbute != null)
                {
                    EFTableAttribute eFTable = fileAttbute as EFTableAttribute;
                    fileName = eFTable.TableName;
                    //int a = 1;Int32 o = 2;
                }
               
                foreach (var propery in obj.GetProperties())
                {
                    var isGeberic = propery.PropertyType.IsGenericType;
                    var propertys = propery.PropertyType.Name;
                    var dd = propery.PropertyType.GetInterfaces();
                    //Activator.CreateInstance();
                    //获取声明此成员的类
                    var blParent = propery.DeclaringType;

                    if (blParent.Name != obj.Name)
                    {
                        continue;
                    } 
                    //if()
                    var ddd = propery.GetValue(t);
                    if (ddd != null) 
                    {
                        if (value.Length > 0)
                        {
                            value.Append(",");
                        }
                        strArry.Add(propery.Name);
                        value.Append(ddd);
                    }
                }
                //var str
            }
            var str = $"insert into {fileName}({string.Join(',', strArry)} values({value.ToString()}))";
            return false;
        }

        public static bool sqlInsert<T>(T t) where T : BaseModel.BaseModel
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 练习
        /// </summary>
        public static void OneExercise<T>(T OneGeneric)where T:class,new()
        {
            //Assembly assembly = Assembly.Load("");
            //assembly.CreateInstance();
        }

        public static List<T> SqlSelect<T>(T t) where T : BaseModel.BaseModel
        {
            throw new NotImplementedException();
        }

        public static bool sqlUpdate<T>(T t) where T : BaseModel.BaseModel
        {
            throw new NotImplementedException();
        }

        private static bool ExcuteSqlIsbl(string sql)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = configuration["Connection"];
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
                var sqlBegin = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;
                if (sql == "")
                {
                    return false;
                }
                sqlCommand.CommandText = sql;
                sqlCommand.Connection = sqlConnection;
                //sqlCommand.Parameters.Add(new SqlParameter() { });
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
    }
}
