using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _Common_Expressions
{
    public sealed class ParameterReplacer : ExpressionVisitor
    {
        private readonly Dictionary<string, ParameterExpression> _parametersDict;

        public ParameterReplacer(params ParameterExpression[] parameters) : this((IEnumerable<ParameterExpression>)parameters)
        {

        }

        public ParameterReplacer(IEnumerable<ParameterExpression> parameters)
        {
            _parametersDict = parameters.ToDictionary(p => p.Type.Name, p => p);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return base.VisitParameter(_parametersDict.TryGetValue(node.Type.Name, out var parameter)
                ? parameter
                : node);
        }
    }
}