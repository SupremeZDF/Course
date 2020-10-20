using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Course2.Model.Modle
{
    public class Data
    {
        public static DataTable GetDate(string sql) 
        {
            using (SqlConnection sqlConnection = new SqlConnection()) 
            {
                sqlConnection.ConnectionString = "Min Pool Size=10;Max Pool Size=500;Connection Timeout=50;Data Source=192.168.100.85,12033;Initial Catalog=AK_Data_jccs;Persist Security Info=True;User ID=AKTEST;Password=btjf123!";
                if (sqlConnection.State != ConnectionState.Open) 
                {
                    sqlConnection.Open();
                }
                var c = sqlConnection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.Transaction = c;
                command.CommandType = CommandType.Text;
                command.CommandText = sql;
                //command.Parameters.Add();
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = command;
                sqlDataAdapter.Fill(dataTable);
                c.Commit();
                return dataTable;
            }
        }   
    }
}
