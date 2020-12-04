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

namespace Course04.Model.SqlHelper
{
    public class GetHelperDataList
    {
        private static IConfiguration Configuration;

        static GetHelperDataList() 
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("json.json",true,true).Build();
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
        }
    }
}
