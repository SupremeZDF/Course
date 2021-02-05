using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoWinForm.Model
{
    public interface OneInterface
    {
        //public static int ID { get; set; }

        //public virtual void Name() { };

         string Nmae { get; set; }

        void names();

        event Action de;

   
    }
}
