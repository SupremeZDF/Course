using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Course05.Model.Model;
using System.Threading;
using Course05.Model.ThredModel;

namespace Course05.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OnrThredController : ControllerBase
    {

        //并行 ： 多核之间de1叫并行
        //并发： cpu分片的并发

        [HttpGet]
        public void Name() 
        {
            Console.WriteLine(Thread.CurrentThread.GetHashCode());
            ThreadExercise.OneExercise();
        }

        [HttpGet]
        public void TwoName() 
        {
            OneThreds.OneRunThread();
        }


        [HttpGet]
        public void ThreeName()
        {
            OneThreds.TwoRunThread();
        }

        [HttpGet]
        public void ThreeRunThread() 
        {
            OneThreds.ThreeRunThread();
        }
    }
}
