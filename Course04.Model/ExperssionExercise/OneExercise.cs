﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AutoMapper.Mappers;

namespace Course04.Model.ExperssionExercise
{
    /// <summary>
    /// 表达式目录书
    /// </summary>
    public class OneExercise
    {
        /// <summary>
        /// 委托 
        /// </summary>
        public static void OneExpersion()
        {
            new List<int>().AsQueryable().Where(i => i > 2);
            Expression<Func<int, int, int>> expression = (m, n) => m * n + n;
            //Expression.Lambda
            //ConstantExpression 常量表达式
            ConstantExpression constantExpression = Expression.Constant(12);
            ConstantExpression constantExpression1 = Expression.Constant(23);
            //表达式相加 二元表达式
            BinaryExpression binary = Expression.Add(constantExpression, constantExpression1);

            Expression<Func<int, int, int>> expression1 = (m, n) => m * n + m + n * n + 2;

            //声明参数
            ParameterExpression parameter = Expression.Parameter(typeof(int), "m");
            ParameterExpression parameter1 = Expression.Parameter(typeof(int), "n");

            ConstantExpression expression2 = Expression.Constant(2);
            //二元表达式
            var multioly = Expression.Multiply(parameter, parameter1);
            var plus1 = Expression.Add(multioly, parameter);
            var plus2 = Expression.Add(plus1, parameter1);
            var plus4 = Expression.Multiply(plus2, parameter1);
            var plus3 = Expression.Add(plus4, expression2);

            Expression<Func<int, int, int>> expression3 = Expression.Lambda<Func<int, int, int>>(plus3, new ParameterExpression[] { parameter, parameter1 });
            //编译执行
           var d = expression3.Compile().Invoke(2,10);
        }

        public static void TwoExpression() 
        {
            {
                ExpressionTool expression1 = new ExpressionTool() { Id = 5, Age = 12, Name = "张三" };
                Expression<Func<ExpressionTool, bool>> expression = x => x.Id.ToString().Equals("5");

                var bl = expression.Compile().Invoke(expression1);
                ParameterExpression parameter = Expression.Parameter(typeof(ExpressionTool), "x");
                ConstantExpression constantExpression = Expression.Constant("5");
                PropertyInfo fieldInfo = typeof(ExpressionTool).GetProperty("Id");
                var plus1 = Expression.Property(parameter, fieldInfo);
                var methodTostring = typeof(int).GetMethod("ToString", new Type[] { });
                var tostringExp = Expression.Call(plus1, methodTostring);
                var tostingEquels = typeof(string).GetMethod("Equals", new Type[] { typeof(string) });
                var equlsExp = Expression.Call(tostringExp, tostingEquels, new Expression[] { constantExpression });
                Expression<Func<ExpressionTool, bool>> expression2 = Expression.Lambda<Func<ExpressionTool, bool>>(equlsExp, new ParameterExpression[] { parameter });
                bool ex = expression2.Compile().Invoke(expression1);
            }

            {
                ExpressionTool expression0 = new ExpressionTool() { Id = 5, Age = 12, Name = "张三" };
                //ExpressionMapper.
                Expression<Func<ExpressionTool, bool>> expression = x => x.Name.Contains("三") && x.Age > 5;

                ParameterExpression expression1 = Expression.Parameter(typeof(ExpressionTool),"x");
                ConstantExpression constant = Expression.Constant("三");
                ConstantExpression constant1 = Expression.Constant(5);
                PropertyInfo propertyInfo = typeof(ExpressionTool).GetProperty("Name");
                MemberExpression propertyInfoExtensions = Expression.Property(expression1, propertyInfo);
                MethodInfo methodInfo = typeof(String).GetMethod("Contains", new Type[] { typeof(string) });
                MethodCallExpression expression2 = Expression.Call(propertyInfoExtensions, methodInfo,new Expression[] { constant });

                PropertyInfo propertyInfo1 = typeof(ExpressionTool).GetProperty("Age");
                MemberExpression memberExpression = Expression.Property(expression1, propertyInfo1);
                BinaryExpression binaryExpression = Expression.GreaterThan(memberExpression, constant1);

                BinaryExpression binaryExpression1 = Expression.AndAlso(expression2, binaryExpression);

                Expression<Func<ExpressionTool, bool>> expression3 = Expression.Lambda<Func<ExpressionTool, bool>>(binaryExpression1, new ParameterExpression[] { expression1 });

                var d = expression3.Compile().Invoke(expression0);
            }
        }
    }
}
