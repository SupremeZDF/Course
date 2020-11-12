using System;
using System.Collections.Generic;
using System.Text;

namespace Course03.Model.AbstrratValite
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =true,Inherited =false)]
    public abstract class FiledValidate : Attribute
    {
        public abstract bool RequestValidate(object obj);
    }
}
