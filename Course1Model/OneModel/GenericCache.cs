using System;
using System.Collections.Generic;
using System.Linq;
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
            pairs["123"] = "123";
            return _TypeTimeDictionary[type];
        }
    }

    /// <summary>
    /// 泛型缓存
    /// </summary>
    public class GenericCache<T>
    {
        /// <summary>
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
            return _TypeTime;
        }
    }
}
