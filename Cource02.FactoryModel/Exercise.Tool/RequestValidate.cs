using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Cource02.FactoryModel.Exercise.Tool
{
    public static class RequestValidateClass
    {
        public static Result RequestValidate<T>(this T o) where T : class, new()  
        {
            Result result = new Result() { code = 1 };
            List<RequestMsg> requestMsgs = new List<RequestMsg>();
            try
            {
                if (o == null)
                {
                    result.code = 0;
                    result.message = "校验数据失败,数据为空";
                    return result;
                }
                var ttype = o.GetType();
                foreach (var i in ttype.GetProperties())
                {
                    if (i.IsDefined(typeof(BaseValidateAttribute)))
                    {
                        var value = i.GetValue(o);
                        foreach (var j in i.GetCustomAttributes(typeof(BaseValidateAttribute), true))
                        {
                            var fuc = j as BaseValidateAttribute;
                            if (fuc != null)
                            {
                                if (!fuc.Validate(value))
                                {
                                    RequestMsg msg = new RequestMsg();
                                    msg.name = i.Name;
                                    msg.msg = "校验失败";
                                    requestMsgs.Add(msg);
                                    result.code = 0;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.code = 0;
                result.message = ex.Message;
            }
            result.@object = requestMsgs;
            return result;
        }
    }
}
