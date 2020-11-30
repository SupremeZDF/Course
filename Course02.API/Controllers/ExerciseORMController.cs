using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cource02.FactoryModel.Exercise.Model;
using Cource02.FactoryModel.Exercise.BaseserVice;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

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
                Account_Number = "123",
                User_Name = "123",
                Gender = "男",
                Password = "123",
                User_Mode = 1
            };
            new ExerciseService<T_User>().Select();
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public void Three()
        {
            T_User t_User = new T_User()
            {
                Account_Number = "123",
                User_Name = "123",
                Gender = "男",
                Password = "123",
                User_Mode = 1
            };
            new ExerciseService<T_User>().Add(t_User);
        }

        /// <summary>
        /// 数据
        /// </summary>
        [HttpGet]
        public void OneEnum()
        {
            Enum(AA.b|AA.c| AA.a );
        }

        public static void Enum(AA aA)
        {
            var c = (AA)aA;
        }
    }

    public enum AA
    {
        a=1,
        b=2,
        c=3,
        d=4
    }
}
