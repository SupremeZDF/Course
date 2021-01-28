using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Course05.Model.Model;
using System.Threading;

namespace Course05.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OnrThredController : ControllerBase
    {
        [HttpGet]
        public void Name() 
        {
            Console.WriteLine(Thread.CurrentThread.GetHashCode());
            ThreadExercise.OneExercise();
        }

        [HttpGet]
        public void TwoName() 
        {
             
        }
    }
}
