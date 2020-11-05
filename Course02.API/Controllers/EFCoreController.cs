using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Course2.Model.IDBHELP;
using Course2.Model.EFModel;
using Course2.Model.Generic;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Course02.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EFCoreController : ControllerBase
    {
        [HttpGet]
        public void OneReflection() 
        {
            ////Course02.API,
            //var basetype = Assembly.GetExecutingAssembly();
            ////var cc = Assembly.GetExecutingAssembly().GetType("");

            //var aa = typeof(int).MakeArrayType(3);

            var ddd = typeof(C).BaseType;

            var classType = typeof(Class);
            
            
            foreach (var t in classType.GetNestedTypes())
            {
                Console.WriteLine($"NestedType ={t}");
                //获取一个值，该值指示 System.Type 是否声明为公共类型。
                Console.WriteLine($"{t}访问 {t.IsPublic}");
                //获取一个值，通过该值指示类是否是嵌套的并且声明为公共的。
                Console.WriteLine($"{t}访问 {t.IsNestedPublic}");
            }

            //Guid
            var intArray = typeof(int).MakeArrayType();
            var int3Array = typeof(int).MakeArrayType(3);

            Console.WriteLine($"是否是int 数组 intArray == typeof(int[]) ：{intArray == typeof(int[]) }");
            Console.WriteLine($"是否是int 3维数组 intArray3 == typeof(int[]) ：{int3Array == typeof(int[]) }");
            Console.WriteLine($"是否是int 3维数组 intArray3 == typeof(int[,,])：{int3Array == typeof(int[,,]) }");

            //数组元素的类型
            Type elementType = intArray.GetElementType();
            Type elementType2 = int3Array.GetElementType();

            Console.WriteLine($"{intArray}类型元素类型：{elementType }");
            Console.WriteLine($"{int3Array}类型元素类型：{elementType2 }");

            //获取数组的维数
            var rank = int3Array.GetArrayRank();
            Console.WriteLine($"{int3Array}类型维数：{rank }");
            Console.ReadKey();

            //OneExecise.Run();

            //IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("", true, true).Build();
        }

        /// <summary>
        /// 反射
        /// </summary>

        [HttpGet]
        public void TwoReflection() 
        {
            

            var t = typeof(AA);

            foreach (var tt in t.GetProperties()) 
            {
                var ttt = tt.PropertyType.IsValueType;
                var gg = tt.PropertyType.IsClass;
                var ggg = tt.PropertyType.Name;
            }

            int a = 1;
            var aa = a.GetType();
            var b = typeof(int);
            var dd = "";
            foreach (var i in typeof(AA).GetProperties()) 
            {
                var c = i.PropertyType.IsValueType;
                var ddd = i.PropertyType.IsClass;
                var ee = i.PropertyType.Name;

                if (i.PropertyType.IsGenericType) 
                {
                    var fff = i.GetValue(dd) as IEnumerable<object>;
                    foreach (var j in fff) 
                    {
                        var jj = j.GetType();
                        foreach (var jjj in jj.GetProperties()) 
                        {
                          
                        }
                    }
                }
                var ff = i.PropertyType.IsArray;
            }
        }


        [HttpGet]
        public void EFCore()
        {


            EFUserModel eFUser = new EFUserModel()
            {
                Account_Number = "123",
                User_Name = "asda"
            };
            DBSqlserver.sqlDelete<EFUserModel>(eFUser);

            var yy = typeof(int);
            var tt = yy.GetProperties();
        }

        [HttpGet]
        public void Generic() 
        {
            DBSqlserver.OneExercise(new OneGeneric());
        }


        [HttpGet]
        public AA Name()
        {
            //AA c = new AA() 
            //{
            //  A=4,
            //  b=2,
            //  c=3
            //};

            //var d = 1;
            //var f = 1;
            //var t = 1;

            //var dd = Newtonsoft.Json.JsonConvert.SerializeObject(c);
            //return c;
            return null;
        }
    }

    public enum dddd 
    {
    
    }

    public class AA
    {

        public dddd dddd { get; set; }

        public string[] bb { get; set; }

        public int A { get; set; }

        public string a { get; set; }

        public B b { get; set; }

       

        public List<C> c { get; set; }

        public List<A> As { get; set; }

        public int d 
        {
            get { 
                return A > 3 ? 4 : 5;
            }
        }
    }

    public class Class
    {
        public class Student
        {
            public string Name { get; set; }
        }
    }

    public class A 
    {
    
    }
    public class B:A
    {

    }
    public class C:B
    {

    }
}
