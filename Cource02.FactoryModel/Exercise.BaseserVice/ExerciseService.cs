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
using System.Linq;

namespace Cource02.FactoryModel.Exercise.BaseserVice
{

    public class ExerciseService<T> : IExerciseService<T> where T : ExerciseBaseModel, new()
    {
        public Result Add(T t)
        {
            //1 特性+反射 +委托 + 泛型
            // 2 属性名称 类名称（表名称）
            //3 数据验证 非空 手机号格式 格式 Email 字符串长度最大最小规则  返回错误得所信息 多重验证
            //4  委托 解耦 优化代码
            //5  进阶需求 泛型缓存  特性相关缓存  字典缓存or泛型缓存
            Result result = new Result() { code = 1 };
            try
            {
                if (t == null)
                {
                    result.code = 0;
                    result.message = "";
                    return result;
                }
                var res = t.RequestValidate();
                if (res.code == 0)
                {
                    return res;
                }
                var sql = SqlBuirder<T>.AddString;

                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                var parameters = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(c => c.GetCustomAttribute(typeof(ormTableColumnNameAttribute)) == null
                || (c.GetCustomAttribute(typeof(ormTableColumnNameAttribute)) as ormTableColumnNameAttribute).Identity == false); ;
                foreach (var prop in parameters)
                {
                    SqlParameter sqlParameter = new SqlParameter();
                    //if ((new List<Type>(typeof(){ }))
                    sqlParameter.Value = prop.GetValue(t) ?? DBNull.Value;
                    sqlParameter.ParameterName = $"@{prop.GetTableColumn()}";
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
                result.message = x.Message;
                var ex = x.Message;
            }
            return result;
        }

        #region 工厂委托

        //调用工厂模式

        public Result InvokeAdd(T t)
        {
            Result result = new Result() { code = 1 };
            if (t == null)
            {
                result.code = 0;
                result.message = "";
                return result;
            }
            var res = t.RequestValidate();
            if (res.code == 0)
            {
                return res;
            }
            var sql = SqlBuirder<T>.AddString;

            return AddExtendFactory((c) =>
            {
                try
                {
                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    var parameters = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(c => c.GetCustomAttribute(typeof(ormTableColumnNameAttribute)) == null
                    || (c.GetCustomAttribute(typeof(ormTableColumnNameAttribute)) as ormTableColumnNameAttribute).Identity == false); ;
                    foreach (var prop in parameters)
                    {
                        SqlParameter sqlParameter = new SqlParameter();
                        //if ((new List<Type>(typeof(){ }))
                        sqlParameter.Value = prop.GetValue(t) ?? DBNull.Value;
                        sqlParameter.ParameterName = $"@{prop.GetTableColumn()}";
                        sqlParameters.Add(sqlParameter);
                    }
                    sql += " select @@identity;";
                    c.CommandText = sql;
                    c.CommandType = CommandType.Text;
                    c.Parameters.AddRange(sqlParameters.ToArray());
                    result.@object = c.ExecuteScalar();
                }
                catch (Exception x)
                {
                    result.code = 0;
                    result.message = x.Message;
                    var ex = x.Message;
                }
                return result;
            });
        }

        public Result AddExtendFactory(Func<SqlCommand, Result> func)
        {
            Result result = new Result() { };
            try
            {
                using (SqlConnection sqlConnection = Configuration.sqlConnection())
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    result = func(sqlCommand);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        #endregion

        #region 委托
        //委托
        public Result AddExtendRun(T ts)
        {

            return AddExtend(ts, (t) =>
             {
                 Result result = new Result() { code = 1 };
                 try
                 {
                     if (t == null)
                     {
                         result.code = 0;
                         result.message = "";
                         return result;
                     }
                     var res = t.RequestValidate();
                     if (res.code == 0)
                     {
                         return res;
                     }
                     var sql = SqlBuirder<T>.AddString;

                     List<SqlParameter> sqlParameters = new List<SqlParameter>();
                     var parameters = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(c => c.GetCustomAttribute(typeof(ormTableColumnNameAttribute)) == null
                     || (c.GetCustomAttribute(typeof(ormTableColumnNameAttribute)) as ormTableColumnNameAttribute).Identity == false); ;
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
                     result.message = x.Message;
                     var ex = x.Message;
                 }
                 return result;
             });
        }


        public Result AddExtend(T t, Func<T, Result> func)
        {
            //1 特性+反射 +委托 + 泛型
            // 2 属性名称 类名称（表名称）
            //3 数据验证 非空 手机号格式 格式 Email 字符串长度最大最小规则  返回错误得所信息 多重验证
            //4  委托 解耦 优化代码
            return func(t);
        }

        #endregion

        public ExerciseResult Delete(T t)
        {
            throw new NotImplementedException();
        }

        #region 委托
        public Result ExtendSelect()
        {
            return AddExtendFactory((c) =>
            {
                Result exerciseResult = new Result();

                var propers = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                try
                {
                    var sql = SqlBuirder<T>.FindAllSql();
                    List<T> t_Users = new List<T>();
                    c.CommandText = sql;
                    c.CommandType = CommandType.Text;
                    var read = c.ExecuteReader();

                    while (read.Read())
                    {
                        T t_User = new T();
                        foreach (var i in propers)
                        {
                            var d = read[i.Name];
                            i.SetValue(t_User, read[i.Name] is DBNull ? null : read[i.Name]);
                        }
                        t_Users.Add(t_User);
                    }
                    exerciseResult.code = 1;
                    exerciseResult.@object = t_Users;
                }
                catch (Exception ex)
                {
                    exerciseResult.code = 0;
                    exerciseResult.message = ex.Message;
                }
                return exerciseResult;
            });
        }
        #endregion

        public ExerciseResult Select()
        {
            ExerciseResult exerciseResult = new ExerciseResult();

            var propers = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            try
            {
                var sql = SqlBuirder<T>.FindAllSql();
                List<T> t_Users = new List<T>();
                using (SqlConnection sqlConnection = Configuration.sqlConnection())
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = sql;
                    sqlCommand.Connection = sqlConnection;
                    var read = sqlCommand.ExecuteReader();

                    while (read.Read())
                    {
                        T t_User = new T();
                        foreach (var i in propers)
                        {
                            var d = read[i.Name];
                            i.SetValue(t_User, read[i.Name] is DBNull ? null : read[i.Name]);
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
