using System;
using System.Collections.Generic;
using System.Text;

namespace Course03.Model.Model
{
    public partial class TwoModel
    {
         public int Name { get; set; }

         public string Password { get; set; }

        public string Age { get; set; }
    }

    public partial class TwoModel
    {
        public void Datadto()
        {
            this.OneRun(2);
        }
    }

    public static class TwoRunClass
    {
        public static void OneRun(this TwoModel twoModel,int i) 
        {
        
        }
    }
}
