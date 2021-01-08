using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.ExperssionExercise
{
    public class GenarelExpressionPublic
    {
        public static object Name;

        public static T_AdminUser T_AdminUser;

        private static object Names;

        private static T_AdminUser T_AdminUsers;

        static GenarelExpressionPublic() 
        {
            T_AdminUser = new T_AdminUser();
            Name = new T_AdminUser();

            T_AdminUsers = new T_AdminUser();
            Names = new T_AdminUser();
        }

        public GenarelExpressionPublic() 
        {
            T_AdminUser = new T_AdminUser();
            Name = new T_AdminUser();

            T_AdminUsers = new T_AdminUser();
            Names = new T_AdminUser();
        }

        public void Consolog() 
        {
            var a = T_AdminUser.GetHashCode();//48397273
            var b = Name.GetHashCode(); //1972295
            var c = T_AdminUsers.GetHashCode(); //49307382
            var d = Names.GetHashCode();  //24724999
        }
    }
}
