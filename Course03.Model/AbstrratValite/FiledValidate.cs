using System;
using System.Collections.Generic;
using System.Text;

namespace Course03.Model.AbstrratValite
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Method,AllowMultiple =true,Inherited = true)]
    public abstract class FiledValidateAttribute : Attribute
    {
        public abstract bool RequestValidate(object obj);

        public FiledValidateAttribute() 
        {
        
        }
    }
}
