using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Course03.Model.Model
{
    public abstract class ThreeModle
    {
        public ThreeModle()
        {

        }

        public static int fid { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        public abstract void Rune();

        public virtual void InstanceRun()
        {
            var i = 1;
        }

        public void TwoRun()
        {
            var o = 1;
        }
    }

    //[Obsolete("sada",true)]
    public class ThreeRunClass : ThreeModle
    {

        public ThreeRunClass()
        {

        }

        public override void Rune()
        {

            {
                foreach (var i in typeof(TwoA).GetProperties())
                {
                    Console.WriteLine($"{i.Name}");
                }
            }

            {
                foreach (var i in typeof(OnaA).GetProperties())
                {
                    Console.WriteLine($"{i.Name}");
                }
            }

            {
                foreach (var i in typeof(OnaA).GetMethods())
                {
                    Console.WriteLine($"{i.Name}");
                }
            }

            {

                foreach (var i in typeof(TwoA).GetProperties(BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    Console.WriteLine($"{i.Name}");
                }
            }

            {
                foreach (var i in typeof(TwoA).GetMethods())
                {
                    Console.WriteLine($"{i.Name}");
                }
            }
        }

        public new void TwoRun()
        {

        }

        public void ThreeRun()
        {

        }

        public override void InstanceRun()
        {
            var i = 1;
        }
    }

    public class OnaA
    {
        public int id { get; set; }

        public string Name { get; set; }

        private string Age { get; set; }

        public string Set { get; set; }

        public void OneRun()
        {
            OneAttrbute oneAttrbute = new OneAttrbute();
        }
    }

    public enum OneEnum
    {
        one = 1,
        two = 2
    }

    public struct OneStrut
    {
        public int dd { get; set; }

        public int dds;
    }

    public class TwoA : OnaA
    {
        public void TwoRun()
        {
            //OneStrut
            //OneStrut oneStrut = new OneStrut();
            /////oneStrut.x
            //var d = 0OneEnum.one;
        }
    }

    public class OneAttrbute : Attribute
    {
    
    }
}
