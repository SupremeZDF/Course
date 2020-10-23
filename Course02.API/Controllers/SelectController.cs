using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Course2.Model.Couurse;
using Course2.Model.Modle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Course2.Model.Itemplate;
using Microsoft.Extensions.Configuration;
using Course2.Model;
using System.Diagnostics;

namespace Course02.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SelectController : ControllerBase
    {

        public IConfiguration _configuration;

        /// <summary>
        /// 
        /// </summary>
        public SelectController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public SelectData GetSelect([FromBody] SelectSSTJ selectSSTJ)
        {
            return Select2Test.GetSelectData(selectSSTJ.page, selectSSTJ.rows);
        }

        [HttpPost]
        public SelectData GetSelectOne()
        {
            //Request.EnableRewind()
            Request.EnableBuffering();
            var c = HttpContext.Request.Body;
            c.Position = 0;
            var ccc = c.Length;
            string json = "";
            StreamReader streamWriter = new StreamReader(c);
            var cc = streamWriter.ReadToEnd();
            return Select2Test.GetSelectData(1, 30);
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public void GetOne([FromBody] AA aA)
        {

        }

        [HttpGet]
        public void Assemblys()
        {
            //var de = AppDomain.CurrentDomain.BaseDirectory;
            //AssemBly.GetAssemBly();
            A a;
            AA aa = new AA();
            a = aa as A;
            //反射构造实列 构造函数传参
            var ccc = Activator.CreateInstance(typeof(int), new object[] { "123", 2 });
            var c = ccc.GetType().GetConstructors()[0].GetParameters();
            a.name();
        }

        [HttpPost]
        public void Singleton()
        {
            //TwoClass twoClass = new TwoClass();

            TwoClass twoClass = TwoClass.Name();

            Assembly assembly = Assembly.Load("Course2.Model");

            var cc = assembly.GetType("Course2.Model.Couurse.TwoClass");

            // 反射破坏 单列   true 执行无参 公共 非公共 构造函数
            var dd = (TwoClass)Activator.CreateInstance(cc,true);
            var ddc = (TwoClass)Activator.CreateInstance(cc, true);
        }

        [HttpGet]
        public void GenericClass() 
        {
            Assembly assembly = Assembly.Load("Course2.Model");

            var cc = assembly.GetType("Course2.Model.Couurse.GenericClass`3");

            Assembly.LoadFile("");

            //var b = Activator.CreateInstance(cc);  设置泛型类参数格式
            cc = cc.MakeGenericType(new Type[] { typeof(int), typeof(int) , typeof(int) });
            var b = Activator.CreateInstance(cc);
            
        }

        [HttpGet]
        public void Factory() 
        {
            DbhelpTest test = new DbhelpTest(_configuration);
            IDbhelp yy = test.GetDbhelp();
            yy.Connection();
        }


        /// <summary>
        /// 反射实列1
        /// </summary>
        [HttpGet]
        public void oneReflection() 
        {
            Assembly assemBly = Assembly.Load("Course2.Model");
            Type type = assemBly.GetType("Course2.Model.Itemplate.DbhelpTest");
            //type.GetProperties()[0].SetValue();
            type.MakeGenericType();
            object ca = Activator.CreateInstance(type);

            var dd = type.GetProperties().Select(i => i.Name);

            foreach (var i in type.GetProperties()) 
            {
                i.SetValue(ca,12);
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            stopwatch.Stop();

            var dds = stopwatch.ElapsedMilliseconds;

            //string.Join();

            //私有方法
            MethodInfo info = type.GetMethod("OneShowSY", BindingFlags.Instance | BindingFlags.NonPublic);
            info.Invoke(ca,null);

            //Emit 反射 放射 
            //System.Reflection.Emit.AssemblyBuilder emit=new System.Reflection.Emit.AssemblyBuilder()

            //重载方法
            MethodInfo info1 = type.GetMethod("Oneshou",new Type[] { });
            info1.Invoke(ca, null);

            MethodInfo info2 = type.GetMethod("Oneshou", new Type[] {typeof(string) });
            info2.Invoke(ca, new object[] { "123"});

            MethodInfo info3 = type.GetMethod("Oneshou", new Type[] { typeof(int) });
            info3.Invoke(ca, new object [] { 12});

            MethodInfo info4 = type.GetMethod("Oneshou", new Type[] { typeof(int), typeof(string) });
            info4.Invoke(ca, new object[] { 12,"12"});

            //静态
            MethodInfo info5 = type.GetMethod("twoShow", new Type[] {typeof(int) });
            info5.Invoke(null, new object[] {12 });

            //泛型方法 threeShow
            MethodInfo info6 = type.GetMethod("threeShow");
            info6.MakeGenericMethod();
            info6 = info6.MakeGenericMethod(new Type[] { typeof(int),typeof(string),typeof(double)});
            info6.Invoke(ca, new object[] { 12,"21",1.20 });
        }

    }

    public interface A 
    {
        void name();
    }

    public class AA:A
    {
        public string q { get; set; }

        public int page { get; set; }

        public void name()
        {
            throw new NotImplementedException();
        }
    }
}
