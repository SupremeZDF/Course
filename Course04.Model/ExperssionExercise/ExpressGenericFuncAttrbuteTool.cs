using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.ExperssionExercise
{
    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Property,AllowMultiple =true,Inherited =true)]
    public class ExpressGenericFuncAttrbuteTool:Attribute
    {
        public string PropertyConvertName { get; set; }
        public ExpressGenericFuncAttrbuteTool(string _PropertyConvertName) 
        {
            PropertyConvertName = _PropertyConvertName;
        }
    }
}
