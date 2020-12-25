using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Course04.Model.SqlHelper;
using Course04.Model.Extend;
using System.Data.SqlClient;
using System.Data;
using Course04.Model.LinqModel;
using Course04.Model.Model;

namespace Course04.Model.workExercise
{
    public class OneLanmda
    {
        public void OneRun<T>()
        {
            new List<int>().Where(s => s > 2 && s < 2);
        }

        public delegate void OneDeledageLamda();

        public static OneDeledageLamda deledageLamda;

        public static void LamdataDelegate()
        {
            deledageLamda = new OneDeledageLamda(Test);
            deledageLamda = delegate () { };
            deledageLamda = () => { };
        }

        public static void DataLamdaExercise()
        {
            var data = GetHelperDataList.GetlsitUser();
            //var groupBy = data.GroupBy();
            var tjOne = data.GetTs((s) => s.id > 2 && s.User_Mode > 0);
            foreach (var i in tjOne)
            {
                var ii = i;
            }

            var tjTwo = data.GetIEnumerber((s) => s.id > 2 && s.User_Mode > 0);
            foreach (var j in tjTwo)
            {
                var jj = j;
            }
        }

        public static void Test()
        {

        }
    }

    public class LinqLandaShujuTest
    {
        public static void T_UserLamda()
        {
            var sql = ToSqlExtensions<T_userModelTable>.ClassToSqlstr();
            var t_userlist = ToSqlExtensions<T_userModelTable>.GetList(cmd =>
           {
               DataTable dataTable = new DataTable();
               if (sql == null || sql == "")
               {
                   return dataTable;
               }
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = sql;
               SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
               sqlDataAdapter.Fill(dataTable);
               return dataTable;
           });
            int sss = 2;
            var c = sql.GetHashCode();

            var T_Questionsql = ToSqlExtensions<T_QuestionTable>.ClassToSqlstr();
            var T_Questionlist = ToSqlExtensions<T_QuestionTable>.GetList(cmd =>
            {
                DataTable dataTable = new DataTable();
                if (T_Questionsql == null || T_Questionsql == "")
                {
                    return dataTable;
                }
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = T_Questionsql;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            });
            var count = 0;
            //内连接
            var linqOne = from i in t_userlist
                          join j in T_Questionlist on i.id equals j.UserID into yu
                          select yu;

            var ddd = from iss in t_userlist where iss.Account_Number == "12" group iss by iss.IntroDuce into dsd orderby dsd.Key select new { };

            //分组
            IEnumerable < IGrouping<int?, T_QuestionTable> > linqTwo = from i in T_Questionlist group i by i.UserID into de select de;

            foreach (IGrouping<int?, T_QuestionTable> queryable in linqTwo)
            {
                var d = queryable;
                var cs= queryable;
                var a = queryable.Key;
                var b = queryable.GetEnumerator();
                foreach (var j in d)
                {

                }
            }

            var linqTwos = from i in T_Questionlist select new { };
            
            //排序
            var linqTwoss = from i in T_Questionlist group i by i.UserID into s orderby s.Key descending select s;

            // 内查询
            var linqthrees = from i in t_userlist where new int[] { 27, 2, 31, 4 }.Contains(i.id) select i;
            var linqFour = from i in t_userlist
                           join j in T_Questionlist
                           on i.id equals j.UserID
                           where new int[] { 27 }.Contains(j.UserID ?? 0)
                           select new
                           {
                               id = i.id,
                               name = j.Headline
                           };

            //linq object
            var dd = linqFour.Where(c => false);

            var linqTwoSql = linqFour.AsQueryable().Skip((1 - 0) * 10).Take(10);
            //IComparable<int>
            //linq to sql
            var linqTwoSqls = linqTwoSql.Where(s => s.id > 2);

            //左连接
            var linqFIve = from i in t_userlist
                           join j in T_Questionlist
                           on i.id equals j.UserID
                           into dept
                           from k in dept.DefaultIfEmpty()
                           select new YY
                           {
                               id = i.id,
                               names = k,
                               name = dept == null ? "" : k.Headline
                           };

            //IQueryable<int> s;
            //DataSet dataSet = sss;
            //linqFIve.Union();
            //foreach (var i in linqFIve)
            //{
            //    var d = i;
            //}
            //linqFIve.id;
        }
    }

    public class YY
    {
        public int id { get; set; }

        public T_QuestionTable names { get; set; }

        public string name { get; set; }
    }

    public interface Name 
    {

    }
}
