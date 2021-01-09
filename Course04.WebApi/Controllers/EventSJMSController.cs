using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Course04.Model.DesignRemote;
using System.Reflection;
using Course04.Model.ExperssionExercise;

namespace Course04.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventSJMSController : ControllerBase
    {

        [HttpGet]
        public void FourExpression()
        {




            GenericexpressPrivate<T_User, T_AdminUser> genericexpressPrivate = new GenericexpressPrivate<T_User, T_AdminUser>((c) => { var d = 2311; return new T_AdminUser() { Id = 2311 }; });
            var aac = genericexpressPrivate.aac;
            var ac = GenericexpressPrivate<T_User, T_AdminUser>.ac;

            var aaaa = typeof(GenericexpressPrivate<T_User, T_AdminUser>).Name;

            GenericexpressPrivate<T_User, T_AdminUser>.Names();
            
               GenericexpressPrivate <T_User, T_AdminUser> genericexpressPrivate1 = new GenericexpressPrivate<T_User, T_AdminUser>((c) => { var d = 23333; return new T_AdminUser() { Id = 23333 }; });
            var aacs = genericexpressPrivate1.aac;
            var acs = GenericexpressPrivate<T_User, T_AdminUser>.ac;
            //var bb = GenericexpressPrivate<T_User, T_AdminUser>.Func(new T_User());
            //genericexpressPrivate.Consolog();
            //genericexpressPrivate1.Consolog();

            GenericexpressPrivate<T_AdminUser, T_AdminUser> genericexpressPrivate2 = new GenericexpressPrivate<T_AdminUser, T_AdminUser>((c) => { var d = "23111"; return new T_AdminUser() { Name = "23111" }; });
            var ds = GenericexpressPrivate<T_AdminUser, T_AdminUser>.ac;

            var aaaas = typeof(GenericexpressPrivate<T_AdminUser, T_AdminUser>).Name;
            GenericexpressPrivate<T_AdminUser, T_AdminUser> genericexpressPrivate3 = new GenericexpressPrivate<T_AdminUser, T_AdminUser>((c) => { var d = "23333b"; return new T_AdminUser() { Name = "23333b" }; });
            var dss = GenericexpressPrivate<T_AdminUser, T_AdminUser>.ac;


            var d = GenericexpressPrivate<T_User, T_AdminUser>.ac; 
            //genericexpressPrivate2.Consolog();
            //genericexpressPrivate3.Consolog();



            GenericexpressPrivate<T_User, T_AdminUser>.Consologs();
            GenericexpressPrivate<T_AdminUser, T_AdminUser>.Consologs();

            genericexpressPrivate.Consolog();
            genericexpressPrivate1.Consolog();


            var a = new GenarelExpressionPublic();
            var b = new GenarelExpressionPublic();
            a.Consolog();
            b.Consolog();
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public void TwoRunExperssion()
        {
            OneExercise.OneExpersion();
        }

        [HttpGet]
        public void ThreeRunExpression()
        {
            OneExercise.TwoExpression();
        }

        [HttpGet]
        public void RunReflection()
        {
            Assembly assembly = Assembly.Load("Course04.Model");
            var da = assembly.GetTypes().Where(i => i.Namespace == "Course04.Model.DesignRemote" && i.BaseType != null && i.BaseType.Name == "KoujPerform").ToList();

            var c = assembly.GetType("Course04.Model.DesignRemote.NorthShow").GetInterfaces();
            var cc = assembly.GetType("Course04.Model.DesignRemote.NorthShow").BaseType.Name;
            foreach (var i in da)
            {

            }

            try
            {

                CentShow koujPerform = new CentShow()
                {
                    Person = "张三",
                    Desk = "张三红木桌子",
                    Chair = "张三电脑椅子",
                    Fan = "张三大风扇",
                    Ruler = "张三尺子",
                    WenDu = 400
                };
                koujPerform.showEnd += new EventTool().ThreeEvent;
                koujPerform.show();

                EastShow koujPerform1 = new EastShow()
                {
                    Person = "张三",
                    Desk = "张三红木桌子",
                    Chair = "张三电脑椅子",
                    Fan = "张三大风扇",
                    Ruler = "张三尺子",
                    WenDu = 400
                };

                foreach (var i in koujPerform1.GetType().GetProperties())
                {
                    if (i.Name == "HB")
                    {
                        var j = i.GetValue(koujPerform1);
                    }
                }

                koujPerform1.CurrentWenDu = 300;
                koujPerform1.CurrentWenDu = 401;
                //EventTool.OnRun(koujPerform1);
                //EventTool.TwoRun(koujPerform1);

                SouthShow koujPerform2 = new SouthShow()
                {
                    Person = "李四",
                    Desk = "李四红木桌子",
                    Chair = "李四电脑椅子",
                    Fan = "李四大风扇",
                    Ruler = "李四尺子",
                    WenDu = 800
                };

                koujPerform2.CurrentWenDu = 700;
                koujPerform2.CurrentWenDu = 801;
                //EventTool.OnRun(koujPerform2);
                //EventTool.TwoRun(koujPerform2);

                WestShow koujPerform3 = new WestShow()
                {
                    Person = "王二",
                    Desk = "王二红木桌子",
                    Chair = "王二电脑椅子",
                    Fan = "王二大风扇",
                    Ruler = "王二尺子",
                    WenDu = 400
                };
                koujPerform2.CurrentWenDu = 300;
                koujPerform2.CurrentWenDu = 401;
                //EventTool.OnRun(koujPerform3);
                //EventTool.TwoRun(koujPerform3);

                NorthShow koujPerform4 = new NorthShow()
                {
                    Person = "麻子",
                    Desk = "麻子红木桌子",
                    Chair = "麻子电脑椅子",
                    Fan = "麻子大风扇",
                    Ruler = "麻子尺子",
                    WenDu = 1200
                };
                koujPerform2.CurrentWenDu = 700;
                koujPerform2.CurrentWenDu = 1201;
                //EventTool.OnRun(koujPerform4);
                //EventTool.TwoRun(koujPerform4);
            }
            catch (Exception ex)
            {
                var x = ex;
                throw;
            }

            //var instanceShow = assembly.GetTypes().Where(i => i.BaseType.Name == "KoujPerform");
            //foreach(var j in instanceShow) 
            //{
            //    var jj = j;
            //}
        }
    }
}
