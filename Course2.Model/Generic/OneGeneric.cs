using System;
using System.Collections.Generic;
using System.Text;

namespace Course2.Model.Generic
{
    public class OneGeneric
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ThreeGeric threeGeric { get; set; }

        public List<TwoGeneric> twoGenerics { get; set; }
    }

    public class TwoGeneric 
    {
        public int id { get; set; }

        public string Name { get; set; }

        public List<ThreeGeric> threeGerics { get; set; }
    }

    public class ThreeGeric 
    {
       public int age { get; set; }

       public string Psword { get; set; }
    }
}
