using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Course04.Model.IoSerzlia
{
    public class XMLHelper
    {
        /// <summary>
        /// 第一个
        /// </summary>
        public static void OneRunXmlDocment()
        {
            {
                //XDocument:用于创建一个XML实例文档
                //XElement:用于一些节点与节点属性的基本操作
                XmlDocument document = new XmlDocument();
                //XComment
                var father = document.CreateElement("BookStore");
                document.AppendChild(father);
                var Book = document.CreateElement("Book");
                var Books = document.CreateElement("Book");
                father.AppendChild(Book);
                father.AppendChild(Books);
                var name = document.CreateElement("Name");
                name.SetAttribute("BookName", "C#");
                name.InnerText = "C#入门";
                Book.AppendChild(name);
                Books.AppendChild(name);
                var a = new FileStream(Path.Combine("D:\\学习\\架构版班_学习课程\\ExerciseTool", $"xmlDocumentExerCise.xml"), FileMode.OpenOrCreate, FileAccess.Write);
                document.Save(a);
                a.Flush();
                a.Dispose();
            }
            {
                XmlDocument document = new XmlDocument();
                var path = Path.Combine("D:\\学习\\架构版班_学习课程\\ExerciseTool", $"xmlDocumentExerCise.xml");
                document.Load(path);
                //var father = document.CreateElement("BookStore");
                //document.AppendChild(father);
                //var Book = document.CreateElement("Book");
                //var Books = document.CreateElement("Book");
                //document.AppendChild(Book);
                //document.AppendChild(Books);

                var root = document.DocumentElement; //获得根节点
        


                var name = document.CreateElement("Name");
                name.SetAttribute("BookName", "C#");
                name.InnerText = "C#入门";

                XmlNode xmlNode = document.CreateNode("element", "NewBook","");
                xmlNode.InnerText = "wpf";
                root.AppendChild(xmlNode);
                root.AppendChild(name);

                //var text = root.InnerText;
                //var xml = root.InnerXml;
                var a = document.SelectSingleNode("BookStore/Book/Name");
                var aa = a.InnerText;
                //foreach (XmlNode node in a.ChildNodes)
                //{
                //    var nodeName = node.Name;
                //    var nodeXMLValue = node.InnerText;
                //}

                //foreach (XmlNode node in a)
                //{
                //    var nodes = node.Name;
                //    var nodetext = node.InnerText;
                //}
                //var b = document.SelectSingleNode("BookStore");
                //var c = root.SelectSingleNode("Book");
                //foreach (XmlNode node in c)
                //{
                //    var nodes = node.Name;
                //    var nodetext = node.InnerText;
                //}
                var d = root.SelectNodes("Book");

                d = document.GetElementsByTagName("*");

                document.Save(path);
                //Book.AppendChild(name);
            }
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load("");
                //获取根节点
                var rootNode = xmlDocument.DocumentElement;
                //获取第一个节点
                var element = (XmlElement)xmlDocument.SelectSingleNode("BookStore/NewBook");
                //删除节点
                rootNode.RemoveChild(element);

                //删除节点属性
                element.RemoveAllAttributes();
                element.RemoveAttribute("name");

                //修改节点与属性
                element.SetAttribute("name", "dasd");

                //获取节点与属性

                //获取指定单个节点
                element = (XmlElement)xmlDocument.SelectSingleNode("BookStore/NewBook");
                //获取指点得节点得集合
                var xmlNodes = xmlDocument.SelectNodes("");
                //获取所有得xml节点
                XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName("*");
            }
            {
                string fileName = Path.Combine("D:\\学习\\架构版班_学习课程\\ExerciseTool", $"xmlDocument.xml");//文件名称与路径
                XmlDocument document = new XmlDocument();
                //Guid.NewGuid()
                document.Load(fileName);
                //var d = document.CreateElement("");
                //d.SetAttribute("", "");
               
            }

            {
                //byte[] vs = new byte[1024*1024];
                //for(var i =0;i<vs.Length;i++) 
                //{
                //    vs[i] = 12;
                //}
                //XmlElement xmlElement = new XmlElement();  //主要是针对节点的一些属性进行操作
                //XmlDocument xmlDocument = new XmlDocument();  //主要是针对节点的CUID操作
                //XmlNode xmlNode = new XmlNode(); //为抽象类，做为以上两类的基类，提供一些操作节点的方法

                XElement xElement = new XElement(
                 new XElement("BookStore",
                     new XElement("Book",
                         new XElement("Name", "C#入门", new XAttribute("BookName", "C#")),
                         new XElement("Author", "Martin", new XAttribute("Name", "Martin")),
                         new XElement("Adress", "上海"),
                         new XElement("Date", DateTime.Now.ToString("yyyy-MM-dd"))
                         ),
                     new XElement("Book",
                         new XElement("Name", "WCF入门", new XAttribute("BookName", "WCF")),
                         new XElement("Author", "Mary", new XAttribute("Name", "Mary")),
                         new XElement("Adress", "北京"),
                         new XElement("Date", DateTime.Now.ToString("yyyy-MM-dd"))
                         )
                         )
                 
                 );

                //XElement xElement1 = new XElement(new XElement("Name",new XmlElement
                //    ("123",new XmlElement("23",""),
                //    )));

                //需要指定编码格式，否则在读取时会抛：根级别上的数据无效。 第 1 行 位置 1异常
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = new UTF8Encoding(false);
                settings.Indent = true;
                string fileName = Path.Combine("D:\\学习\\架构版班_学习课程\\ExerciseTool", $"xmlDocument.xml");//文件名称与路径
                XmlWriter xw = XmlWriter.Create(fileName, settings);
                xElement.Save(xw);
                //写入文件
                xw.Flush();
                xw.Close();

                
            }
        }
    }
}
