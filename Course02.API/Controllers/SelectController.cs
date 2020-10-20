using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course2.Model.Modle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course02.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SelectController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        public SelectData GetSelect() 
        {
            return Select2Test.GetSelectData(1,30);
        }
    }
}
