using System;
using System.Collections.Generic;
using System.Text;

namespace Course2.Model.BaseModel
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class EFExpriceAttribute : Attribute 
    {
        public EFExpriceAttribute() 
        {
         
        }

        public bool isPrimary { get; set; }
        
        public string FiledName { get; set; }
    }
}
