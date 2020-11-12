using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;
using Course03.Model.TwoModel;
using Course03.Model.Model;
using Course03.Model.Runvalidate;

namespace Couese03.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttrbuteController : ControllerBase
    {
        [HttpGet]
        public void OneAttrbute() 
        {
            //Course03.Model
            Assembly assembly = Assembly.Load("Course03.Model");
            var decode = assembly.GetTypes().Where(p => p.Namespace == "Course03.Model.Model");
            var dd = decode.Count();
            var baseName = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace;
            var d = MethodBase.GetCurrentMethod().DeclaringType.Name;
            var a = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        }

        [HttpGet]
        public void TwoAttrbute() 
        {
            new OneAttrbuteRun().Run();
        }

        [HttpGet]
        public void enumAttrbute() 
        {
            var dd = enumClass.nomal;
            enumClass enumClasss = new enumClass();
            enumClass @enum=enumClass.nomal;
            var d = enumClasss.GetType();

            var ddd = (enumClass)1;
             
            //var dd = typeof(enumClass);
            enumClasss.enumRemark();
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public void ThreeAttrbute() 
        {
            TwoRunReflection.run();
        }

        [HttpGet]
        public void Four() 
        {
            OneRunAttrbute.Run();
        }
    }
}
