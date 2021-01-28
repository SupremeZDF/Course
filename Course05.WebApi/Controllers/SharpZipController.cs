using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Course05.Model.ICSharpCodes.SharpZip;

namespace Course05.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SharpZipController : ControllerBase
    {
        [HttpGet]
        public void OneSharpZip() 
        {
            OneICSharpCode.CreateFloder("");
            OneICSharpCode.copyZipFile();
        }

        [HttpPost]
        public void TwoSharpZip() 
        {
            Course05.Model.ICSharpCodes.SharpZip.TwoSharpZip.UnZip(@"D:\DownloadFileFTP\DownloadESignProveZIP\20210126\UNZIP\9d6cb535-a534-4e08-8a3b-a827ea573295.zip",
                @"D:\DownloadFileFTP\DownloadESignProveZIP\20210126\UNZIP","123",true);
            Course05.Model.ICSharpCodes.SharpZip.TwoSharpZip.ZipFile(@"D:\DownloadFileFTP\DownloadESignProveZIP\20210126\ZIP\d3002207-7489-4c2f-a090-ba0f29c8c60c.pdf",
                @$"D:\DownloadFileFTP\DownloadESignProveZIP\20210126\UNZIP\{Guid.NewGuid().ToString()}.zip",2,1024);
            Course05.Model.ICSharpCodes.SharpZip.TwoSharpZip.ZipFile(@"D:\DownloadFileFTP\DownloadESignProveZIP\20210126\ZIP\d3002207-7489-4c2f-a090-ba0f29c8c60c.pdf",
                @$"D:\DownloadFileFTP\DownloadESignProveZIP\20210126\UNZIP\{Guid.NewGuid().ToString()}.zip", 9, 1024);
        }
    }
}
