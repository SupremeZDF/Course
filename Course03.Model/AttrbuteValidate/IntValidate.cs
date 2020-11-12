using Course03.Model.AbstrratValite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course03.Model.AttrbuteValidate
{
    public class IntValidate : FiledValidateAttribute
    {

        public IntValidate() 
        {
        
        }

        public override bool RequestValidate(object obj)
        {
            if (!AllowZero)
            {
                var i = (int)obj;
                if (i==0)
                    return false;
                else
                    return true;
            }
            return true;
        }

        public bool AllowZero { get; set; }
    }
}
