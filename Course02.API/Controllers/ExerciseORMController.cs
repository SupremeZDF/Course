using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cource02.FactoryModel.Exercise.Model;
using Cource02.FactoryModel.Exercise.BaseserVice;

namespace Course02.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExerciseORMController : ControllerBase
    {
        [HttpGet]
        public void One() 
        {
            Cource02.FactoryModel.ExerciseBuirder.SqlBuirder<T_User>.Name();
            Cource02.FactoryModel.ExerciseBuirder.SqlBuirder<T_User>.Name();
            Cource02.FactoryModel.ExerciseBuirder.SqlBuirder<T_Admin>.Name();
        }

        [HttpGet]
        public void Two() 
        {
            T_User t_User = new T_User() 
            {
               Account_Number ="123",
               User_Name="123",
               Gender="男",
               Password="123",
               User_Mode=1
            };
            new ExerciseService<T_User>().Select();
        }
    }
}
