using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Course03.Model.AbstrratValite;
using Course03.Model.AttrbuteValidate;

namespace Course03.Model.Runvalidate
{
    public class OneRunAttrbute
    {

        public static void Run()
        {

            B s = new B();

            s.AttrbuteInherite();

            RunModelAttrbute run = new RunModelAttrbute();
            run.Small = 12;
            run.AgeString = "123";
            run.requestValidate();
        }
    }


    public abstract class A
    {
        [IntValidate(AllowZero = false)]
        public virtual int aa { get; set; }

        [IntValidate(AllowZero = false)]
        public int bb { get; set; }

        [IntValidate(AllowZero = false)]
        public virtual void Name()
        {

        }
    }

    public class B : A
    {
        [IntValidate(AllowZero = true)]
        public override int aa { get => aa; set => aa = value; }

        [IntValidate(AllowZero = true)]
        public new int bb { get; set; }

        [IntValidate(AllowZero = true)]
        public override void Name()
        {

        }
    }


    public static class AttrbuteExtend
    {

        public static void AttrbuteInherite<T>(this T t)
        {
            var type = t.GetType();

            foreach (var i in type.GetMethods())
            {

                var a = i.GetCustomAttributes(typeof(FiledValidateAttribute), true);
                var aa = i.GetCustomAttributes(typeof(FiledValidateAttribute), false);
            }


            foreach (var i in type.GetProperties())
            {
                var a = i.GetCustomAttributes(typeof(FiledValidateAttribute), true);
                var aa = i.GetCustomAttributes(typeof(FiledValidateAttribute), false);

                var d = i.GetValue(i, null);
                if (d != null) 
                {
                    var count = (int)d.GetType().GetProperty("Count").GetValue(d);
                    for (var j = 0; j < count; j++) 
                    {
                        var obj = d.GetType().GetProperty("Item").GetValue(d, new object[] { i });

                        foreach (var jj in obj.GetType().GetProperties()) 
                        {
                        
                        }
                    }
                }
            }
        }

        public static void requestValidate<T>(this T t) where T : class, new()
        {
            var type = t.GetType();
            foreach (var i in type.GetProperties())
            {
                if (i.IsDefined(typeof(FiledValidateAttribute), true))
                {
                    var obj = i.GetValue(t, null);
                    foreach (FiledValidateAttribute filed in i.GetCustomAttributes(typeof(FiledValidateAttribute), true))
                    {
                        var bl = filed.RequestValidate(obj);
                    }
                }
            }
        }
    }

    public class RunModelAttrbute
    {
        [StringValidate(AllowNullSpace = false)]
        [IntValidate(AllowZero = false)]
        public int Small { get; set; }

        [StringValidate(AllowNullSpace = false)]
        [IntValidate(AllowZero = false)]
        public string AgeString { get; set; }
    }
}
