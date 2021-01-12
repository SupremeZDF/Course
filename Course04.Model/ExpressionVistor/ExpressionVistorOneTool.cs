using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;

namespace Course04.Model.ExpressionVistor
{
    public class ExpressionVistorOneTool : ExpressionVisitor
    {
        public void Run(Expression Visit) 
        {
            //访问
            this.Visit(Visit);
        }

        public override Expression Visit(Expression node)
        {
            var nodes = node.ToString();
            var nodeType = node.NodeType;
            return base.Visit(node);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Add) 
            {

            }
            return base.VisitBinary(node);
        }
    }
}
