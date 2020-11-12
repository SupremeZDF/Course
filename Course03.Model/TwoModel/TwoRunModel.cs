using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Course03.Model.TwoModel
{

    public class OneB:IEnumerable
    {
        public int A { get; set; }

        public string B { get; set; }

        public string C { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class TwoRunModel : OneB
    {
        public OneB oneB { get; set; }

        public List<OneB> oneBs { get; set; }
    }

    public class TwoRunReflection
    {
      
        public static void run()
        {
            TwoRunModel two = new TwoRunModel();

            var wu = two.GetType().GetProperty("oneB").PropertyType;
            var wus = two.GetType().GetProperty("oneBs").PropertyType.IsClass;


            var wuss = two.GetType().GetProperty("oneB").PropertyType.IsGenericType;
            var wusss = two.GetType().GetProperty("oneBs").PropertyType.IsGenericType;

            Type type = two.GetType();
            List<TwoRunModel> twoRunModels = new List<TwoRunModel>();
            //twoRunModels.Item
            var a = type.GetInterfaces()[0];
            var ad = typeof(IEnumerable);
            var aa = a as IEnumerable;
            //var aaa = (IEnumerable)Activator.CreateInstance(typeof(IEnumerable));
            var aaaa = a == typeof(IEnumerable);
            var b = type.GetMembers();

            foreach (PropertyInfo i in type.GetProperties()) 
            {
                var ii = i.PropertyType.GetInterface("Interface");
                if (i.PropertyType.IsGenericType && ii == typeof(IEnumerable))
                {
                    var inter = i.GetValue(two);
                    if (inter != null)
                    {
                        var count = (int)inter.GetType().GetProperty("Count").GetValue(inter, null);
                        for (var j = 0; j < count; j++)
                        {
                            var item = inter.GetType().GetProperty("Item").GetValue(inter, new object[] { i });
                        }
                    }
                    var obj = inter as IEnumerable<object>;
                    foreach (var obji in obj)
                    {
                        var ds = obji;
                    }
                }
                else 
                {
                    var dss = i.GetValue(two, null);
                    var ads= i.PropertyType.IsClass;
                }
            }
        }
    }
}
