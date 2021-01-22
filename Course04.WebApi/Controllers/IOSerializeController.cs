using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course04.Model.IoSerzlia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course04.WebApi.Controllers
{
    /// <summary>
    /// 1 文件夹/文件 检查 新增 复制 移动 删除 递归编程技巧 
    /// 2 文件读写 记录文本日志 读取配置文件 
    /// 三种序列化器 xml 和 json
    /// 验证码 图片 缩放 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IOSerializeController : ControllerBase
    {
        [HttpGet]
        public void OneIOSerialize() 
        {
            OneISerliza.OneIOSerialize();
        }

        [HttpGet]
        public void TwoDgExercise() 
        {
            var a = ICOnfigBuiolder.UU(27, 45);
        }

        /// <summary>
        /// 获取子目录
        /// </summary>
        [HttpGet]
        public void GetParentDirectory() 
        {
            OneISerliza.GetParentDirectory();
        }

        [HttpGet]
        public void ThreeDgExercise() 
        {

            XMLHelper.OneRunXmlDocment();
            

            //var a = System.IO.Directory.GetCurrentDirectory();
            ////var a = HttpContext.;
            //SerializeHelper.BinarySerialize();
            //SerializeHelper.XmlSerialize();
            //SerializeHelper.SoapSerialize();
        }
    }
}
