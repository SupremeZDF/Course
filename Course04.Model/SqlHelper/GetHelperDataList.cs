using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using System.IO;
using Course04.Model.Model;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using Course04.Model.sqlLin1Tool;
using System.Reflection;
using System.Text.RegularExpressions;
using Course04.Model.LinqModel;

namespace Course04.Model.SqlHelper
{
    public class GetHelperDataList
    {
        private static IConfiguration Configuration;

        static GetHelperDataList()
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("json.json", true, true).Build();
        }

        public static IConfiguration GetConfiguration()
        {
            return Configuration;
        }

        public static List<T_UserTable> GetlsitUser()
        {
            using (SqlConnection connection = new SqlConnection(Configuration["configstring"]))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "SELECT * FROM  [dbo].[T_User]";
                sqlCommand.Connection = connection;
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);
                return (from i in dataTable.AsEnumerable()
                        select new T_UserTable()
                        {
                            id = i.Field<int?>("id"),
                            Account_Number = i.Field<string>("Account_Number"),
                            User_Name = i.Field<string>("User_Name"),
                            Gender = i.Field<string>("Gender"),
                            Password = i.Field<string>("Password"),
                            User_Mode = i.Field<int?>("User_Mode")
                        }).ToList();
            }
            //if (new int[] { 1, 2, 3, 4 }.Contains(1)) 
            //{

            //}
            //var i = ;
        }
    }

    public class ToSqlExtensions<T> where T : BaseModel, new()
    {
        public static string ClassToSqlstr()
        {
            var type = typeof(T);
            var tableName = type.GetTableName();
            var propertys = type.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            string column = $@"select 
                               {
                                   string.Join(',', propertys.Select
                                   (
                                       s =>
                                       {
                                           var name = s.GetTableColumnName();
                                           if ( name == s.Name)
                                           {
                                               return s.Name;
                                           }
                                           else
                                           {
                                               return $"{s.GetTableColumnName()} as {s.Name}";
                                           }
                                       }
                                       )
                                   )
                               } from {tableName}";
            return column;
        }

        public static List<T> GetList(Func<SqlCommand, DataTable> func)
        {
            using (SqlConnection sqlConnection = new SqlConnection(GetHelperDataList.GetConfiguration()["configstring"]))
            {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                //sqlCommand.Transaction = sqlConnection.BeginTransaction();
                var datatable = func(sqlCommand);
                var list = DatatableTolist(datatable);
                return list;
            }
        }

        public static List<T> DatatableTolist(DataTable data)
        {
            var t = typeof(T);
            var propertys = t.GetProperties();
            List<T> results = new List<T>();
            if (data == null || data.Rows.Count <= 0) 
            {
                return results;
            }
            foreach (DataRow i in data.Rows) 
            {
                T result = new T();
                foreach (var j in propertys) 
                {
                    if (data.Columns.Contains(j.Name)) 
                    {
                        //CanWrite 如果可以写入此属性则为真  Canread 如果可以写入此属性 则为真
                        if (!j.CanWrite) 
                        {
                            continue;
                        }
                        var value = i[j.Name];
                        if (value == DBNull.Value)
                            continue;
                        j.SetValue(result, value);
                    }
                }
                results.Add(result);
            }
            return results;
        }
    }

    public static class DataSqlTool
    {

        public static string GetTableName(this Type type)
        {
            if (type == null)
            {
                return "";
            }
            if (type.IsDefined(typeof(SqlTableNameAttribute), true))
            {
                foreach (SqlTableNameAttribute sqlTable in type.GetCustomAttributes(typeof(SqlTableNameAttribute), true))
                {
                    return sqlTable.TableName;
                }
                return type.Name;
            }
            else
            {
                return type.Name;
            }
        }

        public static string GetTableColumnName(this PropertyInfo property)
        {
            if (property == null)
            {
                return "";
            }
            if (property.IsDefined(typeof(SqlTableColumnNameAttrbute), true))
            {
                foreach (SqlTableColumnNameAttrbute sqlTable in property.GetCustomAttributes(typeof(SqlTableColumnNameAttrbute), true))
                {
                    if (sqlTable.ColumnName == "" || sqlTable.ColumnName == null) 
                    {
                        return property.Name;
                    }
                    return sqlTable.ColumnName;
                    //校验
                    // 获取属性值 值传入 特性验证方法
                }
                return property.Name; ;
            }
            else
            {
                return property.Name;
            }
        }
    }
}
