using System.Linq.Expressions;

namespace Whyfate.Toolkit.Linq;

/// <summary>
/// Expression Extensions.
/// </summary>
public static class ExpressionExtensions
{
    /// <summary>
    /// AndAlso.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ex1">ex1.</param>
    /// <param name="ex2">ex2.</param>
    /// <returns></returns>
    public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> ex1, Expression<Func<T, bool>> ex2)
    {
        return Combine(ex1, ex2, ExpressionType.AndAlso);
    }

    /// <summary>
    /// OrElse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ex1">ex1.</param>
    /// <param name="ex2">ex2.</param>
    /// <returns></returns>
    public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> ex1, Expression<Func<T, bool>> ex2)
    {
        return Combine(ex1, ex2, ExpressionType.OrElse);
    }

    /// <summary>
    /// Combine.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ex1">ex1.</param>
    /// <param name="ex2">ex2</param>
    /// <param name="binaryType">type.</param>
    /// <returns></returns>
    public static Expression<Func<T, bool>> Combine<T>(
        Expression<Func<T, bool>> ex1,
        Expression<Func<T, bool>> ex2,
        ExpressionType binaryType)
    {
        var parameter = ex1.Parameters[0];
        var body = Expression.MakeBinary(
            binaryType,
            ex1.Body,
            new ReplaceParameterVisitor(ex2.Parameters[0], parameter)
                .Visit(ex2.Body)
        );

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}