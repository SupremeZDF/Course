using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Cource02.FactoryModel.Exercise.Tool
{
    public class EmailValidate : BaseValidateAttribute
    {
        public EmailValidate(string strExpress) 
        {
            emailExpress = strExpress;
        }

        private string emailExpress = "";

        public override bool Validate(object value)
        {
            var emailExpression = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            Regex regex = new Regex(emailExpression);
            if (!regex.IsMatch(value.ToString()))
            {
                return false;
            }
            return true;
        }
    }
}
