using System.Linq.Expressions;

namespace Whyfate.Toolkit.Linq;

class ReplaceParameterVisitor : ExpressionVisitor
{
    private readonly ParameterExpression _oldParameter;
    private readonly ParameterExpression _newParameter;

    /// <summary>
    /// .
    /// </summary>
    /// <param name="oldParameter">old parameter.</param>
    /// <param name="newParameter">new parameter.</param>
    public ReplaceParameterVisitor(ParameterExpression oldParameter, ParameterExpression newParameter)
    {
        _oldParameter = oldParameter;
        _newParameter = newParameter;
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        return node == _oldParameter ? _newParameter : base.VisitParameter(node);
    }
}