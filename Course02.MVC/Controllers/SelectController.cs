using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course2.Model.Modle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course02.MVC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SelectController : ControllerBase
    {
        [HttpGet]
        public SelectData GetSelect([FromBody] SelectSSTJ selectSSTJ)
        {
            return Select2Test.GetSelectData(selectSSTJ.page, selectSSTJ.rows);
        }

        [HttpGet]
        public void A()
        {
        
        }

        [HttpGet]
        public void A(int aa)
        {

        }

        //[HttpPost]
        //public void A(int aa)
        //{

        //}
    }
}
