using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.DesignRemote
{
    public interface IJueHuo
    {
        public virtual void JHShowTime() 
        {
            Console.WriteLine("绝活马上开始了");
        }

        void JHShowContent();

        public virtual void JHShowEnd() 
        {
            Console.WriteLine("表演结束了大家鼓掌");
        }
    }
}
