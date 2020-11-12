using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Course03.Model.Model;

namespace Couese03.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OneExerciseController : ControllerBase
    {
        [HttpGet]
        public void OneAction() 
        {
            OneExercise.TwoRun();
        }

        [HttpPost]
        public void TwoAction() 
        {
            TwoModel twoModel = new TwoModel() 
            {
               Age="123",
               Name=2,
               Password="123"
            };
            twoModel.Datadto();
        }

        [HttpGet]
        public void ThreAction() 
        {
            ThreeModle threeModle = new ThreeRunClass() {  ID=1, Name="123"};

            //threeModle.TwoRun();
            threeModle.Rune();
            //threeModle.InstanceRun();
        }
    }
}
