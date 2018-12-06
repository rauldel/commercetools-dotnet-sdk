﻿using System.Linq.Expressions;

namespace commercetools.Sdk.Linq
{
    public class ConstantPredicateVisitorConverter : ICartPredicateVisitorConverter
    {
        public bool CanConvert(Expression expression)
        {
            return expression.NodeType == ExpressionType.Constant;
        }

        public ICartPredicateVisitor Convert(Expression expression, ICartPredicateVisitorFactory cartPredicateVisitorFactory)
        {
            return new ConstantPredicateVisitor(expression.ToString());
        }
    }
}