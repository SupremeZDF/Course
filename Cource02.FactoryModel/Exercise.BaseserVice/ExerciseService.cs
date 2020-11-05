using Cource02.FactoryModel.Exercise.Model;
using Cource02.FactoryModel.Exercise.Tool;
using Cource02.FactoryModel.Exercise_IbaseService;
using Cource02.FactoryModel.ExerciseBuirder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;
using Cource02.FactoryModel.Exercice.Factory;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Net.Http.Headers;

namespace Cource02.FactoryModel.Exercise.BaseserVice
{
    public class ExerciseService<T> : IExerciseService<T> where T : ExerciseBaseModel
    {
        public ExerciseResult Add(T t)
        {
            ExerciseResult result = new ExerciseResult() { code = 1 };
            try
            {
                if (t == null)
                {
                    result.code = 0;
                    result.message = "";
                    return result;
                }
                var sql = SqlBuirder<T>.AddString;

                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                var parameters = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (var prop in parameters)
                {
                    SqlParameter sqlParameter = new SqlParameter();
                    //if ((new List<Type>(typeof(){ }))
                    sqlParameter.Value = prop.GetValue(t) ?? DBNull.Value;
                    sqlParameter.ParameterName = $"@{prop.Name}";
                    sqlParameters.Add(sqlParameter);
                }
                using (SqlConnection sqlConnection = Configuration.sqlConnection())
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    sql += " select @@identity;";
                    sqlCommand.CommandText = sql;
                    sqlCommand.Parameters.AddRange(sqlParameters.ToArray());
                    var excuteSql = sqlCommand.ExecuteScalar();
                }
            }
            catch (Exception x)
            {
                result.code = 0;
                result.message = x.Message ;
                var ex = x.Message;
            }
            return result;
        }

        public ExerciseResult Delete(T t)
        {
            throw new NotImplementedException();
        }

        public ExerciseResult Select()
        {
            ExerciseResult exerciseResult = new ExerciseResult();

            var propers = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            try
            {
                var sql = SqlBuirder<T>.FindAllstring;
                List<T_User> t_Users = new List<T_User>();
                using (SqlConnection sqlConnection = Configuration.sqlConnection()) 
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = sql;
                    sqlCommand.Connection = sqlConnection;
                    var read = sqlCommand.ExecuteReader();

                    while (read.Read()) 
                    {
                        T_User t_User = new T_User();
                        foreach (var i in propers) 
                        {
                            var d = read[i.Name];
                            i.SetValue(t_User,read[i.Name] is DBNull ? null:read[i.Name]);
                        }
                        t_Users.Add(t_User);
                    }
                    exerciseResult.code = 1;
                    exerciseResult.@object = t_Users;
                }
            }
            catch (Exception ex)
            {
                exerciseResult.code = 0;
                exerciseResult.message = ex.Message;
            }
            return exerciseResult;
            //  throw new NotImplementedException();
        }

        public ExerciseResult Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
