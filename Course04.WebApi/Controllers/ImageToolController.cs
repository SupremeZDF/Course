using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course04.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageToolController : ControllerBase
    {
        [HttpPost]
        public void ImageToOne( IFormFileCollection file) 
        {
            //var i =  formFile[0];
            var d = Request.Form.AsQueryable();
            foreach (var i in d) {

                var s = i;
            };
            //AbstaartClass a = new AbstaartClass();
            
        }
    }

    public abstract class AbstaartClass {

        public void Nmae() { }
    }

    public class Image { 
      public IFormFileCollection file { get; set; }

     public string pswd { get; set; }
    }
}
