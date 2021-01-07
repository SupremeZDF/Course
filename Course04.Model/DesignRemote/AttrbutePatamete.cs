using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.DesignRemote
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Parameter,AllowMultiple =true,Inherited =true)]
    public class AttrbutePatamete : Attribute
    {
        public string propertyOrparameterName { get; set; }
    }
}
