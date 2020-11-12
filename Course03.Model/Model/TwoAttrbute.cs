using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;

namespace Course03.Model.Model
{
    public class TwoAttrbute
    {

    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class enumAttrbute : Attribute
    {
        public enumAttrbute()
        {

        }

        /// <summary>
        /// 说明
        /// </summary>
        public string Remark { get; set; }
    }

    public enum enumClass 
    {
        [enumAttrbute(Remark ="正常")]
        nomal=1,
        [enumAttrbute(Remark = "异常")]
        error=2,
        [enumAttrbute(Remark = "关闭")]
        close=3
    }

    public static class enumRun 
    {

        //public enumRun() { }

        public static void enumRemark(this Enum @enum) 
        {
            //var a = @enum.GetType();
            //var aa = a.GetFields();
            //@enum = enumClass.close;
            Type type = @enum.GetType();

            var dd = @enum.ToString();

            var filed = type.GetField(@enum.ToString());
            var str = "";
            if (filed != null) 
            {
                if (filed.IsDefined(typeof(enumAttrbute), true)) 
                {
                    var getcustom = filed.GetCustomAttribute(typeof(enumAttrbute), true) as enumAttrbute;
                    str = getcustom.Remark;
                }
            }
            Type type1 = (new enumClass()).GetType();
        }

        public static void TwoAttrbuteRun() 
        {
        
        }
    }
}
