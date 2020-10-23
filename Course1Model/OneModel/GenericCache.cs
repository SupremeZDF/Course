using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Course1Model.OneModel
{
    /// <summary>
    /// 普通缓存
    /// </summary>
    public class DictionaryCache
    {

        private static Dictionary<Type, string> _TypeTimeDictionary = null;
        /// <summary>
        /// 
        /// </summary>
        static DictionaryCache()
        {
            _TypeTimeDictionary = new Dictionary<Type, string>();
        }

        public DictionaryCache()
        {
        
        }

        public static string GetCache<T>()
        {
            Type type = typeof(Type);
            if (!_TypeTimeDictionary.ContainsKey(type))
            {
                _TypeTimeDictionary[type] = string.Format("{0}_{1}", typeof(T).FullName, DateTime.Now.ToString("yyyyMMddHHmmss,fff"));
            }
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            //pairs.Add();
            pairs["123"] = "123";
            return _TypeTimeDictionary[type];
        }
    }

    /// <summary>
    /// 泛型缓存
    ///  会产生 T 类型的副本
    /// </summary>
    public class GenericCache<T>
    {
        /// 静态构造函数
        /// </summary>
        static GenericCache() 
        {
            _TypeTime = string.Format("{0}_{1}",typeof(T).FullName,DateTime.Now.ToString("yyyyMMddHHmmss,fff"));
        }

        private static string _TypeTime = "";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static string GetCache() 
        {

            var i = 1; //编译器提供的便捷功能，称为语法糖

            return _TypeTime;
        }
    }

    /// <summary>
    /// 泛型测试
    /// </summary>
    public class TestStatic
    {
        static TestStatic() 
        {
            a = "123";
        }

        private static string a;
    }
}
