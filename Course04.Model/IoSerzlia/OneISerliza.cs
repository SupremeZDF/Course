using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Course04.Model.IoSerzlia;
using System.Linq;

namespace Course04.Model.IoSerzlia
{
    /// <summary>
    /// 1 文件夹/文件 检查 新增 复制 移动 删除 递归编程技巧 
    /// 2 文件读写 记录文本日志 读取配置文件 
    /// 三种序列化器 xml 和 json
    /// 验证码 图片 缩放 
    /// </summary>
    public class OneISerliza
    {
        public static string logpath = ICOnfigBuiolder.GetConfigBuilder()["logpath"];

        public static string LogMovePath = ICOnfigBuiolder.GetConfigBuilder()["LogMovePath"];

        public static string PathStr = "D:\\学习\\";

        public static string PathStrs = "D:\\学习";

        //获取当前程序路径
        public static string Logppath2 = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 获取子目录
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryToolModel> GetChildDirectory(DirectoryInfo directoryInfo)
        {
            List<DirectoryToolModel> models = new List<DirectoryToolModel>();
            var data = directoryInfo.GetDirectories();
            if (data != null && data.Length > 0)
            {
                models = data.Select(x => new DirectoryToolModel() { Directorys = x }).ToList();
                foreach (var i in models)
                {
                    if (i.Directorys.GetDirectories().Length > 0)
                    {
                        i.Childs = GetChildDirectory(i.Directorys);
                    }
                }
            }
            return models;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void GetParentDirectory()
        {
            if (Directory.Exists(PathStr))
            {
                DirectoryInfo directory = new DirectoryInfo(PathStr);
                DirectoryToolModel directoryTool = new DirectoryToolModel();
                directoryTool.Directorys = directory;
                //List<DirectoryToolModel> directoryTools = new List<DirectoryToolModel>();
                var a = directory.GetDirectories().Select(x => new DirectoryToolModel() { Directorys = x }).ToList();
                directoryTool.Childs = a;
                foreach (DirectoryToolModel toolModel in directoryTool.Childs)
                {
                    if (toolModel.Directorys.GetDirectories() != null && toolModel.Directorys.GetDirectories().Length > 0)
                    {
                        //获取子目录
                        var data = GetChildDirectory(toolModel.Directorys);
                        toolModel.Childs = data;
                    }
                }
            }

            //var a = directory.GetDirectories();
            //DirectoryInfo directory1 = new DirectoryInfo(PathStrs);
            //a = directory1.GetDirectories();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int ZZAction(int a,int b) 
        {
            if (b == 0) 
            {
                return a;
            }
            return ZZAction(b,a%b);
        }

        /// <summary>
        /// 获取Tree树
        /// </summary>
        public static void GetZijieDian()
        {
            List<TreeNodeModel> models = new List<TreeNodeModel>();
            List<TreeNodeTool> treeNodeTools = new List<TreeNodeTool>();
            //获取一级数据
            foreach (TreeNodeModel treeNode in models.Where(x => x.ParentID == 0))
            {
                TreeNodeTool treeNodeTool = new TreeNodeTool();
                treeNodeTool.Id = treeNode.Id;
                treeNodeTool.NodeName = treeNode.NodeName;
                treeNodeTool.Childs = GetDejDian(treeNodeTool, models);
            }
        }

        /// <summary>
        /// 获取子菜单
        /// </summary>
        public static List<TreeNodeTool> GetDejDian(TreeNodeTool treeNodes, List<TreeNodeModel> treeNodeModels)
        {
            var model = treeNodeModels.Where(x => x.ParentID == treeNodes.Id);
            List<TreeNodeTool> treeNodes1 = new List<TreeNodeTool>();
            treeNodes1 = model.Select(x => new TreeNodeTool() { Id = x.Id, NodeName = x.NodeName }).ToList();
            foreach (TreeNodeTool treeNode in treeNodes1)
            {
                if (treeNodeModels.Where(x => x.ParentID == treeNode.Id).Count() > 0) 
                {
                    treeNode.Childs = GetDejDian(treeNode, treeNodeModels);
                }
            }
            return treeNodes1;
        }

        

        /// <summary>
        /// 
        /// </summary>
        public static void OneIOSerialize()
        {
            //var a = logpath;
            {
                //文件夹帮助类
                if (!Directory.Exists(logpath))
                {
                    DirectoryInfo directory = new DirectoryInfo(logpath);
                    Console.WriteLine($"{directory.FullName}_{directory.Name}_{directory.LastWriteTime}");
                    new List<string>().Select(x => x);
                }
                //var directorys = "D:/学习/架构版班_学习课程/LogPath";

                if (!File.Exists(Path.Combine(logpath, "log.txt")))
                {

                }
                //文件不存在 也会读取出信息
                FileInfo fileInfo = new FileInfo(Path.Combine(logpath, "log.txt"));
                Console.WriteLine($"{fileInfo.FullName}_{fileInfo.CreationTime}_{fileInfo.LastWriteTime}");
            }
            //文件夹帮助类
            {
                //判断目录是否存在
                if (!Directory.Exists(logpath))
                {
                    DirectoryInfo directoryInfo = Directory.CreateDirectory(Path.Combine(logpath, "log.txt")); //一次性创建全部的子路径
                    //文件夹移动并剪切
                    Directory.Move(logpath, LogMovePath);
                    Directory.Delete(LogMovePath, true);
                }
            }

            {
                string fileName = Path.Combine(logpath, "log.txt");
                string fileNameCopy = Path.Combine(logpath, "LogCopy.txt");
                string fileNameMove = Path.Combine(logpath, "LogMOve.txt");
                if (!File.Exists(fileName))
                {
                    //创建文件夹 -> 创建文件
                    Directory.CreateDirectory(logpath);
                    //打开文件流 创建文件并写入
                    using (FileStream fileStream = File.Create(fileName))
                    {
                        string str = "dasdasda";
                        byte[] vs = Encoding.Default.GetBytes(str);
                        str = Encoding.Default.GetString(vs);
                        fileStream.Write(vs, 0, vs.Length);
                        fileStream.Flush();
                    }
                    //打开文件流
                    using (FileStream fileStream = File.Create(fileName))
                    {
                        StreamWriter streamWriter = new StreamWriter(fileStream);
                        streamWriter.WriteLine("1312312");
                        streamWriter.Flush();
                        
                    }
                    //
                    using (StreamWriter fileStream = File.AppendText(fileName))
                    {
                        //StreamWriter streamWriter = new StreamWriter(fileStream);
                        fileStream.WriteLine("1312312");
                        fileStream.Flush();
                    }

                    using (StreamWriter fileStream = File.AppendText(fileName))
                    {
                        string str = "dasdasda";
                        byte[] vs = Encoding.Default.GetBytes(str);
                        //StreamWriter streamWriter = new StreamWriter(fileStream);
                        fileStream.BaseStream.Write(vs);
                        fileStream.Flush();
                    }

                    foreach (string result in File.ReadAllLines(fileName))
                    {
                        var i = result;
                    }

                    string sResult = File.ReadAllText(fileName);
                    byte[] bytecont = File.ReadAllBytes(fileName);
                    var strs = Encoding.UTF8.GetString(bytecont);
                    //Demo1
                    {
                        using (FileStream fileStream1 = File.OpenRead(fileName))  //分批读取
                        {
                            StreamReader streamReader = new StreamReader(fileStream1);
                            int readLength = 5;
                            int length = 0;
                            do
                            {
                                byte[] vs = new byte[readLength];
                                // length 返回读取的长度
                                length = fileStream1.Read(vs, 0, readLength);
                                var set = Encoding.UTF8.GetString(vs);
                                for (var i = 0; i < length; i++)
                                {
                                    var ii = vs[i].ToString();
                                }
                            } while (readLength == length);
                            fileStream1.Flush();
                        }
                    }
                    //Demo2
                    {
                        using (FileStream fileStream1 = File.OpenRead(fileName))  //分批读取
                        {
                            StreamReader streamReader = new StreamReader(fileStream1);
                            //固定的长度
                            int readLength = 10;
                            //读取的长度
                            int length = 0;
                            //do
                            //{
                            //    byte[] vs = new byte[readLength];
                            //    // length 返回读取的长度
                            //    length = fileStream1.Read(vs, 0, readLength);
                            //    var set = Encoding.UTF8.GetString(vs);
                            //    for (var i = 0; i < length; i++)
                            //    {
                            //        var ii = vs[i].ToString();
                            //    }
                            //} while (readLength == length);

                            for (; ; )
                            {
                                byte[] vs = new byte[readLength];
                                //返回读取的长度
                                length = fileStream1.Read(vs, 0, readLength);
                                var set = Encoding.UTF8.GetString(vs);
                                for (var i = 0; i < length; i++)
                                {
                                    var ii = vs[i].ToString();
                                }

                                if (readLength != length)
                                {
                                    break;
                                }
                            }

                            do
                            {
                                byte[] vs = new byte[readLength];
                                //返回读取的长度
                                length = fileStream1.Read(vs, 0, readLength);
                                var set = Encoding.UTF8.GetString(vs);
                                for (var i = 0; i < length; i++)
                                {
                                    var ii = vs[i].ToString();
                                }
                            } while (readLength == length);
                            fileStream1.Flush();
                        }
                        File.Copy(fileName, fileNameCopy);
                        File.Move(fileName, fileNameMove);
                        File.Delete(fileNameCopy);
                        File.Delete(fileNameMove);
                    }
                }
            }

            {

                var directorStr = Directory.GetCurrentDirectory();

                DriveInfo[] driveInfos = DriveInfo.GetDrives();

                //获取驱动盘符信息
                foreach (DriveInfo drive in driveInfos)
                {

                    if (drive.IsReady)
                    {
                        Console.WriteLine($"{drive.DriveType}_{drive.VolumeLabel}_{drive.Name}_{drive.TotalSize}_{drive.TotalFreeSpace}");
                    }
                    else
                    {
                        Console.WriteLine($"{drive.DriveType}");
                    }
                }
                string fileName = Path.Combine(logpath, "log.txt");
                //GetDirectoryName 返回文件的目录名称  
                Console.WriteLine($"{Path.GetDirectoryName(fileName)}");  //返回目录名
                Console.WriteLine(Path.GetDirectoryName(@"d:\\adc"));
                Console.WriteLine(Path.GetDirectoryName(@"d:\\adc\abc.tex"));
                Console.WriteLine(Path.GetRandomFileName()); //返回随机的文件名
                Console.WriteLine(Path.GetFileNameWithoutExtension("d:\\adc.txt"));//反会abc
                Console.WriteLine(Path.GetInvalidPathChars()); //返回静止在路径中使用的字符
                Console.WriteLine(Path.GetInvalidFileNameChars()); //返回静止在文件中使用的字符

            }
        }
    }
}
