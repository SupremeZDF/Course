using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.ExperssionExercise
{
    public class GenericexpressPrivate<Tin,Tout> where Tin:new() where Tout :new ()
    {
        public static Func<Tin, Tout> Func;

        private static Func<Tin, Tout> Funcs;
        public GenericexpressPrivate()
        {
            Tin tin= new Tin();
            Func = c=> new Tout { };
        }

        static GenericexpressPrivate() 
        {
        
        }

        public void Consolog() 
        {
            var a = Func.GetHashCode();
            var b = Func.GetHashCode(); 
        }

        public static void Consologs()
        {
            var a = Func.GetHashCode();
            var b = Func.GetHashCode();
        }
    }
}
