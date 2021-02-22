using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TwoWinForm.Model
{
    public class FourThreadExercise
    {
        public static void OneRunThread()
        {

            {
                List<int> vs1 = new List<int>() { 1, 2, 3, 4 };

                for (var i = 0; i < 10; i++)
                {

                }

                foreach (var i in vs1) 
                {
                    var ii = i;
                    ii++;
                }
            }
          

            {
                int i = 1;
                var ai = i.GetHashCode();

                var ii = i;
                var aii = ii.GetHashCode();

                ii = 3;
            }

            {
                UserModel userModel = new UserModel();
                List<UserModel> userModels = new List<UserModel>();
                userModels.Add(userModel);

                var a = userModel.GetHashCode();  //15368010

                foreach (var mo in userModels) 
                {
                    var aa = mo.GetHashCode();  //15368010
                    mo.Age = 12;
                    var aaa = mo.GetHashCode();  //15368010
                }
                a = userModel.GetHashCode();  //15368010


                UserModel userModel1 = new UserModel();

                //var d = userModel1.GetHashCode(); //4094363
                //userModel1.Name = 12;
                //var dd = userModel1.GetHashCode(); //4094363

                var ddd = userModel1;
                //var dddd = ddd.GetHashCode(); //4094363
                ddd.ID = 12;
                //dddd = ddd.GetHashCode(); //4094363

                UserModel userModel2 = new UserModel();

                userModel2.Name = 12;
            }

            {
                UserModel userModel = new UserModel();
                //Expression<Func<object[]>> expression = () => new object[] { userModel.Age, userModel.Name, userModel.Age };


                List<UserModel> userModels = new List<UserModel>();

                var i = from ii in userModels where ii.Age > 10 orderby ii.Age, ii.ID select ii;

                //var a = expression.Body;

                //int[] a = { 1, 2, 3, 4 };

                //object o = new int [] { 1,2,3,4 };

                //var a = new string[] { "1","2"};

                int[] vs = new int[] { };
            }
        }

        public static void TwoRunThread() 
        {
        
        }
    }

    public class UserModel
    {
        public int ID { get; set; }

        public int Name { get; set; }

        public int Age { get; set; }

        public List<UserModel> userModels1 { get; set; }
    }
}
