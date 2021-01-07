using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.workExercise
{
    public class EventDY
    {
        public static void lessDY() 
        {
            Lesson lesson = new Lesson()
            {
                id = 1,
                Name = "22",
                price = 2699
            };
            lesson.lehandler += new EventObject().Event;
            lesson.price = 3999;

            //Lesson.lehandler+= new EventObject().Event;
            //Lesson.lehandler(null,null);
        }
    }

    public class StaticClass { 
    
        public static string a { get; set; }
    }
}
