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
            var  t_userlist = ToSqlExtensions<T_userModelTable>.GetList(cmd=> 
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
        }
    }
}
