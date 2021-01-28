using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Drawing;

namespace Course05.Model.ICSharpCodes.SharpZip
{
    public class OneICSharpCode
    {
        /// <summary>
        /// 压缩单个文件
        /// </summary>
        /// <param name="fileToZip">要压缩的文件</param>
        /// <param name="zipedFile">压缩后的文件</param>
        /// <param name="compressionLevel">压缩等级</param>
        /// <param name="blockSize">每次写入大小</param>
        public static void ZipFile(string fileToZip, string zipedFile, int compressionLevel, int blockSize)
        { 
            
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        public static void CreateFloder(string createPath) 
        {
            var d = "adcsds";
            var str = d.Substring(0, 2);
            var path = @"D:/DownloadFileFTP/";
            createPath = "/a/b/c/";
            var spli = createPath.Split("/");
            foreach (var j in spli) 
            {
                if (j != null && j.Length > 0) 
                {
                    path += j + "/";
                    Directory.CreateDirectory(path);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void copyZipFile() 
        {
            using (Stream stream = new FileStream(@"D:\DownloadFileFTP\DownloadESignProveZIP\20210126\ZIP\d3002207-7489-4c2f-a090-ba0f29c8c60c.pdf", FileMode.Open, FileAccess.Read)) 
            {
                MemoryStream memoryStream = new MemoryStream();
                var b = stream.Length;
                byte[] vs = new byte[1024 * 2];
                var len = 0;
                do {

                    len = stream.Read(vs, 0, 1024 * 2);
                    var i = stream.Position;
                    memoryStream.Write(vs, 0, 1024 * 2);
                    var d = memoryStream.Length; 
                } while (len == 1024 * 2);
                using (Stream stream1 = File.Create(@"D:\DownloadFileFTP\DownloadESignProveZIP\20210126\UNZIP\d3002207-7489-4c2f-a090-ba0f29c8c60c.pdf")) 
                {
                    memoryStream.Position = 0;
                    stream1.Write(memoryStream.ToArray(), 0, (int)memoryStream.Length);
                }
            }
        }
    }
}
