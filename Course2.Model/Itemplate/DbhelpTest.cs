using Course2.Model.Couurse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Course2.Model.Itemplate
{
    public class DbhelpTest
    {
        public IConfiguration _Configuration;
        public DbhelpTest(IConfiguration configuration) 
        {
            _Configuration = configuration;
        }

        public DbhelpTest() 
        {
        
        }


        public  IDbhelp GetDbhelp()
        {
            Assembly assembly = Assembly.Load(_Configuration["dbhelpFilePath"]);
            Type type = assembly.GetType(_Configuration["dbhelpFileClass"]);

            MethodInfo method = type.GetMethod("show5");

            //设置泛型约束方法
            method.MakeGenericMethod(new Type[] { });

            method.Invoke(type, new object[] { });

            ///设置泛型类约束
            type.MakeGenericType(new Type[] { });

            //true 执行 公共和非公共 构造函数创建实列  
            object obj = Activator.CreateInstance(type,true);
            
            //获取实列方法 私有方法
            type.GetMethod("show4",BindingFlags.NonPublic|BindingFlags.Instance);

            var cds= type.GetMethod("show4", BindingFlags.NonPublic | BindingFlags.Instance).Name;


            //根据参数获取方法
            type.GetMethod("123", new Type[] { });
            foreach (var i in type.GetMethods()) 
            {
                var ty = i.ReturnType;
                foreach (var j in i.GetParameters()) 
                {
                    var c= j.ParameterType.IsGenericType;
                }
                //obj 方法的实列  object [] 执行方法传递的参数
                //静态方法可以传递实列   也可以不用传递实列
                i.Invoke(obj,null);
            }
            var dd = (IDbhelp)Activator.CreateInstance(type);
            //dd.Connection();
            return dd;
        }

        /// <summary>
        /// 反射实列 一
        /// </summary>
        public void OneReflection() 
        { 

        }

        private void OneShowSY() 
        {
        
        }

        public void Oneshou() 
        {

        }

        public void Oneshou(int a)
        {

        }

        public void Oneshou(string a)
        {

        }

        public void Oneshou(int a,string b)
        {

        }

        public static void twoShow(int a) 
        {
        
        }

        public void threeShow<T, S, W>(T A, S B, W C) 
        {
        
        }
    }
}
