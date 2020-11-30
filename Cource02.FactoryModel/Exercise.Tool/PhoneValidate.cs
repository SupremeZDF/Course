using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Cource02.FactoryModel.Exercise.Tool
{
    public class PhoneValidate : BaseValidateAttribute
    {
        public PhoneValidate(string phonexpretion) 
        {
            strExoression = phonexpretion ;
        }

        private string strExoression { get; set; }

        public override bool Validate(object values)
        {
            Regex regex = new Regex(@"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$");
            if (!regex.IsMatch(values.ToString())) 
            {
                return false;
            }
            return true;
        }
    }
}
