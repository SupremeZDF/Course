using System;
using System.Collections.Generic;
using System.Text;

namespace Cource02.FactoryModel.Exercise.Tool
{
    public class NullbledValidate : BaseValidateAttribute
    {
        public NullbledValidate(bool isnull) 
        {
            isAllowNull = isnull;
        }

        public bool isAllowNull { get; set; }

        public override bool Validate(object values)
        {
            if (!isAllowNull) 
            {
                if (values == null || values == "") 
                {
                    return false;
                }
            }
            return true;
        }
    }
}
