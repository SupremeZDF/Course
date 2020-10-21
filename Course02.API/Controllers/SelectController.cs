using System;
using System.Collections.Generic;
using System.IO;
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
        public void GetOne([FromBody]AA aA)
        {

        }
    }

    public class AA
    {
        public string q { get; set; }

        public int page { get; set; }
    }
}
