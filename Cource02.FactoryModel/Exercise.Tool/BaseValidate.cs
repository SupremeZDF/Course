using System;
using System.Collections.Generic;
using System.Text;

namespace Cource02.FactoryModel.Exercise.Tool
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple =true,Inherited =true)]
    public abstract class BaseValidateAttribute : Attribute
    {
        public BaseValidateAttribute() 
        {
            
        }

        private Func<object, bool> _GetFunc;

        public BaseValidateAttribute(Func<object,bool> func)
        {
            _GetFunc = func;
        }

        public bool FuncValidate(object val) 
        {
            return _GetFunc(val);
        }

        public abstract bool Validate(object values);
    }
}
