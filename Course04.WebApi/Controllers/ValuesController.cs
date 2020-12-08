using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Course04.Model.Model;
using Course04.Model.workExercise;

namespace Course04.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController() 
        {
           
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public void OneDelegate() 
        {
            //var i = new TwoDelegate();
            //i.twoRun(); //23522948 23522948
            //var ii = i.GetHashCode();

            EventDY.lessDY();
        }

        [HttpPost]
        public void TwoDelegate() 
        {
            OneLanmda.DataLamdaExercise();
        }

        [HttpPost]
        public void LinqOne() 
        {
            var d = this.GetHashCode();
            LinqLandaShujuTest.T_UserLamda();
        }
    }
}
