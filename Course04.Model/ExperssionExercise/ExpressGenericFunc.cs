using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Course04.Model.ExperssionExercise
{
    public class ExpressGenericFunc<TIn,TOut>
    {
        public static Func<TIn, TOut> Func = null;
        static ExpressGenericFunc() 
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TIn), "x");
            foreach (PropertyInfo into in typeof(TOut).GetProperties()) 
            {
                if (typeof(TIn).GetProperty(into.Name) == null) 
                {
                    continue;
                }
                
            }
        }
    }
}
