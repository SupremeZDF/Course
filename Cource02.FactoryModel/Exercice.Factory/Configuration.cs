using Cource02.FactoryModel.Exercise.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Cource02.FactoryModel.Exercice.Factory
{
    public class Configuration
    {
        private static string ConfigString = ExerciseReadJson.GetConfiguration()["Connection"];

        private static string ConfigsubLit = ExerciseReadJson.GetConfiguration()["Sqlconnection"];

        public static SqlConnection sqlConnection() 
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigString;
            if (sqlConnection.State != ConnectionState.Open) 
            {
                sqlConnection.Open();
            }
            return sqlConnection;
        }
    }
}
