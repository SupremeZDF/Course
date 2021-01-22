using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using System.IO;
using Course04.Model.IoSerzlia.JsonSerzlia;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace Course04.Model.IoSerzlia
{
    public class SerializeHelper
    {
        //二进制序列化器
        public static void BinarySerialize()
        {
            var a = Directory.GetCurrentDirectory();

            string fileName = Path.Combine("D:\\学习\\架构版班_学习课程\\ExerciseTool", "WenBen.txt"); //文件与路径
            using (Stream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                List<JsonSeruzliaModle> jsonSeruzlias = JsonSeruzliaDataTool.GetExerCiseData();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, jsonSeruzlias);
            }
            using (Stream stream1 = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                //需要一个stream，这里是来源于文件
                BinaryFormatter binaryFormatter = new BinaryFormatter(); //创建二进制序列化器
                //使用二进制反序列化对象
                stream1.Position = 0; //重置流位置
                List<JsonSeruzliaModle> jsonSeruzlias = (List<JsonSeruzliaModle>)binaryFormatter.Deserialize(stream1);
            }
        }

        //BinaryFormatter序列化自定义类的对象时，序列化之后的流中带有空字符，以致于无法反序列化，反序列化时总是报错“在分析完成之前就遇到流结尾”（已经调用了stream.Seek(0, SeekOrigin.Begin);）。
        //改用XmlFormatter序列化之后，可见流中没有空字符，从而解决上述问题，但是要求类必须有无参数构造函数，而且各属性必须既能读又能写，即必须同时定义getter和setter，若只定义getter，则反序列化后的得到的各个属性的值都为null。

        /// <summary>
        /// 二进制序列化器
        /// </summary>
        public static void SoapSerialize()
        {
            string fileName = Path.Combine("D:\\学习\\架构版班_学习课程\\ExerciseTool", "Log.txt"); //文件与路径
            {
                using (Stream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write)) 
                {
                    var len = stream.Length;
                    var pos = stream.Position;
                    byte[] vs = Encoding.UTF8.GetBytes("y爷爷");
                    byte[] vss = Encoding.UTF8.GetBytes("我dadasdas我y爷爷");
                    //stream.Position= stream.Length
                    stream.Write(vs,0,vs.Length);
                    len = stream.Length;
                    pos = stream.Position;
                    stream.Write(vss, 0, vss.Length);
                    len = stream.Length;
                    pos = stream.Position;
                    MemoryStream memoryStream = new MemoryStream();
                    //memoryStream.Write();
                    //var  vsss = Encoding.UTF8.GetBytes("我dad哈哈asdas我");
                    //var  vssss = Encoding.UTF8.GetBytes("我dada哈哈sdas我");
                    //stream.Position = 0;
                    //stream.Write(vsss, 0, vs.Length);
                    //stream.Write(vssss, 0, vs.Length);
                }
                using (StreamWriter stream = File.AppendText(fileName))
                {
                    byte[] vs = Encoding.UTF8.GetBytes("我dadasdas我");
                    byte[] vss = Encoding.UTF8.GetBytes("我dadasdas我");
                    stream.Write("我dadasdas我");
                    stream.Write("我dadasdas我");
                    MemoryStream memoryStream = new MemoryStream();
                    //memoryStream.Write();
                    //stream.Position = 0;
                    stream.Write("我dadasdas我");
                    stream.Write("我dadasdas我");
                    
                }
                using (StreamWriter stream = File.AppendText(fileName))
                {

                    byte[] vs = Encoding.UTF8.GetBytes("耶耶耶");
                    stream.Write("我dadasdas我");

                }

            }
            fileName = Path.Combine("D:\\学习\\架构版班_学习课程\\ExerciseTool", "SoapSerialize.txt"); //文件与路径
            {
                //使用Soap序列化对象
                using (Stream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    Stream stream1 = new MemoryStream();
                    List<JsonSeruzliaModle> jsonSeruzlias = JsonSeruzliaDataTool.GetExerCiseData();
                    SoapFormatter soapFormatter = new SoapFormatter();  //创建二进制序列化器
                    soapFormatter.Serialize(stream, jsonSeruzlias);
                    soapFormatter.Serialize(stream1, jsonSeruzlias);
                    stream1.Position = 0;
                    StreamReader streamReader = new StreamReader(stream1);
                    var r = streamReader.ReadToEnd();
                    stream.Position = 0;
                    StreamReader streamReader1 = new StreamReader(stream);
                    var rr = streamReader1.ReadToEnd();
                }
                using (Stream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    SoapFormatter soapFormatter = new SoapFormatter(); //创建二进制序列化器
                                                                       //使用二进制反序化对象
                                                                       //stream.Position = 0;
                                                                       //MemoryStream
                    List<JsonSeruzliaModle> jsonSeruzlias = (List<JsonSeruzliaModle>)soapFormatter.Deserialize(stream);
                }
            }
        }

        /// <summary>
        /// XML序列化器
        /// </summary>
        public static void XmlSerialize()
        {
            //使用XML序列化对象
            string fileName = Path.Combine("D:\\学习\\架构版班_学习课程\\ExerciseTool", @"Student.xml");//文件名称与路径
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                List<JsonSeruzliaModle> jsonSeruzlias = JsonSeruzliaDataTool.GetExerCiseData();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<JsonSeruzliaModle>)); //创建XML序列化器，需要指定对象的类型
                
                //fStream.Position = 0; // 重置流配置
                xmlSerializer.Serialize(fStream, jsonSeruzlias);

                //Stream stream = null;
                //FileStream streamWriter;

                //streamWriter.Write(new byte[] { },0,12);


            }
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<JsonSeruzliaModle>));
                fStream.Position = 0;
                List<JsonSeruzliaModle> jsonSeruzlias = (List<JsonSeruzliaModle>)xmlSerializer.Deserialize(fStream);
            }
        }


    }
}
