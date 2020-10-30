using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Course2.Model.IDBHELP;
using Course2.Model.EFModel;
using Course2.Model.Generic;

namespace Course02.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EFCoreController : ControllerBase
    {
        [HttpGet]
        public void EFCore()
        {
            EFUserModel eFUser = new EFUserModel()
            {
                Account_Number = "123",
                User_Name = "asda"
            };
            DBSqlserver.sqlDelete<EFUserModel>(eFUser);
        }

        [HttpGet]
        public void Generic() 
        {
            DBSqlserver.OneExercise(new OneGeneric());
        }
    }
}
