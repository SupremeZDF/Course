using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course02.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Exercises : ControllerBase
    {
        [HttpGet]
        public void Run()
        {
            TwoTestActionClass twoTest = new TwoTestActionClass();
            var d = twoTest.GetType();
            var c = d.GetProperties();
            var cc = c.FirstOrDefault().GetCustomAttributes(typeof(OneTestAttrbute),true);
            var ccc = cc.Count();
        }
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class OneTestAttrbute : Attribute
    {

    }

    public abstract class OneTestActionClass
    {
        [OneTestAttrbute]
        public abstract string A { get; set; }
    }

    public class TwoTestActionClass : OneTestActionClass
    {
        public override string A { get; set; }
    }
}
