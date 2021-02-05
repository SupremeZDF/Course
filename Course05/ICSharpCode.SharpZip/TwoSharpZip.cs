using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace Course05.Model.ICSharpCodes.SharpZip
{
    public class TwoSharpZip
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
            //文件未找到
            if (!File.Exists(fileToZip))
            {
                throw new System.IO.FileNotFoundException("文件不存在");
            }
            using (FileStream fileStream = File.Create(zipedFile))
            {
                using (ZipOutputStream zipOutputStream = new ZipOutputStream(fileStream))
                {
                    zipOutputStream.Password = "123";
                    using (FileStream fileStream1 = new FileStream(fileToZip, FileMode.Open, FileAccess.Read))
                    {
                        string fileName = fileToZip.Substring(fileToZip.LastIndexOf("\\") + 1);
                        ZipEntry zipEntry = new ZipEntry(fileName);
                        var fileNames = Path.GetFileName(fileToZip);
                        //添加条目 添加 压缩  文件
                        zipOutputStream.PutNextEntry(zipEntry);

                        

                        //zipOutputStream.curEntry
                        //设置压缩级别
                        zipOutputStream.SetLevel(compressionLevel);
                        byte[] buffer = new byte[blockSize];
                        int sizeRead = 0;
                        try
                        {
                            do
                            {
                                sizeRead = fileStream1.Read(buffer, 0, blockSize);
                                zipOutputStream.Write(buffer, 0, blockSize);
                            } while (sizeRead == blockSize);
                        }
                        catch (Exception ex)
                        {

                        }
                        //清除缓存区 并将数据写入
                        fileStream1.Flush();
                        fileStream1.Close();
                    }
                    zipOutputStream.Finish();
                    zipOutputStream.Flush();
                    zipOutputStream.Close();
                }
                fileStream.Close();
            }
        }

        /// <summary>
        /// 解压缩一个 zip 文件。
        /// </summary>
        /// <param name="zipedFile">The ziped file.</param>
        /// <param name="strDirectory">The STR directory.</param>
        /// <param name="password">zip 文件的密码。</param>
        /// <param name="overWrite">是否覆盖已存在的文件。</param>
        public static void UnZip(string zipedFile, string strDirectory, string password, bool overWrite)
        {

            if (strDirectory == "")
                strDirectory = Directory.GetCurrentDirectory();
            if (!strDirectory.EndsWith("\\"))
                strDirectory = strDirectory + "\\";

            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipedFile)))
            {
                s.Password = password;
                ZipEntry theEntry;

                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = "";
                    string pathToZip = "";
                    pathToZip = theEntry.Name;

                    if (pathToZip != "")
                        directoryName = Path.GetDirectoryName(pathToZip) + "\\";

                    string fileName = Path.GetFileName(pathToZip);

                    Directory.CreateDirectory(strDirectory + directoryName);

                    if (fileName != "")
                    {
                        if ((File.Exists(strDirectory + directoryName + fileName) && overWrite) || (!File.Exists(strDirectory + directoryName + fileName)))
                        {
                            using (FileStream streamWriter = File.Create(strDirectory + directoryName + fileName))
                            {
                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);

                                    if (size > 0)
                                        streamWriter.Write(data, 0, size);
                                    else
                                        break;
                                }
                                streamWriter.Close();
                            }
                        }
                    }
                }

                s.Close();
            }
        }
    }
}
