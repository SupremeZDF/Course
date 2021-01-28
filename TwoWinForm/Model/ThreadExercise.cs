using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoWinForm.Model
{
    public class ThreadExercise
    {
        public static void OneExercise() 
        {
            for (var i = 0; i < 10; i++) 
            {
                Model.Name();
            }
        }
    }
}
