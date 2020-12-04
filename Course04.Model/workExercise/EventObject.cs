using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.workExercise
{
    public class EventObject
    {
        public void Event(object? sender, EventArgs e) 
        {
            var _object = sender;
            var _e = e;
        }
    }
}
