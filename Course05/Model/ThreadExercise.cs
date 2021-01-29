using System;
using System.Collections.Generic;
using System.Text;

namespace Course05.Model.Model
{
    public class ThreadExercise
    {
        public static void OneExercise()
        {
            //for (var i = 0; i < 10; i++)
            //{
            //    Model.Name();
            //}

            Action<string> action = new Action<string>(OneName);
            action.BeginInvoke("", null, null);
        }

        public static void OneName(string Name) 
        {
        
        }
    }
}
