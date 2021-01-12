using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Course04.Model.IoSerzlia;

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

        //获取当前程序路径
        public static string Logppath2 = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 
        /// </summary>
        public static void OneIOSerialize() 
        {
            //var a = logpath;
            {
                if (!Directory.Exists(logpath)) 
                {
                   
                }
            }
        }
    }
}
