using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.workExercise
{
    public class Lesson
    {
        public int id { get; set; }

        public string Name { get; set; }

        private double _price { get; set; }

        public  event EventHandler lehandler;

        public double price { 
            get
            { 
                return _price;
            }
            set 
            {
                var i = _price;
                if (value > price) 
                {
                    lehandler += OneEventags;
                    lehandler?.Invoke(this,new DiscountPrice() { beforePrice=_price,afterPeice=value});
                }
                _price = value;
            }
        }

        public void OneEventags(object? sender, EventArgs e) 
        {
            var I = id;
        }

        public void tWOEventags(object? sender, EventArgs e)
        {
            var I = id;
        }
    }

    public class DiscountPrice :EventArgs
    {
          public double beforePrice { get; set; }

          public double afterPeice { get; set; }
    }
}
