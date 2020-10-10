using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            DictionaryCache o = new DictionaryCache();
            DictionaryCache.GetCache<int>();
            //DictionaryCache.GetCache<int>();
        }
    }
}
