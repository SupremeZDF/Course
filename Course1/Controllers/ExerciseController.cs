using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Http;
using Course1Model;
using Course1Model.OneModel;

namespace Course1.Controllers
{
    public class ExerciseController : ApiController
    {
        [HttpGet]
        public void OneCnecantier() 
        {
            int a = 1;
            string b = "2";
            double c = 3;
            OneClass.ShowObject(a);
            OneClass.ShowObject(b);
            OneClass.ShowObject(c);
        }

        [HttpGet]
        public void T() 
        {
            //OneClass.Show<string>(null);
            OneClass.Show();
        }

        [HttpGet]
        public void GenericCache() 
        {
            //DictionaryCache o = new DictionaryCache();
            //DictionaryCache.GetCache<int>();
            //DictionaryCache.GetCache<int>();

            Course1Model.OneModel.GenericCache<int> genericCache = new GenericCache<int>();
           
            Course1Model.OneModel.GenericCache<string> genericCache1 = new GenericCache<string>();

            //TestStatic testStatic = new TestStatic();
            //TestStatic testStatic1 = new TestStatic();
        }

        /// <summary>
        /// 
        /// </summary>
        public void One() 
        {
          //List<>
        }

        [HttpGet]
        public void ThreeMethod() 
        {
            //ThreeClass.Get<int>(1);
        }

        [HttpGet]
        public void Asseblay() 
        {
            var c = AppDomain.CurrentDomain.BaseDirectory;
            var cc = Assembly.Load("");
        }
    }
}
