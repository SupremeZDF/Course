using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.Extend
{
    public static class OneLanmdaExtend
    {
        public static List<T> GetTs<T>(this List<T> ts, Func<T, bool> func)
        {
            List<T> ts1 = new List<T>();
            if (ts == null)
            {
                return null;
            }
            foreach (T i in ts)
            {
                if (func(i))
                {
                    ts1.Add(i);
                }
            }
            return ts1;
        }

        public static IEnumerable<T> GetIEnumerber<T>(this List<T> ts, Func<T, bool> func)
        {
            foreach (T i in ts)
            {
                if (func(i))
                {
                    yield return i;
                }
            }
        }

        public static List<TResult> GetListU<T, TResult>(this List<T> ts, Func<T, TResult> func) 
        {
            if (ts == null) 
            {
                return null;
            }

            foreach (var i in ts) 
            {
                var result = func(i);
            }
            return null;
        }
    }
}
