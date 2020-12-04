using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Course04.Model.SqlHelper;
using Course04.Model.Extend;

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
            var groupBy = data.GroupBy();
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
}
