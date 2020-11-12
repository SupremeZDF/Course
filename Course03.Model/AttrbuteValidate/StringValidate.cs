using Course03.Model.AbstrratValite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course03.Model.AttrbuteValidate
{
    public class StringValidate : FiledValidateAttribute
    {
        public StringValidate() 
        {
        
        }

        public override bool RequestValidate(object obj)
        {
            if (!AllowNullSpace) 
            {
                var i = obj.ToString().Length > 0;
                if (i)
                    return true;
                else
                    return false;
            }
            return true;
        }

        public bool AllowNullSpace { get; set; }
    }
}
