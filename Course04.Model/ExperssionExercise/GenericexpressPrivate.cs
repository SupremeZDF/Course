using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.ExperssionExercise
{
    public class GenericexpressPrivate<Tin,Tout> where Tin:new() where Tout :new ()
    {
        public static Func<Tin, Tout> Func;

        private static Func<Tin, Tout> Funcs;

        public static int ac;

        private static int yy;

        public int aac;
        public GenericexpressPrivate(Func<Tin, Tout> func)
        {
            yy++;
            ac++;
            aac++;
            //Tin tin= new Tin();
            Func = func;
            Funcs = func;
            var a = Func.GetHashCode();  //715508023 801619166
            var b = Funcs.GetHashCode();  //715508023 801619166
        }

        static GenericexpressPrivate() 
        {
            //Tin tin = new Tin();
            //Func = c => new Tout { };
            //Funcs = c => new Tout { };
            //var a = Func.GetHashCode(); //1324739303
            //var b = Funcs.GetHashCode();  //1324739303
        }

        public void Consolog() 
        {
            var a = Func.GetHashCode();
            var b = Funcs.GetHashCode(); 
        }

        public static void Names() { 
        
           
        }

        public static void Consologs()
        {
            var a = Func.GetHashCode();
            var b = Funcs.GetHashCode();
        }
    }
}
